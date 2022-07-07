using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class MovieAndCategoryMap: CoreMap<MoviesAndCategories>
    {
        
        public MovieAndCategoryMap()
        {
            ToTable("dbo.MovieAndCategory");

            HasKey(x => new
            {
                x.MovieID,
                x.CategoryID
            });
        }
    }
}
