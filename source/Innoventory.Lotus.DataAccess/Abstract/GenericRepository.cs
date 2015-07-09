using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Transactions;
using Innoventory.Lotus.Database.DataEntities;
using System.Linq.Expressions;
using System.Collections.Generic;
using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.ViewModels;


namespace Innoventory.Lotus.Business.Abstract
{
    public abstract class GenericRepository<DbEntity, VM> : IGenericRepository<VM>
        where DbEntity : class, new()
        where VM : class, IIdentifiable, new()
    {
        private InnoventoryDBContext _context;
        private DbSet<DbEntity> entitySet;

        // Track whether Dispose has been called.
        private bool disposed = false;

        protected InnoventoryDBContext DbContext
        {
            get
            {
                return _context;
            }

        }

        protected DbContextTransaction transaction;

        protected abstract VM GetEntity(Guid id);

        protected abstract IList<VM> GetEntities();

        protected abstract IList<VM> Find(Expression<Func<DbEntity, bool>> predicate);

        protected abstract void DeleteEntity(Guid id);


        protected abstract DbEntity GetDomainEntity(VM viewModel);

        protected abstract bool AddEntity(VM viewModel);


        protected abstract bool EditEntity(VM viewModel);


        public GenericRepository()
        {
            _context = new InnoventoryDBContext();

            entitySet = DbContext.Set<DbEntity>();
        }


        public virtual FindResult<VM> GetAll()
        {
            FindResult<VM> result = new FindResult<VM>();

            try
            {
                IList<VM> entityList = GetEntities();
                result.Entities = new List<VM>();
                result.Success = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual GetEntityResult<VM> FindById(Guid id)
        {
            GetEntityResult<VM> result = new GetEntityResult<VM>();

            try
            {
                VM entity = GetEntity(id);

                if (entity != null)
                {
                    result.Entity = entity;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = "Record does not exist";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }

            return result;
        }

        public virtual FindResult<VM> FindBy(Expression<Func<DbEntity, bool>> predicate)
        {
            FindResult<VM> result = new FindResult<VM>() { Success = false };

            try
            {

                result.Entities = Find(predicate);
                result.Success = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }



        public virtual UpdateResult<VM> Update(VM viewModel)
        {

            UpdateResult<VM> result = new UpdateResult<VM>();

            try
            {
                if (viewModel.EntityId == Guid.Empty)
                {

                    viewModel.EntityId = new Guid();

                    result.Success = AddEntity(viewModel);

                }
                else
                {
                    result.Success = EditEntity(viewModel);
                }

                result.Entity = viewModel;
            }
            catch (Exception ex)
            {
                string ErrorMessage = string.Format("An error {0} occurred while saving changes to database",
                                   ex.Message);
                throw ex;
            }

            return result;
        }

        public virtual bool Delete(VM viewModel)
        {
            bool success = false;
            try
            {

                DbEntity existingEntity = GetDomainEntity(viewModel);

                entitySet.Remove(existingEntity);

                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
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
                    // Dispose context.
                    DbContext.Dispose();

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
