using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyApp.Entity.Concrete
{
    public class AdvisorCategory
    {
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
