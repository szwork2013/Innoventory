using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    [Export(typeof(ISalesReturnItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesReturnItemRepository : GenericRepository<SalesReturnItem>, ISalesReturnItemRepository
    {
        public SalesReturnItem FindById(Guid salesReturnItemId)
        {
            return GetAll().FirstOrDefault(x => x.SalesReturnItemId == salesReturnItemId);
        }
    }
}
