using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Data.Concrete.EntityFramework.Configs;
using TherapyApp.Data.Concrete.EntityFramework.Extensions;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Concrete.EntityFramework.Contexts
{
    public class TherapyAppContext : IdentityDbContext<User, Role, string>
    {
        public TherapyAppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdvisorCategory> AdvisorCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdvisorConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
