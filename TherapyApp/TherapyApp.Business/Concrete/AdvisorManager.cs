using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Business.Abstract;
using TherapyApp.Data.Abstract;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Business.Concrete
{
    public class AdvisorManager : IAdvisorService
    {
      private readonly IAdvisorRepository _advisorRepository;

        public AdvisorManager(IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task CreateAsync(Advisor advisor)
        {
            await _advisorRepository.CreateAsync(advisor);
        }

        public void Delete(Advisor advisor)
        {
            _advisorRepository.Delete(advisor);
        }

        public async Task<List<Advisor>> GetAllActiveAdvisorsAsync(string categoryUrl = null, string brancherUrl = null)
        {
            var result = await _advisorRepository.GetAllActiveAdvisorsAsync(categoryUrl, brancherUrl);
            return result;
        }

        public async Task<List<Advisor>> GetAllAdvisorBranchAsync()
        {
            var result = await _advisorRepository.GetAllAdvisorBranchAsync();
            return result;  
        }

        public async Task<List<Advisor>> GetAllAsync()
        {
            var result = await _advisorRepository.GetAllAsync();
            return result;
        }

        public async Task<Advisor> GetByIdAsync(int id)
        {
            var result = await _advisorRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Advisor advisor)
        {
            _advisorRepository.Update(advisor);    
        }
    }
}
