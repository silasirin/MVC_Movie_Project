namespace DataAccess.Migrations
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(DataAccess.Context.ProjectContext context)
        {

            //Categories
            List<Category> categories = new List<Category>()
            {
                new Category{CategoryID = 1,CategoryName="Animasyon"},
                new Category{CategoryID = 2,CategoryName="Fantastik"},
                new Category{CategoryID = 3,CategoryName="Aksiyon"},
                new Category{CategoryID = 4,CategoryName="Anime"}
                
            };
           
            if (!context.Categories.Any()) //herhangi bir kategori yoksa
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            
            //Movie
            List<Movie> movies = new List<Movie>()
            {
              
                new Movie{
                    MovieID = 1,
                    MovieName="Doctor Strange 2",
                    Description="Marvel Studios'tan 'Doktor Strange Çoklu Evren Çılgınlığında' filmi ile Marvel Sinematik Evreni, Çoklu Evrenin kapılarını açıyor ve sınırları her zamankinden daha ileri zorluyor. Hem eski hem de yeni mistik yol arkadaşlarının yardımıyla, gizemli yeni bir düşmanla yüzleşmek için Çoklu Evrenin akıllara durgunluk veren ve tehlikeli alternatif gerçekliklerini kat eden Doktor Strange ile bilinmeyene yolculuk başlıyor.",
                    Duration=126,
                    UnitPrice =35,
                    ImagePath ="~/Content/img/drStrange.jpg"
                },
                new Movie{
                    MovieID = 2,
                    MovieName="Ejderham ve Ben",
                    Description="Cornelia Funke’nin dünyaca ünlü romanından sinemaya uyarlanan Ejderham Ve Ben, genç gümüş ejderha Ateş Drake ile Ben adlı bir çocuğundostluğunu konu alıyor. Diğer ejderhaların rahat yaşayabileceğivekimsenin bulamayacağı Cennet Vadisi’ne ulaşmak için Himalayalar’da dostlarıyla muhteşem bir serüvene çıkıyorlar!",
                    Duration=91,
                    UnitPrice =30,
                    ImagePath ="/Content/img/ejderham.jpg"
                },
                new Movie{
                    MovieID = 3,
                    MovieName="Top Gun: Maverick",
                    Description=" 1986 yapımı Top Gun'ın devam hikâyesi olan Top Gun: Maverick, usta pilot Maverick'in bu kez eğitmen olarak hava kuvvetlerine geri dönüşü sonrası gelişen olayları anlatıyor. Donanmanın en iyi pilotlarından biri olan Pete “Maverick” Mitchell, 30 yıllık hizmetten sonra ait olduğu yerde, cesur bir test pilotu olarak sınırları zorlar ve kendisini yere bağlayacak olan terfiden kaçar. Kendisini Top Gun mezunlarından oluşan bir müfrezeyi o güne kadar hiçbir pilotun görmediği özel bir görev için eğitirken bulur. Belirsiz bir gelecekle ve geçmişinden gelen anılarla karşı karşıya kalan Maverick, en büyük korkularıyla yüzleşmek ve büyük bir fedakarlık yapmasını gerektiren bir göreve gitmek zorunda kalır.",
                    Duration=131,
                    UnitPrice =35,
                    ImagePath ="/Content/img/topGun.jpg"
                },
                new Movie{
                    MovieID = 4,
                    MovieName="Jujutsu Kaisen 0: The Movie",
                    Description="Yuta Okkotsu, son derece güçlü bir Lanetli Ruh'un kontrolünü ele geçiren ve gücünü kontrol etmesine ve ona göz kulak olmasına yardımcı olmak için Jujutsu Büyücüleri tarafından Tokyo Prefectural Jujutsu Lisesi'ne kaydolan bir lise öğrencisidir.",
                    Duration=105,
                    UnitPrice =35,
                    ImagePath ="/Content/img/jujutsu.jpg"
                }

            };

            if (!context.Movies.Any())
            {
                foreach (var movie in movies)
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
            }

            //Saloon
            List<Saloon> saloons = new List<Saloon>()
            {
                new Saloon { SaloonID = 1, SaloonName="A", Capacity=150 },
                new Saloon { SaloonID = 2, SaloonName="B", Capacity=80 },
                new Saloon { SaloonID = 3, SaloonName="C", Capacity=110 },
                new Saloon { SaloonID = 4, SaloonName="D", Capacity=70 },
            };

            if (!context.Saloons.Any())
            {
                foreach (var saloon in saloons)
                {
                    context.Saloons.Add(saloon);
                    context.SaveChanges();
                }
            }

            //var gun=new DateTime()
            //week of month, day of week seklindeki property'ler kullanilabilir.
            //session icin time veya timespan
            
            //Session
            List<Session> sessions = new List<Session>()
            {
                new Session {SessionID = 1, SessionTime=DateTime.Now}, //TODO datetime sor
                new Session {SessionID = 2, SessionTime= DateTime.Now},
                new Session {SessionID = 3, SessionTime= DateTime.Now},
                new Session {SessionID = 4, SessionTime= DateTime.Now},

            };

            if (!context.Sessions.Any())
            {
                foreach (var session in sessions)
                {
                    context.Sessions.Add(session);
                    context.SaveChanges();
                }
            }

            //Weeks
            List<Week> weeks = new List<Week>()
            {
                new Week {WeekID = 1,FirstDay=DateTime.Now,LastDay=DateTime.Now},
                new Week {WeekID = 2,FirstDay=DateTime.Now,LastDay=DateTime.Now}, 
                new Week {WeekID = 3,FirstDay=DateTime.Now,LastDay=DateTime.Now},
                new Week {WeekID = 4,FirstDay=DateTime.Now,LastDay=DateTime.Now}
            };

            if (!context.Weeks.Any())
            {
                foreach (var week in weeks)
                {
                    context.Weeks.Add(week);
                    context.SaveChanges();
                }
            }

            //MoviesAndCategories
            List<MoviesAndCategories> moviesAndCategories = new List<MoviesAndCategories>()
            {
                new MoviesAndCategories {MovieID=1,CategoryID=2},
                new MoviesAndCategories {MovieID=2,CategoryID=1},
                new MoviesAndCategories {MovieID=3,CategoryID=3},
                new MoviesAndCategories {MovieID=4,CategoryID=4},
            };

            if (!context.MoviesAndCategories.Any())
            {
                foreach (var moviesCategories in moviesAndCategories)
                {
                    context.MoviesAndCategories.Add(moviesCategories);
                    context.SaveChanges();
                }
            }

            //todo theater eklenecek?
            List<Theater> theaters = new List<Theater>()
            {
                new Theater {TheaterID=1,MovieID=1,SaloonID=1,WeekID=1,SessionID=1},
                new Theater {TheaterID=2,MovieID=2,SaloonID=2,WeekID=2,SessionID=2},
                new Theater {TheaterID=3,MovieID=3,SaloonID=3,WeekID=3,SessionID=3},
                new Theater {TheaterID=4,MovieID=4,SaloonID=4,WeekID=4,SessionID=4}
            };

            if (!context.Theaters.Any())
            {
                foreach (var theater in theaters)
                {
                    context.Theaters.Add(theater);
                    context.SaveChanges();
                }
            }
        }
    }
    
}
