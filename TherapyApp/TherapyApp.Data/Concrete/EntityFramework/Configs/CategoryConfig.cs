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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Adli Psikoloji",
                    Description = "Adli psikoloji, sanıkların soruşturma tekniği, görgü tanıklarının düşebileceği yanılsamaların saptanması, suç işleme yönteminin önceden bilinmesi, suçlu çocukların yeniden eğitim yoluyla toplum yaşamlarına uyumlarının sağlanması gibi konularla ilgilenen psikoloji dalıdır",
                    Url = "adli-psikoloji"

                },
                new Category
                {
                    Id = 2,
                    Name = "Aile Terapisi",
                    Description = "Eş, çocuklar ve yakın akrabaları da kapsayan, aile üyelerini ilgilendiren sorunlara yönelik bir terapi formatıdır. Aile terapisi, ailede sorun ve çatışmaların belirlemesine ve bunların çözülmesine yardımcı olur.",
                    Url = "aile-terapisi"

                },
                 new Category
                 {
                     Id = 3,
                     Name = "Anksiyete (kaygı) Bozuklukları",
                     Description= "Anksiyete bir diğer adıyla kaygı bozukluğu, psikolojik bir rahatsızlıktır.Anksiyete bozukluğu olan kişilerde, yoğun, sürekli devam eden bir endişe hali ve günlük hayatta rastlanılan durumlara karşı korku vardır.Panik atak krizleriyle de kendini gösterebilir",
                     Url = "anksiyete-bozukluklari"

                 },
                 new Category
                 {
                     Id=4,
                     Name = "Bipolar Bozukluk",
                     Description = "İki uçlu duygudurum bozukluğu bir diğer adıyla manik-depresif hastalık, kişinin duygudurumunda, enerjisinde ve sosyal aktiviteleri tamamlama yetisinde bozulmalara neden olan psikolojik hastalıktır.",
                     Url ="bipolar-bozukluk",
                 },
                 new Category
                 {
                     Id = 5,
                     Name= "Boşanma Danışmanlığı",
                     Description= "boşanma sürecinde psikolojik sorunlar yaşamayı en aza indirmek, ortaya çıkması muhtemel olan yas ve ayrılıkla baş etmeyi kolaylaştırmak, bu sürecin çocuklar ve çiftler açısından en az hasarla atlatılmasını kolaylaştırmak için gerçekleştirilen bir hizmettir.",
                     Url = "bosanma-danismanligi"
                 },
                 new Category
                 {
                     Id =6,
                     Name = "Depresyon",
                     Description= "bireylerin kendini psikolojik olarak iyi hissetmediği, çok uzun süreler devam edebilen ve günlük hayatı etkileyen psikolojik bir rahatsızlıktır",
                     Url="depresyon"
                 },
                 new Category
                 {
                     Id = 7,
                     Name = "Uyku Bozuklukları",
                     Description = "Uyku esnasında oluşan sorunlar veya aksiliklerin tamamına uyku bozukluğu denir",
                     Url ="uyku-bozukluklari",
                 },
                 new Category
                 {
                     Id = 8,
                     Name = "Kariyer Danışmanlığı",
                     Description = "danışan birey veya grupla kariyer gelişimi ile ilgili sorunlarda (meslek seçimi, iş arama, vb.) profesyonel bir danışmanın yürütüldüğü ilişki biçimidir",
                     Url ="kariyer-danismanligi",
                 },
                 new Category
                 {
                     Id = 9,
                     Name = "Asperger Sendromu",
                     Description= "Asperger sendromu esasen otistik spektrum bozukluğu yani kısaca OSB adı verilen geniş bir tanı yelpazesinin parçasıdır",
                     Url= "asperger-sendromu"
                 },
                 new Category
                 {
                     Id = 10,
                     Name = "İletişim Problemleri",
                     Description = "ikili iletişim kuran taraflar arasında yapılan bir takım hayatlar sonucunda ortaya çıkar. ",
                     Url = "iletisim-problemleri"
                 },
                 new Category
                 {
                     Id = 11,
                     Name = "Fizyoterapist",
                     Description = "Yaralanma, hastalık, travma ya da yaşlılık gibi nedenlerle eksilme gösteren fonksiyonel hareketleri geri kazandırma amaçlı yapılan; elektrik akımı, sıcak ya da soğuk uygulaması, egzersizler ya da çeşitli uygulamalarla hastaların tedavisine verilen isimdir.",
                     Url = "fizyoterapist"
                 },
                  new Category
                  {
                      Id = 12,
                      Name = "Diyetisyen",
                      Description = "Sağlık kurallarına uygun olarak kullanılmasını sağlayan, besin denetimini yapan, bu konularda fizyolojik, psikolojik ve sosyolojik olarak sağlıklı yaşam biçimlerinin benimsenmesi amacıyla bireyi ve toplumu bilgilendiren, bilinçlendiren kişilerdir.",
                      Url = "diyetisyen"
                  }
                );

        }
    }
}
