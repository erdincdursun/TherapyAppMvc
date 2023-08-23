using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TherapyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Education = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advisors_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorCategories",
                columns: table => new
                {
                    AdvisorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorCategories", x => new { x.AdvisorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AdvisorCategories_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvisorCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0597f004-c4dc-4eba-bf7f-a7016d69ab7d", null, "Admin role.", "Admin", "ADMIN" },
                    { "aaafa58f-bc74-46ae-b2a2-bf82b78e26e5", null, "User Role.", "User", "USER" },
                    { "ae371bb7-e8dc-4668-96e0-816cbfc9556e", null, "Advisor Role", "Advisor", "ADVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "83474a87-b307-4e35-89af-1007675e899f", 0, "Pasa mah.Evren Sk.No:8/4 Sisli/İstanbul", "İstanbul", "150b4295-3086-4512-bd08-f6578ee236c4", new DateTime(1964, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "turkaydursun@gmail.com", true, "Türkay", "Erkek", "Dursun", true, null, " ", "TURKAYDURSUN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEGW+WJzUY/qhKQRM1AQKZzWyNiR3yIg/yQl1IPT7l447MtEiaUr2Azo6NkKL2+T1A==", "+9053547318", true, "", false, "admin" },
                    { "f2a5b5d4-45ee-477b-b477-9eece5eb805a", 0, "Pasa mahallesi dilek sokak no:8/4 sisli/istanbul", "İstanbul", "16849ff4-d8dd-412e-a2b7-02d60de5f7c4", new DateTime(1993, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "yunusemre@gmail.com", true, "Erdi", "Erkek", "Dursun", true, null, " ", "YUNUSEMRE@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAEFmyD2cdu5ZcNicVgDbj9kcmoeqb9rRL1gaKLj0b/1dMJ0XTSFKDtNcxq/y/kh2rzQ==", "+904556677888", true, "", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(761), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(775), "Aile Danışmanı", "aile-danismani" },
                    { 2, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(781), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(781), "Klinik Psikolog", "klinik-danismani" },
                    { 3, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(784), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(791), "Çocuk ve Ergen Psikoloğu", "cocuk-ve-ergen-psikologu" },
                    { 4, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(808), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(809), "Çift Terapisti", "cift-terapisti" },
                    { 5, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(811), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(812), "Dil ve Konuşma Terapisti", "dil-ve-konusma-terapisti" },
                    { 6, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(814), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(815), "Uzman Nöropsikolog", "uzman-noropsikolog" },
                    { 7, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(816), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(817), "Fizyoterapist", "fizyoterapist" },
                    { 8, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(819), true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(820), "Diyetisyen", "diyetisyen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4529), "Adli psikoloji, sanıkların soruşturma tekniği, görgü tanıklarının düşebileceği yanılsamaların saptanması, suç işleme yönteminin önceden bilinmesi, suçlu çocukların yeniden eğitim yoluyla toplum yaşamlarına uyumlarının sağlanması gibi konularla ilgilenen psikoloji dalıdır", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4541), "Adli Psikoloji", "adli-psikoloji" },
                    { 2, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4548), "Eş, çocuklar ve yakın akrabaları da kapsayan, aile üyelerini ilgilendiren sorunlara yönelik bir terapi formatıdır. Aile terapisi, ailede sorun ve çatışmaların belirlemesine ve bunların çözülmesine yardımcı olur.", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4549), "Aile Terapisi", "aile-terapisi" },
                    { 3, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4552), "Anksiyete bir diğer adıyla kaygı bozukluğu, psikolojik bir rahatsızlıktır.Anksiyete bozukluğu olan kişilerde, yoğun, sürekli devam eden bir endişe hali ve günlük hayatta rastlanılan durumlara karşı korku vardır.Panik atak krizleriyle de kendini gösterebilir", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4553), "Anksiyete (kaygı) Bozuklukları", "anksiyete-bozukluklari" },
                    { 4, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4555), "İki uçlu duygudurum bozukluğu bir diğer adıyla manik-depresif hastalık, kişinin duygudurumunda, enerjisinde ve sosyal aktiviteleri tamamlama yetisinde bozulmalara neden olan psikolojik hastalıktır.", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4556), "Bipolar Bozukluk", "bipolar-bozukluk" },
                    { 5, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4558), "boşanma sürecinde psikolojik sorunlar yaşamayı en aza indirmek, ortaya çıkması muhtemel olan yas ve ayrılıkla baş etmeyi kolaylaştırmak, bu sürecin çocuklar ve çiftler açısından en az hasarla atlatılmasını kolaylaştırmak için gerçekleştirilen bir hizmettir.", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4558), "Boşanma Danışmanlığı", "bosanma-danismanligi" },
                    { 6, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4561), "bireylerin kendini psikolojik olarak iyi hissetmediği, çok uzun süreler devam edebilen ve günlük hayatı etkileyen psikolojik bir rahatsızlıktır", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4561), "Depresyon", "depresyon" },
                    { 7, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4563), "Uyku esnasında oluşan sorunlar veya aksiliklerin tamamına uyku bozukluğu denir", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4564), "Uyku Bozuklukları", "uyku-bozukluklari" },
                    { 8, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4566), "danışan birey veya grupla kariyer gelişimi ile ilgili sorunlarda (meslek seçimi, iş arama, vb.) profesyonel bir danışmanın yürütüldüğü ilişki biçimidir", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4567), "Kariyer Danışmanlığı", "kariyer-danismanligi" },
                    { 9, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4569), "Asperger sendromu esasen otistik spektrum bozukluğu yani kısaca OSB adı verilen geniş bir tanı yelpazesinin parçasıdır", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4569), "Asperger Sendromu", "asperger-sendromu" },
                    { 10, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4571), "ikili iletişim kuran taraflar arasında yapılan bir takım hayatlar sonucunda ortaya çıkar. ", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4572), "İletişim Problemleri", "iletisim-problemleri" },
                    { 11, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4574), "Yaralanma, hastalık, travma ya da yaşlılık gibi nedenlerle eksilme gösteren fonksiyonel hareketleri geri kazandırma amaçlı yapılan; elektrik akımı, sıcak ya da soğuk uygulaması, egzersizler ya da çeşitli uygulamalarla hastaların tedavisine verilen isimdir.", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4575), "Fizyoterapist", "fizyoterapist" },
                    { 12, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4577), "Sağlık kurallarına uygun olarak kullanılmasını sağlayan, besin denetimini yapan, bu konularda fizyolojik, psikolojik ve sosyolojik olarak sağlıklı yaşam biçimlerinin benimsenmesi amacıyla bireyi ve toplumu bilgilendiren, bilinçlendiren kişilerdir.", true, false, new DateTime(2023, 7, 27, 9, 16, 1, 911, DateTimeKind.Local).AddTicks(4577), "Diyetisyen", "diyetisyen" }
                });

            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "Id", "About", "BranchId", "CreatedDate", "Education", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "PhotoUrl", "Price", "Url" },
                values: new object[,]
                {
                    { 1, "Erdinç Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 1, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6851), "Gazi Üniversitesi Rehberlik ve Psikolojik", "Erdinç", true, false, "Dursun", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6870), "erdinc-dursun.jpg", 500m, "erdinc-dursun-1" },
                    { 2, "Büşra Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 2, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6886), "Beykent Üniversitesi Rehberlik ve Psikolojik", "Büşra", true, false, "Dursun", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6886), "busra-dursun.jpg", 950m, "busra-dursun-2" },
                    { 3, "Ayse Hafsa Doğan, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 3, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6891), "İstanbul Üniversitesi Rehberlik ve Psikolojik", "Ayşe Hafsa", true, false, "Doğan", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6892), "ayse-hafsa-dogan.jpg", 350m, "ayse-hafsa-dogan-3" },
                    { 4, "Ömer Ayaz Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 4, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6895), "Marmara Üniversitesi Rehberlik ve Psikolojik", "Ömer Ayaz", true, false, "Dursun", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6896), "omer-ayaz-dursun.jpg", 900m, "omer-ayaz-dursun-4" },
                    { 5, "Ömer Ayaz Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 5, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6900), "Gazi Üniversitesi Rehberlik ve Psikolojik", "Zeynep Serra", true, false, "Dogan", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6901), "zeynep-serra-dogan.jpg", 700m, "zeynep-serra-dogan-5" },
                    { 6, "Nazlı Öztürk, lisans eğitimini 2021 yılında Adnan Menderes Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 6, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6904), "Adnan Menderes Üniversitesi Rehberlik ve Psikolojik", "Nazlı", true, false, "Öztürk", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6905), "nazli-ozturk.jpg", 700m, "nazli-ozturk-6" },
                    { 7, "Erdi Dursun, lisans eğitimini 2021 yılında İstanbul Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 3, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6908), "İstanbul Üniversitesi Rehberlik ve Psikolojik", "Erdi", true, false, "Dursun", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6909), "erdi-dursun.jpg", 650m, "erdi-dursun-7" },
                    { 8, "Özübek, lisans eğitimini 2021 yılında Arel Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 7, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6912), "Arel Üniversitesi Rehberlik ve Psikolojik", "Ahmet Tuğra", true, false, "Özübek", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6913), "ahmet-tugra-ozubek.jpg", 100m, "ahmet-tugra-ozubek-8" },
                    { 9, "Arzu Öztürk, lisans eğitimini 2021 yılında Vakfıkebir Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 8, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6916), "Vakfıkebir Üniversitesi Rehberlik ve Psikolojik", "Arzu", true, false, "Öztürk", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6917), "arzu-ozturk.jpg", 700m, "arzu-ozturk-9" },
                    { 10, "Şeyda Nur Doğan, lisans eğitimini 2021 yılında Anadolu Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 6, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6921), "Anadolu Üniversitesi Rehberlik ve Psikolojik", "Şeyda Nur", true, false, "Doğan", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6921), "seyda-nur-dogan.jpg", 320m, "seyda-nur-dogan-10" },
                    { 11, "Abdul Öztürk, lisans eğitimini 2021 yılında Vakfıkebir Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 1, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6925), "Vakfıbekir Üniversitesi Rehberlik ve Psikolojik", "Abdul", true, false, "Öztürk", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6925), "abdul-ozturk.jpg", 190m, "abdul-ozturk-11" },
                    { 12, "Habibe Dursun, lisans eğitimini 2021 yılında Sivas Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ", 8, new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6929), "Sivas Üniversitesi Rehberlik ve Psikolojik", "Habibe", true, false, "Dursun", new DateTime(2023, 7, 27, 9, 16, 1, 910, DateTimeKind.Local).AddTicks(6930), "habibe-dursun.jpg", 290m, "habibe-dursun-12" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0597f004-c4dc-4eba-bf7f-a7016d69ab7d", "83474a87-b307-4e35-89af-1007675e899f" },
                    { "aaafa58f-bc74-46ae-b2a2-bf82b78e26e5", "f2a5b5d4-45ee-477b-b477-9eece5eb805a" }
                });

            migrationBuilder.InsertData(
                table: "AdvisorCategories",
                columns: new[] { "AdvisorId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 10 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 9 },
                    { 3, 7 },
                    { 3, 10 },
                    { 4, 2 },
                    { 4, 5 },
                    { 4, 10 },
                    { 5, 8 },
                    { 5, 10 },
                    { 6, 1 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 9 },
                    { 7, 7 },
                    { 7, 10 },
                    { 8, 11 },
                    { 9, 12 },
                    { 10, 1 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 9 },
                    { 11, 2 },
                    { 11, 5 },
                    { 11, 6 },
                    { 11, 10 },
                    { 12, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorCategories_CategoryId",
                table: "AdvisorCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_BranchId",
                table: "Advisors",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvisorCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
