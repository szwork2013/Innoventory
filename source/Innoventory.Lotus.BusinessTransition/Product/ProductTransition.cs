using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Innoventory.Lotus.Database;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Repository;
using Innoventory.Lotus.Database.DataEntities;
using System.ComponentModel.Composition;
using Innoventory.Lotus.Repository.Abstract;
using System.Runtime.Caching;
using Innoventory.Lotus.Core.Common;

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
        private ISubCategoryAttributeMapRepository subCategoryAttributeMapRepository;


        [Import]
        private IProductVariantImageFileMapRepository productVariantImageFileMapRepository;

        public GetEntityResult<ProductViewModel> GetProduct(Guid productId)
        {
            GetEntityResult<ProductViewModel> entityResult = new GetEntityResult<ProductViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                GetEntityResult<ProductViewModel> productResult = productRepository.FindById(dbContext, productId);


                if (!productResult.Success)
                {
                    return productResult;
                }

                var product = productResult.Entity;

                var categorySubCategoryMap = from cscmap in dbContext.CategorySubCategoryMapSet
                                             join c in dbContext.CategorySet on cscmap.CategoryId equals c.CategoryId
                                             join sc in dbContext.SubCategorySet
                                             on cscmap.SubCategoryId equals sc.SubCategoryId
                                             where (cscmap.CategorySubCategoryMapId == product.CategorySubCategoryMapId)
                                             select new CategorySubCategoryMapViewModel
                                             {
                                                 Category = new CategoryViewModel
                                                 {
                                                     CategoryId = c.CategoryId,
                                                     CategoryName = c.CategoryName,
                                                     Description = c.Description,
                                                 },
                                                 CategoryId = c.CategoryId,
                                                 CategorySubCategoryMapId = product.CategorySubCategoryMapId,
                                                 SubCategory = new SubCategoryViewModel
                                                 {
                                                     Description = sc.Description,
                                                     SubCategoryId = sc.SubCategoryId,
                                                     SubCategoryName = sc.SubCategoryName,
                                                 },
                                                 SubCategoryId = sc.SubCategoryId
                                             };


                product.CategorySubCategoryMap = categorySubCategoryMap.FirstOrDefault();



                //if (categorySubCategoryMap != null)
                //{
                //    var category = dbContext.CategorySet.Where(x => x.CategoryId == categorySubCategoryMap.CategoryId).FirstOrDefault();

                //    if (category != null)
                //    {
                //        product.CategoryId = category.CategoryId;
                //        product.CategoryName = category.CategoryName;
                //    }

                //    var subCategory = dbContext.SubCategorySet.Where(x => x.SubCategoryId == categorySubCategoryMap.SubCategoryId).FirstOrDefault();

                //    if (subCategory != null)
                //    {
                //        product.SubCategoryId = subCategory.SubCategoryId;
                //        product.SubCategoryName = subCategory.SubCategoryName;
                //    }


                //}

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

                FindResult<SubCategoryAttributeMapViewModel> subCatAttribMapResult = subCategoryAttributeMapRepository
                                .FindBy(dbContext, x => x.SubCategoryId == product.CategorySubCategoryMap.SubCategoryId);

                if (subCatAttribMapResult.Success && subCatAttribMapResult.Count > 0)
                {

                    categoryAttributeCount = subCatAttribMapResult.Count;

                }
                if (product.ProductVariants != null && product.ProductVariants.Count > 0)
                {
                    foreach (ProductVariantViewModel pvm in product.ProductVariants)
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
                                                                 ProductAttributeValue = avl.AttributeValue,
                                                                 ProductAttributeId = productAttributs.ProductAttributeId,
                                                             }).ToList();

                    }
                }

                FindResult<ProductVariantListItem> pvResult = GetAllProductVariantListItems(product.ProductId);

                if (pvResult.Success)
                {
                    product.ProductVariantListItems = pvResult.Entities;
                }

                entityResult.Entity = product;

                entityResult.Success = true;
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

                    if (filterOption.CategoryId != Guid.Empty)
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
                            sb.AppendFormat("{0}: {1}; ", item.ProductAttributeName, item.ProductAttributeValue);
                            sb.Append(" ");
                        }

                        string formattedAttributeValues = sb.ToString().Trim();

                        if (formattedAttributeValues.EndsWith(";"))
                        {
                            formattedAttributeValues = formattedAttributeValues.Substring(0, formattedAttributeValues.Length - 1);
                        }

                        pvm.AttributeValuesString = formattedAttributeValues;
                    }

                }



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

            Guid categoryId = productViewModel.CategorySubCategoryMap.CategoryId;
            Guid subCategoryId = productViewModel.CategorySubCategoryMap.SubCategoryId;


            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                try
                {

                    UpdateResult<ProductViewModel> updateResult = productRepository.Update(dbContext, productViewModel);

                    if (!updateResult.Success)
                    {
                        return updateResult;
                    }

                    foreach (ProductVariantViewModel prvm in productViewModel.ProductVariants)
                    {

                        prvm.ProductId = updateResult.Entity.ProductId;

                        ProductVariant pv = dbContext.ProductVariantSet.Where(x => x.ProductVariantId == prvm.ProductVariantId).FirstOrDefault();

                        if (pv == null)
                        {
                            prvm.ProductVariantId = Guid.Empty;
                        }

                        UpdateResult<ProductVariantViewModel> pvUpdateResult = productVariantRepository.Update(prvm);

                        if (!pvUpdateResult.Success)
                        {
                            result.Success = false;
                            result.ErrorMessage = pvUpdateResult.ErrorMessage;
                            return result;
                        }

                        List<ProductVariantAttributeValue> productVariantAttributeValueMaps = dbContext.ProductVariantAttributeValueSet
                                            .Where(x => x.ProductVariantId == prvm.ProductVariantId).ToList();

                        List<Guid> attributeSelectValueIds = new List<Guid>();

                        foreach (var item in prvm.ProductVariantAttributeValues)
                        {
                            if (item.ProductAttributeId != Guid.Empty)
                            {


                                if ((!item.AttributeValueListId.HasValue
                                     || item.AttributeValueListId.Value == Guid.Empty)
                                     && !string.IsNullOrEmpty(item.ProductAttributeValue))
                                {
                                    SubCategoryAttributeMap scAttrMap = dbContext.SubCategoryAttributeMapSet
                                        .Where(x => x.ProductAttributeId == item.ProductAttributeId && x.SubCategoryId == subCategoryId).FirstOrDefault();

                                    AttributeValueList avl = new AttributeValueList()
                                    {

                                        AttributeValueListId = Guid.NewGuid(),
                                        AttributeValue = item.ProductAttributeValue,
                                        CategoryId = categoryId,
                                        SubCategoryAttributeMapID = scAttrMap.SubCategoryAttributeMapId,
                                    };

                                    dbContext.AttributeValueListSet.Add(avl);


                                    item.AttributeValueListId = avl.AttributeValueListId;

                                    ProductVariantAttributeValue newPVAttrValue = new ProductVariantAttributeValue()
                                    {
                                        ProductVariantId = prvm.ProductVariantId,
                                        AttributeValueListId = item.AttributeValueListId.Value,
                                    };

                                    dbContext.ProductVariantAttributeValueSet.Add(newPVAttrValue);
                                    dbContext.SaveChanges();

                                }
                                else if (item.AttributeValueListId.HasValue && item.AttributeValueListId != Guid.Empty && !string.IsNullOrEmpty(item.ProductAttributeValue))
                                {
                                    ProductVariantAttributeValue pvAttrValue = productVariantAttributeValueMaps
                                                        .Where(x => x.AttributeValueListId == item.AttributeValueListId.Value)
                                                        .FirstOrDefault();

                                    if (pvAttrValue != null)
                                    {
                                        productVariantAttributeValueMaps.Remove(pvAttrValue);
                                    }
                                    else
                                    {
                                        ProductVariantAttributeValue newPVAttrValue = new ProductVariantAttributeValue()
                                        {
                                            ProductVariantId = prvm.ProductVariantId,
                                            AttributeValueListId = item.AttributeValueListId.Value,
                                        };

                                        dbContext.ProductVariantAttributeValueSet.Add(newPVAttrValue);
                                        dbContext.SaveChanges();

                                    }
                                }
                            }

                        }

                        if (productVariantAttributeValueMaps != null && productVariantAttributeValueMaps.Count > 0)
                        {
                            foreach (var pvavm in productVariantAttributeValueMaps)
                            {
                                dbContext.ProductVariantAttributeValueSet.Remove(pvavm);

                            }

                            dbContext.SaveChanges();
                        }
                    }

                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = ex.Message;
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
