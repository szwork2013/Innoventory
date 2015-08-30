using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Abstract
{
    public interface IGenericRepository
    {

    }
    public interface IGenericRepository<T> : IGenericRepository
        where T : class, IIdentifiable, new()
    {
        FindResult<T> GetAll();

        FindResult<T> GetAll(InnoventoryDBContext dbContext);

        FindResult<T> FindBy(Func<T, bool> predicate);


        FindResult<T> FindBy(InnoventoryDBContext dbContext, Func<T, bool> predicate);

        GetEntityResult<T> FindById(Guid id);

        GetEntityResult<T> FindById(InnoventoryDBContext dbContext, Guid id);

        UpdateResult<T> Update(T viewModel);

        UpdateResult<T> Update(InnoventoryDBContext dbContext, T viewModel);

        EntityOperationResultBase Delete(Guid id);

        EntityOperationResultBase Delete(InnoventoryDBContext dbContext, Guid id);


                
    }
}
