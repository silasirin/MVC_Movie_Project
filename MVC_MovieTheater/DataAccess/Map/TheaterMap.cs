using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class TheaterMap:CoreMap<Theater>
    {
        public TheaterMap()
        {
            ToTable("dbo.Theater");
            Property(x => x.TheaterID).IsRequired();
        }
    }
}
