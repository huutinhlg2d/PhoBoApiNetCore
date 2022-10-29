using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using BussinessObject.PhoBo.Data;
using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected PhoBoContext PhoBoContext { get; set; }
        public RepositoryBase(PhoBoContext phoBoContext)
        {
            PhoBoContext = phoBoContext;
        }
        public virtual IEnumerable<T> FindAll() => PhoBoContext.Set<T>().AsNoTracking();
        public virtual T FindByID(params object[] keys)
        {
            return PhoBoContext.Set<T>().Find(keys);
        }

        public virtual async Task<T> FindByIDAsync(params object[] keys)
        {
            return await PhoBoContext.Set<T>().FindAsync(keys);
        }
        public virtual IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            PhoBoContext.Set<T>().Where(expression).AsNoTracking();
        public virtual void Create(T entity) => PhoBoContext.Set<T>().Add(entity);
        public virtual void Update(T entity) => PhoBoContext.Set<T>().Update(entity);
        public virtual void Delete(T entity) => PhoBoContext.Set<T>().Remove(entity);
    }
}
