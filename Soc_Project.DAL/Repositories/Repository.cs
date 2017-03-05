using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return query;
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return filter == null ? query.FirstOrDefault() : query.FirstOrDefault(filter);
        }

        public virtual T Get(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            var entry = context.Entry(entityToUpdate);
            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(entityToUpdate);
            }

            entry.State = EntityState.Modified;
        }
    }
}
