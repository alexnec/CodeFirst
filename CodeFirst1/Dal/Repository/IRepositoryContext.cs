﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst1.Dal.Repository
{
    public interface IRepositoryContext
    {
        DbContext DbContext { get; }

        DbSet<T> GetDbSet<T>() where T: class;

        void SaveChanges();
    }
}
