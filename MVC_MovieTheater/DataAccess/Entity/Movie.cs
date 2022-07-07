using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Movie: EntityRepository
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }

        //Mapping (Bir filmin birden fazla kategorisi olur.)
        public List<MoviesAndCategories> MoviesAndCategories { get; set; }
        public List<Theater> Theaters { get; set; }
    }
}
