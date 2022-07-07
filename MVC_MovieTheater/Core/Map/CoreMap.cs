using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : EntityRepository
    {
        public CoreMap()
        {
        }
    }
}
