using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Saloon: EntityRepository
    {
        public int SaloonID { get; set; }
        public string SaloonName { get; set; }
        public int Capacity { get; set; }

        public List<Theater> Theaters { get; set; }
    }
}
