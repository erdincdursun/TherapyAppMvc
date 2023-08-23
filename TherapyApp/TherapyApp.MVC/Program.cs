using AspNetCoreHero.ToastNotification;
using ThreapyApp.MVC.EmailServices.Abstract;
using ThreapyApp.MVC.EmailServices.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TherapyApp.Business.Abstract;
using TherapyApp.Business.Concrete;
using TherapyApp.Data.Abstract;
using TherapyApp.Data.Concrete.EntityFramework.Contexts;
using TherapyApp.Data.Concrete.EntityFramework.Repositories;
using TherapyApp.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TherapyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<TherapyAppContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;//Sayýsal deðer
    options.Password.RequireLowercase = true;//küçük harf
    options.Password.RequireUppercase = true;//büyük harf
    options.Password.RequiredLength = 6;//þifre uzunlugu
    options.Password.RequireNonAlphanumeric = true;//özel karakter

    options.Lockout.MaxFailedAccessAttempts = 3; //Üst üste izin verilecek hatalý giriþ sayýsý
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//Üst üste izin verilen kez hatalý giriþ yapmaya çalýþýlan hesap hangi süreyle kilitlenecek?

    options.User.RequireUniqueEmail = true;//Sistemden daha önce kayýtlý olmayan bir mail adresi kullanýlmak zorunda olsun mu?

    options.SignIn.RequireConfirmedEmail = true;//Kayýt olunurken email onayý istensin mi?
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kayýt olunurken telefon onayý istensin mi?
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//Eðer kullanýcý eriþebilmesi için login olmak zorunda olduðu bir istekte bulunursa, yönlendirilecek path.
    options.LogoutPath = "/account/logout";//Logout olduðunda yönlendirilecek action
    options.AccessDeniedPath = "/account/accessdenied";//Kullanýcý yetkisi olmayan bir endpointe istekte bulunursa yönlendirilecek path
    options.ExpireTimeSpan = TimeSpan.FromDays(30);//Cookiemizin yaþam süresi ne kadar olacak?
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = "ThreapyApp.Security.Cookie"
    };
});

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(option => new SmtpEmailSender(

    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"],
    builder.Configuration.GetValue<bool>("EmailSender:EnableSsl")
    ));

builder.Services.AddScoped<IAdvisorService, AdvisorManager>();
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IAdvisorRepository, EfCoreAdvisorRepository>();
builder.Services.AddScoped<IBranchRepository, EfCoreBranchRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});


var app = builder.Build();



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "advisorscategory",
    pattern: "advisor/{categoryurl?}",
    defaults: new { controller = "AdvisorController", action = "AdvisorList" }
    );
app.MapControllerRoute(
    name: "advisorsBranch",
    pattern: "advisor/{branchyurl?}",
    defaults: new { controller = "AdvisorController", action = "AdvisorList" }
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
