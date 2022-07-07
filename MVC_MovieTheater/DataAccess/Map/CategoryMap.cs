using Core.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class CategoryMap: CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.CategoryID).IsRequired();
            Property(x => x.CategoryName).HasMaxLength(255).IsRequired(); //bos gecilemez ve max 255 karakter
        }
    }
}
