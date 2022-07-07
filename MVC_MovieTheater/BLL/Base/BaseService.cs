using Core;
using Core.Services;
using DataAccess.Context;
using DataAccess.Tool;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {
        ProjectContext context = DbContextSingleton.Context;

        public ProjectContext GetContext()
        {
            return context;
        }

        public string Add(T model)
        {
            try
            {
                context.Set<T>().Add(model);
                context.SaveChanges();
                return "Veri eklendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Add(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Any(exp);
        }

        public string Delete(int id)
        {
            try
            {
                T deleted = GetByID(id);
                deleted.Status = Core.Enums.Status.Deleted;
                Update(deleted);
                return "Veri silindi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public string RemoveForce(T model)
        {
            try
            {
                context.Set<T>().Remove(model);
                return "Veri kalici olarak silindi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }

        public string Update(T model)
        {
            throw new NotImplementedException();
        }

        //public string Update(int id)
        //{
        //    try
        //    {
        //        T updated = GetByID(model.);
        //        //context.Entry(updated).State = System.Data.Entity.EntityState.Modified;

        //        DbEntityEntry entity = context.Entry(updated);
        //        entity.CurrentValues.SetValues(model);
        //        context.SaveChanges();

        //        return $"{model.ID} nolu veri guncellendi.";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    };
        //}
    }

}
