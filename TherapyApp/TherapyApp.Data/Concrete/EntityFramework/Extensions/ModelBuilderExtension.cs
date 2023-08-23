using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Concrete.EntityFramework.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Role Information
            List<Role> roles = new List<Role>
            {
                new Role { Name="Admin", Description="Admin role.", NormalizedName="ADMIN"},
                new Role { Name="User", Description="User Role.", NormalizedName="USER"},
                new Role { Name="Advisor", Description="Advisor Role", NormalizedName="ADVISOR"},
                
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region User information
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Türkay",
                    LastName="Dursun",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Email="turkaydursun@gmail.com",
                    NormalizedEmail="TURKAYDURSUN@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth= new DateTime(1964,7,24),
                    Address="Pasa mah.Evren Sk.No:8/4 Sisli/İstanbul",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true,
                    PhoneNumber="+9053547318",
                    PhoneNumberConfirmed=true
                },
                new User
                {
                    FirstName="Erdi",
                    LastName="Dursun",
                    UserName="user",
                    NormalizedUserName="USER",
                    Email="yunusemre@gmail.com",
                    NormalizedEmail="YUNUSEMRE@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth= new DateTime(1993,12,12),
                    Address="Pasa mahallesi dilek sokak no:8/4 sisli/istanbul",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true,
                    PhoneNumber="+904556677888",
                    PhoneNumberConfirmed=true
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
           


            #region Password Information
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            #endregion
            #region Role Assignment Operations
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles[0].Id },
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles[1].Id }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

        }
    }

}
