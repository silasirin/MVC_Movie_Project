using DataAccess.Entity;
using DataAccess.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=localhost\\SQLEXPRESS;database=MovieTheaterDB;Trusted_Connection=true";
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MoviesAndCategories> MoviesAndCategories { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Theater> Theaters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new MovieAndCategoryMap());
            modelBuilder.Configurations.Add(new CategoryMap()); //class'taki constructor'in calismasi icin new yazarak instance aldik.
            modelBuilder.Configurations.Add(new MovieMap());
            modelBuilder.Configurations.Add(new WeekMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new SaloonMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
