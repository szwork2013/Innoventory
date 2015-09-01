using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Core.Common;

using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.Composition;


namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ISupplierRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SupplierRepository : GenericRepository<Supplier, SupplierViewModel>, ISupplierRepository
    {


        protected override SupplierViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Supplier> entitySet = dbContext.SupplierSet;

            Supplier dmSupplier = entitySet.FirstOrDefault(x => x.SupplierId == id);

            SupplierViewModel custVM = new SupplierViewModel();

            SupplierViewModel supplierVM = ObjectMapper.PropertyMap(dmSupplier, custVM);

            return supplierVM;
        }

        protected override List<SupplierViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Supplier> entitySet = dbContext.SupplierSet;

            List<Supplier> suppliers = entitySet.ToList();

            List<SupplierViewModel> retList = new List<SupplierViewModel>();

            foreach (Supplier supplier in suppliers)
            {
                SupplierViewModel custVM = new SupplierViewModel();


                retList.Add(ObjectMapper.PropertyMap(supplier, custVM));

            }

            return retList;
        }

        
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Supplier> entitySet = dbContext.SupplierSet;

            //SupplierViewModel supplierVM = GetEntity(dbContext, id);


            Supplier supplier = entitySet.FirstOrDefault(x => x.SupplierId == id);

            if (supplier != null)
            {
                entitySet.Remove(supplier);
                dbContext.SaveChanges();
            }
            return true;
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, SupplierViewModel viewModel)
        {
            Supplier supplier = GetDomainEntity(viewModel);
            dbContext.SupplierSet.Add(supplier);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SupplierViewModel viewModel)
        {
            DbSet<Supplier> entitySet = dbContext.SupplierSet;

            Supplier supplier = GetDomainEntity(viewModel);

            entitySet.Attach(supplier);

            dbContext.Entry(supplier).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<SupplierViewModel> Find(InnoventoryDBContext dbContext, Func<SupplierViewModel, bool> predicate)
        {
            List<SupplierViewModel> suppliers = (GetEntities(dbContext)).Where(predicate).ToList();

            return suppliers;
        }

        public FindResult<SupplierViewModel> SearchSupplier(string searchString)
        {
            FindResult<SupplierViewModel> result = new FindResult<SupplierViewModel>()
            {
                Success = false,
            };

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                List<Supplier> suppliers = null;

                if (!string.IsNullOrEmpty(searchString) && searchString.Trim() != string.Empty)
                {
                    suppliers = dbContext.SupplierSet.Where(x => x.SupplierName.Contains(searchString)).OrderBy(x => x.SupplierName).ToList();
                }
                else
                {
                    suppliers = dbContext.SupplierSet.OrderBy(x => x.SupplierName).ToList();
                }

                List<SupplierViewModel> supplierVMs = new List<SupplierViewModel>();

                result.Entities = supplierVMs;

                if (suppliers != null && suppliers.Count > 0)
                {

                    foreach (Supplier supplier in suppliers)
                    {

                        SupplierViewModel supplierVM = ObjectMapper.PropertyMap(supplier, new SupplierViewModel());

                        if (supplierVM != null)
                        {
                            supplierVMs.Add(supplierVM);
                        }

                    }

                }

            }

            result.Success = true;

            return result;
        }

        protected Supplier GetDomainEntity(SupplierViewModel viewModel)
        {
            Supplier supplier = ObjectMapper.PropertyMap(viewModel, new Supplier());

            return supplier;
        }
    }
}
