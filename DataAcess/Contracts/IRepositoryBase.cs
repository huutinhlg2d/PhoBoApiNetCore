using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T FindByID(params object[] keys);
        Task<T> FindByIDAsync(params object[] keys);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);       
    }
}
