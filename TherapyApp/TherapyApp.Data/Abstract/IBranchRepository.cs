using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Abstract
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<List<Branch>> GetAllBranchAsync(bool isDeleted, bool? isActive = null);

    }
}
