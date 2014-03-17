using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public class EfRepositoryContext : IRepositoryContext
    {
         private DbContext dbContext;

         public EfRepositoryContext(DbContext db)
         {
             this.dbContext = db;
         }

         public DbContext DbContext
         {
             get { return dbContext; }
         }

         public DbSet<T> GetDbSet<T>() where T : class
         {
             return dbContext.Set<T>(); 
         }

         public void SaveChanges()
         {
             dbContext.SaveChanges(); ;
         }
    }
}