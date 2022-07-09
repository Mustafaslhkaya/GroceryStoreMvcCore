using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MvcFoodProject.DataAccess.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context context = new Context();
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public void Add(T Entity)
        {
            context.Set<T>().Add(Entity);
            context.SaveChanges();
        }
        public void Delete(T Entity)
        {
            context.Set<T>().Remove(Entity);
            context.SaveChanges();
        }
        public void Update(T Entity)
        {
            context.Set<T>().Update(Entity);
            context.SaveChanges();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public List<T> GetInclude(string entity)
        {
            return context.Set<T>().Include(entity).ToList();
        }
    }
}
