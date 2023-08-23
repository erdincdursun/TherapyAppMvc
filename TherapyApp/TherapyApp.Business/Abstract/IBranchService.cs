using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Business.Abstract
{
    public interface IBranchService
    {

        Task<Branch> GetByIdAsync(int id);
        Task<List<Branch>> GetAllAsync();
        Task CreateAsync(Branch branch);
        void Update(Branch branch);
        void Delete(Branch branch);

        Task<List<Branch>> GetAllBranchAsync(bool isDeleted, bool? isActive = null);

    }
}
