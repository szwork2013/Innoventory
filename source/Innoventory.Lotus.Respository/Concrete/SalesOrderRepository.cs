using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Common;
using System.Data.Entity;

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ISalesOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesOrderRepository : GenericRepository<SalesOrder, SalesOrderViewModel>, ISalesOrderRepository
    {

        protected SalesOrder GetDomainEntity(SalesOrderViewModel viewModel)
        {
            SalesOrder salesOrder = ObjectMapper.PropertyMap(viewModel, new SalesOrder());

            return salesOrder;
        }
      
        protected override SalesOrderViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SalesOrder> entitySet = dbContext.SalesOrderSet;

            SalesOrder dmSalesOrder = entitySet.FirstOrDefault(x => x.SalesOrderId == id);

            SalesOrderViewModel poVM = new SalesOrderViewModel();

            SalesOrderViewModel salesOrderVM = ObjectMapper.PropertyMap(dmSalesOrder, poVM);

            return salesOrderVM;
        }

        protected override List<SalesOrderViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<SalesOrder> entitySet = dbContext.SalesOrderSet;

            List<SalesOrder> salesOrders = entitySet.OrderBy(x => x.SalesOrderId).ToList();

            List<SalesOrderViewModel> retList = new List<SalesOrderViewModel>();

            foreach (SalesOrder salesOrder in salesOrders)
            {
                SalesOrderViewModel poVM = new SalesOrderViewModel();


                retList.Add(ObjectMapper.PropertyMap(salesOrder, poVM));

            }

            return retList;
        }

       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SalesOrder> entitySet = dbContext.SalesOrderSet;

            //SalesOrderViewModel salesOrderVM = GetEntity(dbContext, id);


            SalesOrder salesOrder = entitySet.FirstOrDefault(x => x.SalesOrderId == id);

            if (salesOrder != null)
            {
                entitySet.Remove(salesOrder);
                dbContext.SaveChanges();
            }
            return true;
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, SalesOrderViewModel viewModel)
        {
            SalesOrder salesOrder = GetDomainEntity(viewModel);
            dbContext.SalesOrderSet.Add(salesOrder);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SalesOrderViewModel viewModel)
        {
            DbSet<SalesOrder> entitySet = dbContext.SalesOrderSet;

            SalesOrder salesOrder = GetDomainEntity(viewModel);

            entitySet.Attach(salesOrder);

            dbContext.Entry(salesOrder).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<SalesOrderViewModel> Find(InnoventoryDBContext dbContext, Func<SalesOrderViewModel, bool> predicate)
        {
            List<SalesOrderViewModel> salesOrders = (GetEntities(dbContext)).Where(predicate).ToList();

            return salesOrders;
        }
    }
}
