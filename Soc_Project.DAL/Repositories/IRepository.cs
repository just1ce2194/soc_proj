using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);

        T FirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        T Get(object id);

        void Add(T entity);

        void Delete(T entityToDelete);

        void Delete(object id);

        void Update(T entityToUpdate);

    }
}
