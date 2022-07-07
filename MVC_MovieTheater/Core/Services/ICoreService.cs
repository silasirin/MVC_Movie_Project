using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICoreService<T> where T : EntityRepository
    {
        //Add
        string Add(T model);

        //Add List
        string Add(List<T> models);

        //Get
        T GetByID(int id);

        //Get List
        List<T> GetList();

        //Delete
        string Delete(int id);

        //Update
        string Update(T model);

        //Any (var mi yok mu sorgula)
        bool Any(Expression<Func<T, bool>> exp);

        //GetDefault (varsayilan degerine gore getir or: status null olanlari getir vs. kriter islemleri)
        List<T> GetDefault(Expression<Func<T, bool>> exp);

        //Remove Force (dogrudan silme islemi, her kullanici yapamayacak)
        string RemoveForce(T model);
    }
}
