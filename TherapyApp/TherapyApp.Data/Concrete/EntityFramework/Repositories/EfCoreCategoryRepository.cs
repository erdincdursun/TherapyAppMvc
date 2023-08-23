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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(TherapyAppContext _dbContext) : base(_dbContext)
        {
        }
        private TherapyAppContext Context
        {
            get { return _dbContext as TherapyAppContext; }
        }

        public async Task<List<Category>> GetAllCategoryAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
                .Categories
                .Where(c => c.IsDeleted == isDeleted)
                .AsQueryable();
            if (isActive != null)
            {
                result = result .Where(c=> c.IsActive == isActive) .AsQueryable();
            }
            return await result.ToListAsync();
        }

    }
}


