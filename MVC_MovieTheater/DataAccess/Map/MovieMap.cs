using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class MovieMap: CoreMap<Movie>
    {
        public MovieMap()
        {
            ToTable("dbo.Movies");
            Property(x => x.MovieID).IsRequired();
            Property(x => x.MovieName).HasMaxLength(255).IsRequired(); //bos gecilemez ve max 255 karakter
        }
    }
}
