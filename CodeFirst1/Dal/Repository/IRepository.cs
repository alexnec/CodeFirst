using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public interface IRepository
    {
        void AddEntity<T>(T entity) where T : class;

        void UpdateEntity<T>(T entity) where T : class;

        void DeleteEntity<T>(T entity) where T : class;

        IList<T> GetList<T>() where T : class;

        T GetEntity<T>(object primaryKey) where T : class;
    }
}