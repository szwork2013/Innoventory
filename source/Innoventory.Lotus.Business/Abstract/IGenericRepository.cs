using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Abstract
{
    public interface IGenericRepository
    {

    }
    public interface IGenericRepository<T> : IGenericRepository, IDisposable
        where T : class, IIdentifiable, new()
    {
        FindResult<T> GetAll();

        FindResult<T> FindBy(Expression<Func<T, bool>> predicate);

        GetEntityResult<T> FindById(Guid id);

        UpdateResult<T> Update(T viewModel);

        EntityOperationResultBase Delete(Guid id);
                
    }
}
