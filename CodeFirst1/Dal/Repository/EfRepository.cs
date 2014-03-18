using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public class EfRepository : IRepository
    {
        private IUnitOfWork repositoryContext;

        public EfRepository(IUnitOfWork repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public void AddEntity<T>(T entity) where T : class
        {
            repositoryContext.GetDbSet<T>().Add(entity);
        }

        public void UpdateEntity<T>(T entity) where T : class
        {
            //repositoryContext.GetDbSet<T>().Attach(entity);
            repositoryContext.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            repositoryContext.GetDbSet<T>().Remove(entity);
        }

        public IList<T> GetList<T>() where T : class
        {
            return repositoryContext.GetDbSet<T>().ToList();
        }
        
        public T GetEntity<T>(object primaryKey) where T : class
        {
            return repositoryContext.GetDbSet<T>().Find(primaryKey);
        }
    }
}
