using MercurTech.DataAccessLayer.Abstract;
using MercurTech.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new Context();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var ctx = new Context();
            return ctx.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var ctx = new Context();
            return ctx.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var ctx = new Context();
            ctx.Set<T>().Add(t);
            ctx.SaveChanges();
        }

        public void Update(T t)
        {
            using var ctx = new Context();
            ctx.Set<T>().Update(t);
            ctx.SaveChanges();
        }
    }
}
