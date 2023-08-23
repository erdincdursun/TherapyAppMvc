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
    options.Password.RequireDigit = true;//Say�sal de�er
    options.Password.RequireLowercase = true;//k���k harf
    options.Password.RequireUppercase = true;//b�y�k harf
    options.Password.RequiredLength = 6;//�ifre uzunlugu
    options.Password.RequireNonAlphanumeric = true;//�zel karakter

    options.Lockout.MaxFailedAccessAttempts = 3; //�st �ste izin verilecek hatal� giri� say�s�
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//�st �ste izin verilen kez hatal� giri� yapmaya �al���lan hesap hangi s�reyle kilitlenecek?

    options.User.RequireUniqueEmail = true;//Sistemden daha �nce kay�tl� olmayan bir mail adresi kullan�lmak zorunda olsun mu?

    options.SignIn.RequireConfirmedEmail = true;//Kay�t olunurken email onay� istensin mi?
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kay�t olunurken telefon onay� istensin mi?
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//E�er kullan�c� eri�ebilmesi i�in login olmak zorunda oldu�u bir istekte bulunursa, y�nlendirilecek path.
    options.LogoutPath = "/account/logout";//Logout oldu�unda y�nlendirilecek action
    options.AccessDeniedPath = "/account/accessdenied";//Kullan�c� yetkisi olmayan bir endpointe istekte bulunursa y�nlendirilecek path
    options.ExpireTimeSpan = TimeSpan.FromDays(30);//Cookiemizin ya�am s�resi ne kadar olacak?
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
