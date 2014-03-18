using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository 
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

        IList<T> GetList();

        T GetEntity(object primaryKey);
    }
}