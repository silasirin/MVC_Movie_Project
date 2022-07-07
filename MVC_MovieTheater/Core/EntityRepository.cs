using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EntityRepository
    {

        public EntityRepository()
        {
            Status = Status.Active;
            CreatedDate = DateTime.Now;

        }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }


        //todo: Created ve Updated property'leri veritabanin kayit esnasinda doldurulacak. IP yakalama nesnesi olusturulacak. 
    }
}
