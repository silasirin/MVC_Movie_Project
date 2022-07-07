using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class SaloonMap: CoreMap<Saloon>
    {
        public SaloonMap()
        {
            ToTable("dbo.Saloons");
            Property(x => x.SaloonID).IsRequired();
            Property(x => x.SaloonName).HasMaxLength(25).IsRequired(); //bos gecilemez ve max 255 karakter
        }
    }
}
