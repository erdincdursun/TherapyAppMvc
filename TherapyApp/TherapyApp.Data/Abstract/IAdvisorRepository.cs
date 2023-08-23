using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Abstract
{
    public interface IAdvisorRepository : IGenericRepository<Advisor>
    {
        Task<List<Advisor>> GetAllAdvisorBranchAsync();
        Task<List<Advisor>> GetAllActiveAdvisorsAsync(string categoryUrl = null, string brancherUrl = null);

    }
}
