using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class MoviesAndCategories: EntityRepository
    {
        public int MovieID { get; set; }
        public int CategoryID { get; set; }

        //Mapping
        public Category Category { get; set; }
        public Movie Movie { get; set; }
    }
}
