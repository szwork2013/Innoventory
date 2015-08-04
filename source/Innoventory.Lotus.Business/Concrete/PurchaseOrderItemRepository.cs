using Innoventory.Lotus.Business.Abstract;
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

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IPurchaseOrderItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PurchaseOrderItemRepository : GenericRepository<PurchaseOrderItem, PurchaseOrderItemViewModel>, IPurchaseOrderItemRepository
    {
        protected PurchaseOrderItem GetDomainEntity(PurchaseOrderItemViewModel viewModel)
        {
            PurchaseOrderItem purchaseorderitem = ObjectMapper.PropertyMap(viewModel, new PurchaseOrderItem());

            return purchaseorderitem;
        }
       
        protected override PurchaseOrderItemViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<PurchaseOrderItem> entitySet = dbContext.PurchaseOrderItemSet;

            PurchaseOrderItem dmPurchaseOrderItem = entitySet.FirstOrDefault(x => x.PurchaseOrderItemId == id);

            PurchaseOrderItemViewModel poiVM = new PurchaseOrderItemViewModel();

            PurchaseOrderItemViewModel purchaseorderitemVM = ObjectMapper.PropertyMap(dmPurchaseOrderItem, poiVM);

            return purchaseorderitemVM;

        }

        protected override List<PurchaseOrderItemViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<PurchaseOrderItem> entitySet = dbContext.PurchaseOrderItemSet;

            List<PurchaseOrderItem> purchaseorderitems = entitySet.OrderBy(x => x.PurchaseOrderId).ToList();

            List<PurchaseOrderItemViewModel> retList = new List<PurchaseOrderItemViewModel>();

            foreach (PurchaseOrderItem purchaseorderitem in purchaseorderitems)
            {
                PurchaseOrderItemViewModel poiVM = new PurchaseOrderItemViewModel();


                retList.Add(ObjectMapper.PropertyMap(purchaseorderitem, poiVM));

            }

            return retList;

        }

       

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<PurchaseOrderItem> entitySet = dbContext.PurchaseOrderItemSet;

            PurchaseOrderItem purchaseorderitem = entitySet.FirstOrDefault(x => x.PurchaseOrderItemId == id);

            if (purchaseorderitem != null)
            {
                entitySet.Remove(purchaseorderitem);
                dbContext.SaveChanges();
            }
            return true;

        }

       

        protected override bool AddEntity(InnoventoryDBContext dbContext, PurchaseOrderItemViewModel viewModel)
        {
            PurchaseOrderItem purchaseorderitem = GetDomainEntity(viewModel);
            dbContext.PurchaseOrderItemSet.Add(purchaseorderitem);

            dbContext.SaveChanges();
            return true;

        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, PurchaseOrderItemViewModel viewModel)
        {
            DbSet<PurchaseOrderItem> entitySet = dbContext.PurchaseOrderItemSet;

            PurchaseOrderItem purchaseorderitem = GetDomainEntity(viewModel);

            entitySet.Attach(purchaseorderitem);

            dbContext.Entry(purchaseorderitem).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<PurchaseOrderItemViewModel> Find(InnoventoryDBContext dbContext, Func<PurchaseOrderItemViewModel, bool> predicate)
        {
            List<PurchaseOrderItemViewModel> purchaseorderitems = (GetEntities(dbContext)).Where(predicate).ToList();

            return purchaseorderitems;
        }
    }
}
