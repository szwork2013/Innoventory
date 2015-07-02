﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Abstract
{
    public interface IGenericRepository
    {

    }
    public interface IGenericRepository<T> : IGenericRepository, IDisposable where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        string Save();
    }
}
