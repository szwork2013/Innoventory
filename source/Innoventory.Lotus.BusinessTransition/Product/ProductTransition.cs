using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Innoventory.Lotus.Database;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Business;
using Innoventory.Lotus.Database.DataEntities;
using System.ComponentModel.Composition;
using Innoventory.Lotus.Business.Abstract;
using System.Runtime.Caching;

namespace Innoventory.Lotus.BusinessTransition
{

    [Export(typeof(IProductTransition))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ProductTransition : IProductTransition
    {

        private const string CONST_CACHE_PRODUCT = "PRODUCT_CACHE";

        private const string CONST_CACHE_PRODUCT_VARIANT = "PRODUCT_VARIANT_CACHE";

        private MemoryCache productCache;

        //private MemoryCache productVariantCache;

        [Import]
        private IProductRepository productRepository;

        [Import]
        private IProductVariantRepository productVariantRepository;

        [Import]
        private ICategorySubCategoryMapRepository categorySubCategoryMapRepository;

        [Import]
        private ICategoryRepository categoryRepository;

        [Import]
        private ISubCategoryRepository subCategoryRepository;

        [Import]
        private IVolumeMeasureRepository volumeMeasureRepository;

        [Import]
        private IImageFileRepository imageFileRepository;

        [Import]
        private IProductAttributeRepository productAttributeRepository;

        [Import]
        private ISubCategoryAttributeMapRepository categorySubCategoryAttributeMapRepository;

        [Import]
        private IAttributeValueListRepository attributeValueListRepository;

        
        [Import]
        private IProductVariantImageFileMapRepository productVariantImageFileMapRepository;

        public GetEntityResult<ProductViewModel> GetProduct(Guid productId)
        {
            GetEntityResult<ProductViewModel> entityResult = new GetEntityResult<ProductViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                //dbContext.Database.SqlQuery(  )

                var product = (from pr in dbContext.ProductSet.ToList()
                               join vm in dbContext.VolumeMeasureSet.ToList() on pr.SalesVolumeMeasureId equals vm.VolumeMeasureId
                               join svm in dbContext.VolumeMeasureSet.ToList() on pr.PurchaseVolumeMeasureId equals svm.VolumeMeasureId
                               join catSubCatMap in dbContext.CategorySubCategoryMapSet.ToList() on pr.CategorySubCategoryMapId equals catSubCatMap.CategorySubCategoryMapId
                               join category in dbContext.CategorySet.ToList() on catSubCatMap.CategoryId equals category.CategoryId
                               join subCategory in dbContext.SubCategorySet on catSubCatMap.SubCategoryId equals subCategory.SubCategoryId
                               where pr.ProductId == productId
                               select new ProductViewModel
                               {
                                   CategoryId = category.CategoryId,
                                   CategoryName = category.CategoryName,
                                   CategorySubCategoryMapId = pr.CategorySubCategoryMapId,
                                   Description = pr.Description,
                                   ImageId = pr.ImageId,
                                   ItemType = pr.ItemType,
                                   ProductName = pr.ProductName,
                                   PurchaseVolueMeasureId = pr.PurchaseVolumeMeasureId,
                                   PurchaseVolumeMeasureName = vm.ShortName,
                                   SalesVolumeMeasureName = svm.ShortName,
                                   SalesVolumeMeasureId = pr.SalesVolumeMeasureId,
                                   SubCategoryId = subCategory.SubCategoryId,
                                   SubCategoryName = subCategory.SubCategoryName,
                                   Remarks = pr.Remarks
                               }).FirstOrDefault();

                GetEntityResult<ProductViewModel> productResult = productRepository.FindById(dbContext, productId);


                if (!productResult.Success)
                {

                    return productResult;

                }



                FindResult<ProductVariantViewModel> findProductVriantResult = productVariantRepository.FindBy(dbContext, x => x.ProductId == productId);

                if (!findProductVriantResult.Success)
                {
                    entityResult.Success = false;
                    entityResult.ErrorMessage = findProductVriantResult.ErrorMessage;
                    return entityResult;
                }


                List<ProductVariantViewModel> productVariants = findProductVriantResult.Entities;

                product.ProductVariants = productVariants;
                               

                long categoryAttributeCount = 0;

                FindResult<SubCategoryAttributeMapViewModel> subCatAttribMapResult = categorySubCategoryAttributeMapRepository
                                .FindBy(dbContext, x => x.SubCategoryId == product.CategorySubCategoryMapId);

                if (subCatAttribMapResult.Success && subCatAttribMapResult.Count > 0)
                {

                    categoryAttributeCount = subCatAttribMapResult.Count;

                }

                foreach (ProductVariantViewModel pvm in productVariants)
                {



                    pvm.ProductVariantAttributeValues = (from pv in dbContext.ProductVariantAttributeValueSet
                                                         join avl in dbContext.AttributeValueListSet on pv.AttributeValueListId equals avl.AttributeValueListId
                                                         join subcatAttrMap in dbContext.SubCategoryAttributeMapSet
                                                         on avl.SubCategoryAttributeMapID equals subcatAttrMap.SubCategoryAttributeMapId
                                                         join productAttributs in dbContext.ProductAttributeSet
                                                         on subcatAttrMap.ProductAttributeId equals productAttributs.ProductAttributeId
                                                         where pv.ProductVariantId == pvm.ProductVariantId
                                                         select new ProductVariantAttributeValueViewModel
                                                         {
                                                             ProductVariantId = pv.ProductVariantId,
                                                             AttributeValueListId = avl.AttributeValueListId,
                                                             ProductAttributeName = productAttributs.AttributeName,
                                                             ProductAttributeValue = avl.AttributeValue
                                                         }).ToList();

                }

            }

            return entityResult;
        }

        public FindResult<ProductViewModel> GetAllProducts(ProductFilterOption filterOption, SortOption sortOption)
        {
            


        }

        public UpdateResult<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductToInactive(Guid productId)
        {
            throw new NotImplementedException();
        }

        public bool ActivateProduct(Guid productId)
        {
            throw new NotImplementedException();
        }



        public PreCacheResult<ProductViewModel> PreCache()
        {
            throw new NotImplementedException();
        }
    }
}
