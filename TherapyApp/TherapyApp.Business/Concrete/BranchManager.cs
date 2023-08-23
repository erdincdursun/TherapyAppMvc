using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Business.Abstract;
using TherapyApp.Data.Abstract;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task CreateAsync(Branch branch)
        {
           await _branchRepository.CreateAsync(branch);
        }

        public void Delete(Branch branch)
        {
            _branchRepository.Delete(branch);
        }

        public async Task<List<Branch>> GetAllAsync()
        {
           var result = await _branchRepository.GetAllAsync();
            return result;
        }

        public async Task<List<Branch>> GetAllBranchAsync(bool isDeleted, bool? isActive = null)
        {
            var result = await _branchRepository.GetAllBranchAsync(isDeleted, isActive);    
            return result;
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            var result = await _branchRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Branch branch)
        {
            _branchRepository.Update(branch);
        }
    }
}
