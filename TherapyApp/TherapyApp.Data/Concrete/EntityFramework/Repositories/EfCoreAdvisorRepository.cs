using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Data.Abstract;
using TherapyApp.Data.Concrete.EntityFramework.Contexts;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Concrete.EntityFramework.Repositories
{
    public class EfCoreAdvisorRepository : EfCoreGenericRepository<Advisor>, IAdvisorRepository
    {
        public EfCoreAdvisorRepository(TherapyAppContext _context) : base(_context)
        {
        }
        private TherapyAppContext Context
        {
            get { return _dbContext as TherapyAppContext; }
        }

        public async Task<List<Advisor>> GetAllActiveAdvisorsAsync(string categoryUrl = null, string brancherUrl = null)
        {
            var result = Context
                    .Advisors
                    .Where(a => a.IsActive && !a.IsDeleted)
                    .Include(b => b.AdvisorCategories)
                    .Include(b => b.Branch)
                    .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(b => b.AdvisorCategories)
                    .ThenInclude(bc => bc.Category)
                    .Where(b => b.AdvisorCategories.Any(bc => bc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (brancherUrl != null)
            {
                result = result
                    .Where(b => b.Branch.Url == brancherUrl)
                    .AsQueryable();
            }
      
            return await result.ToListAsync();
             
        }
    

        public async Task<List<Advisor>> GetAllAdvisorBranchAsync()
        {
            var result = await
                Context
                .Advisors
                .Where(a => a.IsActive)
                .Include(a => a.Branch)
                .ToListAsync();
                return result;

        }
    }
}
