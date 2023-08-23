using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyApp.Entity.Concrete;

namespace TherapyApp.Data.Concrete.EntityFramework.Configs
{
    public class AdvisorCategoryConfig : IEntityTypeConfiguration<AdvisorCategory>
    {
        public void Configure(EntityTypeBuilder<AdvisorCategory> builder)
        {
            builder.HasKey(ac => new { ac.AdvisorId, ac.CategoryId });
            builder.HasData(
                new AdvisorCategory { AdvisorId = 1, CategoryId = 2 },
                new AdvisorCategory { AdvisorId = 1, CategoryId = 5 },
                new AdvisorCategory { AdvisorId = 1, CategoryId = 6 },
                new AdvisorCategory { AdvisorId = 1, CategoryId = 10 },


                new AdvisorCategory { AdvisorId = 2, CategoryId = 1 },
                new AdvisorCategory { AdvisorId = 2, CategoryId = 3 },
                new AdvisorCategory { AdvisorId = 2, CategoryId = 4 },
                new AdvisorCategory { AdvisorId = 2, CategoryId = 6 },
                new AdvisorCategory { AdvisorId = 2, CategoryId = 9 },

                new AdvisorCategory { AdvisorId = 3, CategoryId = 7 },
                new AdvisorCategory { AdvisorId = 3, CategoryId = 10 },


                new AdvisorCategory { AdvisorId = 4, CategoryId = 2 },
                new AdvisorCategory { AdvisorId = 4, CategoryId = 5 },
                new AdvisorCategory { AdvisorId = 4, CategoryId = 10 },


                new AdvisorCategory { AdvisorId = 5, CategoryId = 10 },
                new AdvisorCategory { AdvisorId = 5, CategoryId = 8 },


                new AdvisorCategory { AdvisorId = 6, CategoryId = 1 },
                new AdvisorCategory { AdvisorId = 6, CategoryId = 3 },
                new AdvisorCategory { AdvisorId = 6, CategoryId = 4 },
                new AdvisorCategory { AdvisorId = 6, CategoryId = 9 },


                new AdvisorCategory { AdvisorId = 7, CategoryId = 7 },
                new AdvisorCategory { AdvisorId = 7, CategoryId = 10 },


                new AdvisorCategory { AdvisorId = 8, CategoryId = 11 },


                new AdvisorCategory { AdvisorId = 9, CategoryId = 12 },


                new AdvisorCategory { AdvisorId = 10, CategoryId = 1 },
                new AdvisorCategory { AdvisorId = 10, CategoryId = 3 },
                new AdvisorCategory { AdvisorId = 10, CategoryId = 4 },
                new AdvisorCategory { AdvisorId = 10, CategoryId = 9 },

                new AdvisorCategory { AdvisorId = 11, CategoryId = 2 },
                new AdvisorCategory { AdvisorId = 11, CategoryId = 5 },
                new AdvisorCategory { AdvisorId = 11, CategoryId = 6 },
                new AdvisorCategory { AdvisorId = 11, CategoryId = 10 },

                new AdvisorCategory { AdvisorId = 12, CategoryId = 12 }


                );
        }
    }
}
