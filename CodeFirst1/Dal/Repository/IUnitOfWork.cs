using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T: class;
        void SaveChanges();
    }
}
