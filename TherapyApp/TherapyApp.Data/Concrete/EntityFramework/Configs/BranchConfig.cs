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
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
              new Branch
              {
                  Id = 1,
                  Name = "Aile Danışmanı",
                  Url = "aile-danismani"
              },
                  new Branch
                  {
                      Id = 2,
                      Name = "Klinik Psikolog",
                      Url = "klinik-danismani"
                  },
                  new Branch
                  {
                      Id = 3,
                      Name = "Çocuk ve Ergen Psikoloğu",
                      Url = "cocuk-ve-ergen-psikologu"
                  },
                  new Branch
                  {
                      Id = 4,
                      Name = "Çift Terapisti",
                      Url = "cift-terapisti"
                  },
                  new Branch
                  {
                      Id = 5,
                      Name = "Dil ve Konuşma Terapisti",
                      Url = "dil-ve-konusma-terapisti"
                  },
                  new Branch
                  {
                      Id = 6,
                      Name = "Uzman Nöropsikolog",
                      Url = "uzman-noropsikolog"
                  },
                   new Branch
                   {
                       Id = 7,
                       Name = "Fizyoterapist",
                       Url = "fizyoterapist"
                   },
                    new Branch
                    {
                        Id = 8,
                        Name = "Diyetisyen",
                        Url = "diyetisyen"
                    }

              );
        }
    }
}
