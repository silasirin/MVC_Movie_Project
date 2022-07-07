using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class AppUserMap: CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUser");
            HasKey(x => x.UserID);
            Property(x => x.UserID).IsRequired();
            Property(x => x.UserName).HasMaxLength(255).IsRequired(); //bos gecilemez ve max 255 karakter
        }
    }
}
