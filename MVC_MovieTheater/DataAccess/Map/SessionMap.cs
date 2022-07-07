using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class SessionMap: CoreMap<Session>
    {
        public SessionMap()
        {
            ToTable("dbo.Sessions");
            Property(x => x.SessionID).IsRequired();
            Property(x => x.SessionTime).IsRequired(); //bos gecilemez ve max 255 karakter
        }
    }
}
