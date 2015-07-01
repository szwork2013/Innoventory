using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Transactions;
using Innoventory.Lotus.Domain.DataEntities;
using System.Linq.Expressions;


namespace Innoventory.Lotus.DataAccess.Abstract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected InnoventoryDBContext _context;
        private IDbTransaction transaction;
        protected DbSet<T> dbSet;

        private Transaction trans;

        // Track whether Dispose has been called.
        private bool disposed = false;

        public GenericRepository()
        {
            _context = new InnoventoryDBContext();

            dbSet = _context.Set<T>();
        }


        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet.AsQueryable<T>();
            return query;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet.Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {

            dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual string Save()
        {
            StringBuilder message = new StringBuilder();
            try
            {
                _context.SaveChanges();
                message.Append("Data saved successfully!");
            }
            catch (System.Data.DataException de)
            {
                throw (de);
            }
            return message.ToString();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose contex.
                    _context.Dispose();

                    _context = null;
                }
                disposed = true;
            }
        }

        ~GenericRepository()
        {
            Dispose(false);
        }

    }
}
