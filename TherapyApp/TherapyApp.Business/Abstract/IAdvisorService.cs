using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Business.Abstract
{
    public interface IAdvisorService
    {
        #region Generic
        Task<Advisor> GetByIdAsync(int id);
        Task<List<Advisor>> GetAllAsync();
        Task CreateAsync(Advisor advisor);
        void Update(Advisor advisor);
        void Delete(Advisor advisor);

        #endregion

        Task<List<Advisor>> GetAllAdvisorBranchAsync();
        Task<List<Advisor>> GetAllActiveAdvisorsAsync(string categoryUrl= null, string brancherUrl=null);


    }
}
