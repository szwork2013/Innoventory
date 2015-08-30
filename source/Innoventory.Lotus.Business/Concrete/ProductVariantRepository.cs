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
using System.Runtime.Caching;


namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(IProductVariantRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantRepository : GenericRepository<ProductVariant, ProductVariantViewModel>, IProductVariantRepository
    {

        MemoryCache pvCache;

        public const string CONST_CACHE_PRODUCT_VARIANT = "PRODUCT_VARIANT_CACHE";

        protected ProductVariant GetDomainEntity(ProductVariantViewModel viewModel)
        {
            ProductVariant productVariant = GetProductVariant(viewModel);

            return productVariant;
        }

        private ProductVariant GetProductVariant(ProductVariantViewModel viewModel)
        {
            ProductVariant pv = new ProductVariant()
            {
                AvailableQuantity = viewModel.AvailableQuantity,
                BarCode = viewModel.BarCode,
                BasePrice = viewModel.BasePrice,
                CaseHeight = viewModel.CaseHeight,
                CaseLength = viewModel.CaseLength,
                CaseWeight = viewModel.CaseWeight,
                CaseWidth = viewModel.CaseWidth,
                ImageFileId = viewModel.MainImageFileId,
                IsActive = viewModel.IsActive,
                IsPurchaseable = viewModel.IsPurchaseable,
                IsSellable = viewModel.IsSellable,
                LastPurchasePrice = viewModel.LastPurchasePrice,
                LastSupplierId = viewModel.LastSupplierId,
                ModifiedOn = DateTime.Now,
                ProductHeight = viewModel.ProductHeight,
                ProductId = viewModel.ProductId,
                ProductLength = viewModel.ProductLength,
                ProductVariantId = viewModel.ProductVariantId,
                ProductWeight = viewModel.ProductWeight,
                ProductWidth = viewModel.ProductWidth,
                ReorderPoint = viewModel.ReorderPoint,
                ReorderQuantity = viewModel.ReorderQuantity,
                PromotionId = viewModel.PromotionId,
                ShelfPrice = viewModel.ShelfPrice,
                SKUCode = viewModel.SKUCode,
                UnitVolume = viewModel.UnitVolume,
            };

            return pv;
        }



        protected override ProductVariantViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            ProductVariant dmProductVariant = entitySet.FirstOrDefault(x => x.ProductVariantId == id);

            ProductVariantViewModel pvVM = new ProductVariantViewModel();

            ProductVariantViewModel productVariantVM = ObjectMapper.PropertyMap(dmProductVariant, pvVM);

            return productVariantVM;

        }

        protected override List<ProductVariantViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            List<ProductVariant> productVariants = entitySet.ToList();

            List<ProductVariantViewModel> retList = new List<ProductVariantViewModel>();

            foreach (ProductVariant productVariant in productVariants)
            {

                ProductVariantViewModel pvVM = new ProductVariantViewModel();

                retList.Add(ObjectMapper.PropertyMap(productVariant, pvVM));

            }

            return retList;
        }

        protected override List<ProductVariantViewModel> Find(InnoventoryDBContext dbContext, Func<ProductVariantViewModel, bool> predicate)
        {

            List<ProductVariantViewModel> productVariants = (GetEntities(dbContext)).Where(predicate).ToList();

            return productVariants;

        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            //ProductVariantViewModel productVariantVM = GetEntity(dbContext, id);


            ProductVariant productVariant = entitySet.FirstOrDefault(x => x.ProductVariantId == id);

            if (productVariant != null)
            {
                entitySet.Remove(productVariant);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            ProductVariant productVariant = GetDomainEntity(viewModel);
            dbContext.ProductVariantSet.Add(productVariant);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            ProductVariant productVariant = GetDomainEntity(viewModel);

            entitySet.Attach(productVariant);

            dbContext.Entry(productVariant).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }

        public PreCacheResult<ProductVariantViewModel> PreCache()
        {
            PreCacheResult<ProductVariantViewModel> precacheResult = new PreCacheResult<ProductVariantViewModel>();
            
            InnoventoryDBContext dbContext = new InnoventoryDBContext();

            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            precacheResult.Count = entitySet.Count();

            
            List<ProductVariant> productVariants = entitySet.ToList();

            List<ProductVariantViewModel> retList = new List<ProductVariantViewModel>();

            Parallel.ForEach(productVariants, pv =>
            {
                ProductVariantViewModel pvVM = new ProductVariantViewModel();

                retList.Add(ObjectMapper.PropertyMap(pv, pvVM));

            });

            return precacheResult;
        }
    }
}
