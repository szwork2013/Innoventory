using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
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
