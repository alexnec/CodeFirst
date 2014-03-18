using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
         private DbContext _dbContext;

         public EfUnitOfWork(DbContext db)
         {
             this._dbContext = db;
         }

         public void SaveChanges()
         {
             _dbContext.SaveChanges(); ;
         }

         public IRepository<T> GetRepository<T>() where T : class
         {
             return new EfRepository<T>(_dbContext);
         }
    }
}