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
    [Export(typeof(ISalesOrderItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesOrderItemRepository : GenericRepository<SalesOrderItem>, ISalesOrderItemRepository
    {
        public SalesOrderItem FindById(Guid salesOrderItemId)
        {
            return GetAll().FirstOrDefault(x => x.SalesOrderItemId == salesOrderItemId);
        }
    }
}
