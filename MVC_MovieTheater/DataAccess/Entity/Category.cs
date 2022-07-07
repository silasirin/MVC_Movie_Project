using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Category: EntityRepository
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //Mapping (Bir kategoride birden fazla film olur.)
        public List<MoviesAndCategories> MoviesAndCategories { get; set; }
    }
}
