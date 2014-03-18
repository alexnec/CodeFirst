using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            //_dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IList<T> GetList()
        {
            return _dbContext.Set<T>().ToList();
        }
        
        public T GetEntity(object primaryKey)
        {
            return _dbContext.Set<T>().Find(primaryKey);
        }
    }
}
