using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Theater: EntityRepository
    {
        public int TheaterID { get; set; }
        public int MovieID { get; set; }
        public int WeekID { get; set; }
        public int SessionID { get; set; }
        public int SaloonID { get; set; }

        public Movie Movie { get; set; }
        public Week Week { get; set; }
        public Session Session { get; set; }
        public Saloon Saloon { get; set; }
    }
}
