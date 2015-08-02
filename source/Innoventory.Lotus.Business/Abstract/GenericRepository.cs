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
using Innoventory.Lotus.Core.Common;


namespace Innoventory.Lotus.Business.Abstract
{
    public abstract class GenericRepository<DbEntity, VM> : IGenericRepository<VM>
        where DbEntity : class, new()
        where VM : class, IIdentifiable, new()
    {
       
      
        #region Abstract Methods
        protected abstract VM GetEntity(InnoventoryDBContext dbContext, Guid id);

        protected abstract List<VM> GetEntities(InnoventoryDBContext dbContext);

        protected abstract List<VM> Find(InnoventoryDBContext dbContext, Func<VM, bool> predicate);

        protected abstract bool DeleteEntity(InnoventoryDBContext dbContext, Guid id);


        //protected abstract DbEntity GetDomainEntity(VM viewModel);

        protected abstract bool AddEntity(InnoventoryDBContext dbContext, VM viewModel);


        protected abstract bool EditEntity(InnoventoryDBContext dbContext, VM viewModel);
        #endregion


        #region Generic Interface Implementation
        public virtual FindResult<VM> GetAll()
        {
            FindResult<VM> result = new FindResult<VM>();

            try
            {
                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {

                    List<VM> entityList = GetEntities(dbContext);
                    result.Entities = entityList;
                    result.Success = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual FindResult<VM> GetAll(InnoventoryDBContext dbContext)
        {
            FindResult<VM> result = new FindResult<VM>();

            try
            {
                List<VM> entityList = GetEntities(dbContext);
                result.Entities = entityList;
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
                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {

                    VM entity = GetEntity(dbContext, id);


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
            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }

            return result;
        }

        public virtual GetEntityResult<VM> FindById(InnoventoryDBContext dbContext, Guid id)
        {
            GetEntityResult<VM> result = new GetEntityResult<VM>();

            try
            {
                VM entity = GetEntity(dbContext, id);

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

        public virtual FindResult<VM> FindBy(Func<VM, bool> predicate)
        {
            FindResult<VM> result = new FindResult<VM>() { Success = false };

            try
            {
                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {

                    result.Entities = Find(dbContext, predicate);
                    result.Success = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public virtual FindResult<VM> FindBy(InnoventoryDBContext dbContext, Func<VM, bool> predicate)
        {
            FindResult<VM> result = new FindResult<VM>() { Success = false };

            try
            {

                result.Entities = Find(dbContext, predicate);
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
                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {

                    if (viewModel.EntityId == Guid.Empty)
                    {

                        viewModel.EntityId = Guid.NewGuid();

                        result.Success = AddEntity(dbContext, viewModel);

                    }
                    else
                    {
                        result.Success = EditEntity(dbContext, viewModel);
                    }

                    result.Entity = viewModel;
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = string.Format("An error {0} occurred while saving changes to database",
                                   ex.Message);
                throw ex;
            }

            return result;
        }

        public virtual UpdateResult<VM> Update(InnoventoryDBContext dbContext, VM viewModel)
        {

            UpdateResult<VM> result = new UpdateResult<VM>();

            try
            {
                if (viewModel.EntityId == Guid.Empty)
                {

                    viewModel.EntityId = Guid.NewGuid();

                    result.Success = AddEntity(dbContext, viewModel);

                }
                else
                {
                    result.Success = EditEntity(dbContext, viewModel);
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

        public virtual EntityOperationResultBase Delete(Guid id)
        {
            EntityOperationResultBase result = new EntityOperationResultBase() { Success = false };
            try
            {
                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {

                    result.Success = DeleteEntity(dbContext, id);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual EntityOperationResultBase Delete(InnoventoryDBContext dbContext, Guid id)
        {
            EntityOperationResultBase result = new EntityOperationResultBase() { Success = false };
            try
            {

                result.Success = DeleteEntity(dbContext, id);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion


    }
}
