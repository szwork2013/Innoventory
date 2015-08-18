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
        private ISubCategoryAttributeMapRepository categorySubCategoryAttributeMapRepository;

        [Import]
        private IProductAttributeRepository productAttributeRepository;

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
                               join vm in dbContext.VolumeMeasureSet.ToList() on pr.VolumeMeasureId equals vm.VolumeMeasureId
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
                                   VolueMeasureId = pr.VolumeMeasureId,
                                   volumeMeasureShortName = vm.ShortName,
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

        public FindResult<ProductListItem> GetAllProductListItems(ProductFilterOption filterOption)
        {
            FindResult<ProductListItem> result = new FindResult<ProductListItem>() { Success = false };

            try
            {

                using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
                {
                    List<ProductListItem> productListItems = (from pr in dbContext.ProductSet.ToList()
                                                              join catSubCatMap in dbContext.CategorySubCategoryMapSet.ToList()
                                                              on pr.CategorySubCategoryMapId equals catSubCatMap.CategorySubCategoryMapId
                                                              join category in dbContext.CategorySet.ToList()
                                                              on catSubCatMap.CategoryId equals category.CategoryId
                                                              join subCategory in dbContext.SubCategorySet
                                                              on catSubCatMap.SubCategoryId equals subCategory.SubCategoryId
                                                              select new ProductListItem
                                                              {
                                                                  CategoryId = category.CategoryId,
                                                                  CategoryName = category.CategoryName,
                                                                  Description = pr.Description,
                                                                  ImageId = pr.ImageId,
                                                                  ItemType = pr.ItemType,
                                                                  ProductName = pr.ProductName,
                                                                  SubCategoryId = subCategory.SubCategoryId,
                                                                  SubCategoryName = subCategory.SubCategoryName,
                                                                  ProductId = pr.ProductId

                                                              }).ToList();

                    

                    if (!string.IsNullOrEmpty(filterOption.SearchString) && filterOption.SearchString.Trim() != string.Empty)
                    {
                        productListItems = productListItems.Where(x => x.ProductName.Contains(filterOption.SearchString)).ToList();

                    }

                    if(filterOption.CategoryId != Guid.Empty)
                    {
                        productListItems = productListItems.Where(x => x.CategoryId == filterOption.CategoryId).ToList();
                    }

                    if (filterOption.SubCategoryId != Guid.Empty)
                    {
                        productListItems = productListItems.Where(x => x.SubCategoryId == filterOption.SubCategoryId).ToList();
                    }

                    result.Entities = productListItems.OrderBy(x => x.ProductName).ToList();
                }

                result.Success = true;


            }
            catch (Exception ex)
            {
                result.Success = false;
                throw;
            }


            return result;

        }

        public FindResult<ProductVariantListItem> GetAllProductVariantListItems(Guid productId)
        {
            FindResult<ProductVariantListItem> result = new FindResult<ProductVariantListItem> { Success = false };

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                var productVariants = (from prv in dbContext.ProductVariantSet
                                       where prv.ProductId == productId
                                       select new ProductVariantListItem
                                       {
                                           ProductVariantId = prv.ProductVariantId,
                                           AvailableQuantity = prv.AvailableQuantity,
                                           BasePrice = prv.BasePrice,
                                           ShelfPrice = prv.ShelfPrice,
                                           SKUCode = prv.SKUCode,
                                       }).ToList();

                foreach (ProductVariantListItem pvm in productVariants)
                {



                    var productVariantAttributeValues = GetProductVariantAttributeValueVMS(dbContext, pvm.ProductVariantId);


                    if (productVariantAttributeValues.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (var item in productVariantAttributeValues)
                        {
                            sb.AppendFormat("{0} - ({1}), ", item.ProductAttributeName, item.ProductAttributeValue);
                            sb.Append(" ");
                        }

                        string formattedAttributeValues = sb.ToString().Trim();

                        if (formattedAttributeValues.EndsWith(","))
                        {
                            formattedAttributeValues = formattedAttributeValues.Substring(0, formattedAttributeValues.Length - 1);
                        }

                        pvm.AttributeValuesString = formattedAttributeValues;
                    }

                }


                productVariantRepository.FindById(Guid.NewGuid());

                result.Entities = productVariants;
            }

            result.Success = true;

            return result;
        }


        public List<ProductVariantAttributeValueViewModel> GetProductVariantAttributeValueVMS(InnoventoryDBContext dbContext, Guid productVariantId)
        {

            var ProductVariantAttributeValues = (from pv in dbContext.ProductVariantAttributeValueSet
                                                 join avl in dbContext.AttributeValueListSet on pv.AttributeValueListId equals avl.AttributeValueListId
                                                 join subcatAttrMap in dbContext.SubCategoryAttributeMapSet
                                                 on avl.SubCategoryAttributeMapID equals subcatAttrMap.SubCategoryAttributeMapId
                                                 join productAttributs in dbContext.ProductAttributeSet
                                                 on subcatAttrMap.ProductAttributeId equals productAttributs.ProductAttributeId
                                                 where pv.ProductVariantId == productVariantId
                                                 select new ProductVariantAttributeValueViewModel
                                                 {
                                                     ProductVariantId = pv.ProductVariantId,
                                                     AttributeValueListId = avl.AttributeValueListId,
                                                     ProductAttributeName = productAttributs.AttributeName,
                                                     ProductAttributeValue = avl.AttributeValue
                                                 }).ToList();

            return ProductVariantAttributeValues;
        }
        public UpdateResult<ProductViewModel> SaveProduct(ProductViewModel productViewModel)
        {

            UpdateResult<ProductViewModel> result = new UpdateResult<ProductViewModel>() { Success = false };

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                UpdateResult<ProductViewModel> updateResult = productRepository.Update(dbContext, productViewModel);

                if (!updateResult.Success)
                {
                    return updateResult;
                }

                foreach (ProductVariantViewModel prvm in productViewModel.ProductVariants)
                {
                    productVariantRepository.Update(prvm);

                    foreach (var item in prvm.ProductVariantAttributeValues)
                    {
                        //item.
                    }
                }
            }

            return result;
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
