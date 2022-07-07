using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Week: EntityRepository
    {
        public int WeekID { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        public List<Theater> Theaters { get; set; }
    }
}
