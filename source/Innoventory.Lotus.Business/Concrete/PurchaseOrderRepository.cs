using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(IPurchaseOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder, PurchaseOrderViewModel>, IPurchaseOrderRepository
    {
        protected PurchaseOrder GetDomainEntity(PurchaseOrderViewModel viewModel)
        {
            PurchaseOrder purchaseorder = ObjectMapper.PropertyMap(viewModel, new PurchaseOrder());

            return purchaseorder;
        }

        protected override PurchaseOrderViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<PurchaseOrder> entitySet = dbContext.PurchaseOrderSet;

            PurchaseOrder dmPurchaseOrder = entitySet.FirstOrDefault(x => x.PurchaseOrderId == id);

            PurchaseOrderViewModel poVM = new PurchaseOrderViewModel();

            PurchaseOrderViewModel purchaseorderVM = ObjectMapper.PropertyMap(dmPurchaseOrder, poVM);

            return purchaseorderVM;
        }

        protected override List<PurchaseOrderViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<PurchaseOrder> entitySet = dbContext.PurchaseOrderSet;

            List<PurchaseOrder> purchaseorders = entitySet.OrderBy(x => x.PurchaseOrderId).ToList();

            List<PurchaseOrderViewModel> retList = new List<PurchaseOrderViewModel>();

            foreach (PurchaseOrder purchaseorder in purchaseorders)
            {
                PurchaseOrderViewModel poVM = new PurchaseOrderViewModel();


                retList.Add(ObjectMapper.PropertyMap(purchaseorder, poVM));

            }

            return retList;
        }

      
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<PurchaseOrder> entitySet = dbContext.PurchaseOrderSet;

            //PurchaseOrderViewModel purchaseorderVM = GetEntity(dbContext, id);


            PurchaseOrder purchaseorder = entitySet.FirstOrDefault(x => x.PurchaseOrderId == id);

            if (purchaseorder != null)
            {
                entitySet.Remove(purchaseorder);
                dbContext.SaveChanges();
            }
            return true;
        }

      
        protected override bool AddEntity(InnoventoryDBContext dbContext, PurchaseOrderViewModel viewModel)
        {
            PurchaseOrder purchaseorder = GetDomainEntity(viewModel);
            dbContext.PurchaseOrderSet.Add(purchaseorder);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, PurchaseOrderViewModel viewModel)
        {
            DbSet<PurchaseOrder> entitySet = dbContext.PurchaseOrderSet;

            PurchaseOrder purchaseorder = GetDomainEntity(viewModel);

            entitySet.Attach(purchaseorder);

            dbContext.Entry(purchaseorder).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }

        protected override List<PurchaseOrderViewModel> Find(InnoventoryDBContext dbContext, Func<PurchaseOrderViewModel, bool> predicate)
        {
            List<PurchaseOrderViewModel> purchaseorders = (GetEntities(dbContext)).Where(predicate).ToList();

            return purchaseorders;
        }
    }
}
