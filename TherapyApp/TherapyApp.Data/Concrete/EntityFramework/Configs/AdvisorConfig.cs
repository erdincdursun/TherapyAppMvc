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
    public class AdvisorConfig : IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasData(
            new Advisor
            {
                Id = 1,
                FirstName = "Erdinç",
                LastName = "Dursun",
                About = "Erdinç Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 1,
                Education = "Gazi Üniversitesi Rehberlik ve Psikolojik",
                Price = 500,
                PhotoUrl = "erdinc-dursun.jpg",
                Url = "erdinc-dursun-1"

            },
            new Advisor
            {
                Id = 2,
                FirstName = "Büşra",
                LastName = "Dursun",
                About = "Büşra Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 2,
                Education = "Beykent Üniversitesi Rehberlik ve Psikolojik",
                Price = 950,
                PhotoUrl = "busra-dursun.jpg",
                Url = "busra-dursun-2"

            },
            new Advisor
            {
                Id = 3,
                FirstName = "Ayşe Hafsa",
                LastName = "Doğan",
                About = "Ayse Hafsa Doğan, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 3,
                Education = "İstanbul Üniversitesi Rehberlik ve Psikolojik",
                Price = 350,
                PhotoUrl = "ayse-hafsa-dogan.jpg",
                Url = "ayse-hafsa-dogan-3"

            },
            new Advisor
            {
                Id = 4,
                FirstName = "Ömer Ayaz",
                LastName = "Dursun",
                About = "Ömer Ayaz Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 4,
                Education = "Marmara Üniversitesi Rehberlik ve Psikolojik",
                Price = 900,
                PhotoUrl = "omer-ayaz-dursun.jpg",
                Url = "omer-ayaz-dursun-4"

            },
            new Advisor
            {
                Id = 5,
                FirstName = "Zeynep Serra",
                LastName = "Dogan",
                About = "Ömer Ayaz Dursun, lisans eğitimini 2021 yılında Gazi Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 5,
                Education = "Gazi Üniversitesi Rehberlik ve Psikolojik",
                Price = 700,
                PhotoUrl = "zeynep-serra-dogan.jpg",
                Url = "zeynep-serra-dogan-5"

            },
            new Advisor
            {
                Id = 6,
                FirstName = "Nazlı",
                LastName = "Öztürk",
                About = "Nazlı Öztürk, lisans eğitimini 2021 yılında Adnan Menderes Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                BranchId = 6,
                Education = "Adnan Menderes Üniversitesi Rehberlik ve Psikolojik",
                Price = 700,
                PhotoUrl = "nazli-ozturk.jpg",
                Url = "nazli-ozturk-6"

             },
             new Advisor
             {
                 Id = 7,
                 FirstName = "Erdi",
                 LastName = "Dursun",
                 About = "Erdi Dursun, lisans eğitimini 2021 yılında İstanbul Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                 BranchId = 3,
                 Education = "İstanbul Üniversitesi Rehberlik ve Psikolojik",
                 Price = 650,
                 PhotoUrl = "erdi-dursun.jpg",
                 Url = "erdi-dursun-7"

             },
              new Advisor
              {
                  Id = 8,
                  FirstName = "Ahmet Tuğra",
                  LastName = "Özübek",
                  About = "Özübek, lisans eğitimini 2021 yılında Arel Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                  BranchId = 7,
                  Education = "Arel Üniversitesi Rehberlik ve Psikolojik",
                  Price = 100,
                  PhotoUrl = "ahmet-tugra-ozubek.jpg",
                  Url = "ahmet-tugra-ozubek-8"

              },
               new Advisor
               {
                   Id = 9,
                   FirstName = "Arzu",
                   LastName = "Öztürk",
                   About = "Arzu Öztürk, lisans eğitimini 2021 yılında Vakfıkebir Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                   BranchId = 8,
                   Education = "Vakfıkebir Üniversitesi Rehberlik ve Psikolojik",
                   Price = 700,
                   PhotoUrl = "arzu-ozturk.jpg",
                   Url = "arzu-ozturk-9"

               },
                new Advisor
                {
                    Id = 10,
                    FirstName = "Şeyda Nur",
                    LastName = "Doğan",
                    About = "Şeyda Nur Doğan, lisans eğitimini 2021 yılında Anadolu Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                    BranchId = 6,
                    Education = "Anadolu Üniversitesi Rehberlik ve Psikolojik",
                    Price = 320,
                    PhotoUrl = "seyda-nur-dogan.jpg",
                    Url = "seyda-nur-dogan-10"

                },
                 new Advisor
                 {
                     Id = 11,
                     FirstName = "Abdul",
                     LastName = "Öztürk",
                     About = "Abdul Öztürk, lisans eğitimini 2021 yılında Vakfıkebir Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                     BranchId = 1,
                     Education = "Vakfıbekir Üniversitesi Rehberlik ve Psikolojik",
                     Price = 190,
                     PhotoUrl = "abdul-ozturk.jpg",
                     Url = "abdul-ozturk-11"

                 },
                  new Advisor
                  {
                      Id = 12,
                      FirstName = "Habibe",
                      LastName = "Dursun",
                      About = "Habibe Dursun, lisans eğitimini 2021 yılında Sivas Üniversitesi Rehberlik ve Psikolojik Danışmanlık alanında “Temel Psikolojik İhtiyaçlar ile İnternet Bağımlılığı ve Diğer Kişisel Faktörler Arasındaki İlişki” konulu bitirme tezi ile tamamlamıştır. ",
                      BranchId = 8,
                      Education = "Sivas Üniversitesi Rehberlik ve Psikolojik",
                      Price = 290,
                      PhotoUrl = "habibe-dursun.jpg",
                      Url = "habibe-dursun-12"

                  });
        }
    }
}
