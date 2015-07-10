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
    [Export(typeof(ISalesOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrder FindById(Guid salesOrderId)
        {
            return GetAll().FirstOrDefault(x => x.SalesOrderId == salesOrderId);
        }
    }
}
