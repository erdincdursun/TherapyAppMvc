using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Abstract;

namespace TherapyApp.Entity.Concrete
{
    public class Advisor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public string Education { get; set; }
        public List<AdvisorCategory> AdvisorCategories { get; set; }



    }
}
