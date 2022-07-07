using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class WeekMap: CoreMap<Week>
    {
        public WeekMap()
        {
            ToTable("dbo.Weeks");
            Property(x => x.WeekID).IsRequired();
            Property(x => x.FirstDay).IsOptional();
            Property(x => x.LastDay).IsOptional();
        }
    }
}
