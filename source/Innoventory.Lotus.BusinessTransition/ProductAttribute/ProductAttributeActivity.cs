using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Innoventory.Lotus.Database.DataEntities;


namespace Innoventory.Lotus.BusinessActivity
{
    [Export(typeof(IProductAttributeActivity))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ProductAttributeActivity : IProductAttributeActivity
    {

        [Import]
        private IProductAttributeRepository productAttributeRepository;

        [Import]
        private ISubCategoryRepository subCategoryRepository;

        [Import]
        private ISubCategoryAttributeMapRepository subCategoryAttributeMapRepository;

        //[Import]
        //private ICategorySubCategoryMapRepository categorySubCategoryMapRepo;

        public FindResult<ProductAttributeViewModel> GetProductAttributes()
        {
            FindResult<ProductAttributeViewModel> findResult = new FindResult<ProductAttributeViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                findResult = productAttributeRepository.GetAll(dbContext);

                if (!findResult.Success)
                {
                    return findResult;
                }


                return SetFindResult(findResult, dbContext);
            }

        }

        private FindResult<ProductAttributeViewModel> SetFindResult(FindResult<ProductAttributeViewModel> findResult, InnoventoryDBContext dbContext)
        {


            //findResult.Success = false;

            FindResult<SubCategoryViewModel> subCategoryResult = subCategoryRepository.GetAll(dbContext);

            FindResult<ProductAttributeViewModel> retResult = new FindResult<ProductAttributeViewModel>();

            retResult.Entities = new List<ProductAttributeViewModel>();



            if (findResult.Success && findResult.Entities.Count > 0)
            {
                foreach (var entity in findResult.Entities)
                {
                    Guid productAttributeId = entity.ProductAttributeId;

                    FindResult<SubCategoryAttributeMapViewModel> subCategoryAttributeMapResult = subCategoryAttributeMapRepository.FindBy(x => x.ProductAttributeId == productAttributeId);

                    List<AttributeSubCategorySelection> subCategorySelections = new List<AttributeSubCategorySelection>();

                    subCategoryResult.Entities.ForEach(x => subCategorySelections.Add(new AttributeSubCategorySelection
                    {
                        SubCategory = x,
                        IsSelected = false,
                    }));

                    subCategorySelections.ForEach(x => x.IsSelected = false);

                    entity.SubCategorySelections = new List<AttributeSubCategorySelection>();


                    entity.SubCategorySelections = subCategorySelections;
                    entity.SubCategoryNames = string.Empty;

                    AttributeSubCategorySelection selection = new AttributeSubCategorySelection();


                    if (subCategoryAttributeMapResult.Success && subCategoryAttributeMapResult.Entities.Count > 0)
                    {
                        foreach (SubCategoryAttributeMapViewModel map in subCategoryAttributeMapResult.Entities)
                        {
                            AttributeSubCategorySelection selectedSubCategory = entity.SubCategorySelections
                                .FirstOrDefault(x => x.SubCategory.SubCategoryId == map.SubCategoryId);

                            selectedSubCategory.IsSelected = true;

                            entity.SubCategoryNames += selectedSubCategory.SubCategory.SubCategoryName + ", ";
                        }
                    }

                    if (entity.SubCategoryNames.Contains(","))
                    {
                        entity.SubCategoryNames = entity.SubCategoryNames.Trim().Substring(0, entity.SubCategoryNames.Trim().Length - 1);
                    }

                    retResult.Entities.Add(entity);
                }

                retResult.Success = true;

            }

            return retResult;
        }

        public FindResult<ProductAttributeViewModel> Find(Func<ProductAttributeViewModel, bool> predicate)
        {
            FindResult<ProductAttributeViewModel> productFindResult = null;

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                productFindResult = productAttributeRepository.FindBy(dbContext, predicate);

                if (!productFindResult.Success)
                {
                    return productFindResult;

                }


                return SetFindResult(productFindResult, dbContext);
            }
        }

        public GetEntityResult<ProductAttributeViewModel> FindById(Guid id)
        {

            GetEntityResult<ProductAttributeViewModel> getEntityResult = null;

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                getEntityResult = productAttributeRepository.FindById(dbContext, id);

                if (!getEntityResult.Success)
                {
                    return getEntityResult;
                }

                FindResult<ProductAttributeViewModel> findResult = new FindResult<ProductAttributeViewModel>();

                findResult.Entities.Add(getEntityResult.Entity);

                findResult = SetFindResult(findResult, dbContext);

                getEntityResult.Success = true;

                getEntityResult.Entity = findResult.Entities.FirstOrDefault();
            }

            return getEntityResult;

        }

        public UpdateResult<ProductAttributeViewModel> UpdateProductAttribute(ProductAttributeViewModel productAttribute)
        {
            UpdateResult<ProductAttributeViewModel> updateResult = new UpdateResult<ProductAttributeViewModel>();

            updateResult.Entity = productAttribute;

            List<AttributeSubCategorySelection> selectedSubCategories = productAttribute.SubCategorySelections.Where(x => x.IsSelected).ToList();

            if (selectedSubCategories.Count == 0)
            {
                updateResult.Success = false;
                updateResult.ErrorMessage = "Please select at least one Sub Category";

                return updateResult;
            }

            if (string.IsNullOrEmpty(productAttribute.AttributeName))
            {
                updateResult.ErrorMessage = "Please enter a valid attribute name";
                return updateResult;
            }

            if (IsAttributeNameDuplicate(productAttribute))
            {
                updateResult.ErrorMessage = "Attribute Name already exist";

                return updateResult;
            }



            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                using (DbContextTransaction trans = dbContext.Database.BeginTransaction())
                {

                    if (productAttribute.ProductAttributeId != Guid.Empty)
                    {

                        FindResult<SubCategoryAttributeMapViewModel> subCategoryAttributeMapVMResult = subCategoryAttributeMapRepository.FindBy(x => x.ProductAttributeId == productAttribute.ProductAttributeId);

                        List<Guid> existingSubCategoryIds = subCategoryAttributeMapVMResult.Entities.Select(x => x.SubCategoryId).ToList();

                        if (!subCategoryAttributeMapVMResult.Success)
                        {
                            updateResult.ErrorMessage = updateResult.ErrorMessage = string.Format("Can not retrieve existing mappings");
                            return updateResult;
                        }

                        if (subCategoryAttributeMapVMResult.Entities.Count > 0)
                        {
                            foreach (var item in subCategoryAttributeMapVMResult.Entities)
                            {
                                AttributeSubCategorySelection existingSelection = productAttribute.SubCategorySelections
                                        .FirstOrDefault(x => x.SubCategory.SubCategoryId == item.SubCategoryId && x.IsSelected == true);

                                if (existingSelection == null)
                                {
                                    EntityOperationResultBase deleteResult = subCategoryAttributeMapRepository.Delete(dbContext, item.SubCategoryAttributeMapId);

                                    if (deleteResult.Success == false)
                                    {
                                        updateResult.ErrorMessage = updateResult.ErrorMessage = string.Format("Mapping {0} Can not be deleted. Error: {1}", item.SubCategoryAttributeMapId, deleteResult.ErrorMessage);
                                    }
                                }
                            }
                        }

                        foreach (AttributeSubCategorySelection subCategorySelection in selectedSubCategories)
                        {

                            if (!existingSubCategoryIds.Contains(subCategorySelection.SubCategory.SubCategoryId))
                            {

                                SubCategoryAttributeMapViewModel newMapping = new SubCategoryAttributeMapViewModel
                                {
                                    ProductAttributeId = productAttribute.ProductAttributeId,
                                    SubCategoryId = subCategorySelection.SubCategory.SubCategoryId
                                };

                                UpdateResult<SubCategoryAttributeMapViewModel> updMappingResult = subCategoryAttributeMapRepository.Update(dbContext, newMapping);

                                if (!updMappingResult.Success)
                                {
                                    updateResult.Success = false;
                                    updateResult.ErrorMessage = updateResult.ErrorMessage = string.Format("Mapping with {0} Can not be saved", subCategorySelection.SubCategory.SubCategoryName); ;
                                    return updateResult;
                                }

                            }

                        }

                        updateResult = productAttributeRepository.Update(productAttribute);

                    }
                    else
                    {

                        updateResult = productAttributeRepository.Update(productAttribute);

                        if (!updateResult.Success)
                        {
                            return updateResult;
                        }

                        ProductAttributeViewModel updatedModel = updateResult.Entity;

                        foreach (var subCatSelection in selectedSubCategories)
                        {

                            SubCategoryAttributeMapViewModel newMapping = new SubCategoryAttributeMapViewModel
                            {
                                SubCategoryId = subCatSelection.SubCategory.SubCategoryId,
                                ProductAttributeId = updatedModel.ProductAttributeId
                            };

                            UpdateResult<SubCategoryAttributeMapViewModel> newMappingUpdateResult = subCategoryAttributeMapRepository.Update(newMapping);

                            if (!newMappingUpdateResult.Success)
                            {
                                trans.Rollback();
                                updateResult.Success = false;
                                updateResult.ErrorMessage = string.Format("Mapping with {0} Can not be saved", subCatSelection.SubCategory.SubCategoryName);
                                return updateResult;
                            }


                        }


                    }

                    trans.Commit();
                }

                if (updateResult.Success)
                {
                    updateResult.SuccessMessage = "Product Attribute saved successfully";
                }
                //if(findre)


            }

            return updateResult;

        }

        private bool IsAttributeNameDuplicate(ProductAttributeViewModel productAttribute)
        {

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                FindResult<ProductAttributeViewModel> findResult = productAttributeRepository.FindBy(dbContext, x => x.AttributeName == productAttribute.AttributeName);

                if (findResult.Success && findResult.Entities.Count > 0)
                {

                    if (findResult.Entities.FirstOrDefault().ProductAttributeId != productAttribute.ProductAttributeId)
                    {
                        return true;
                    }

                }

            }

            return false;
        }


        public DeleteResult<ProductAttributeViewModel> Delete(Guid id)
        {
            GetEntityResult<ProductAttributeViewModel> productAttributeResult = FindById(id);

            DeleteResult<ProductAttributeViewModel> deleteResult = new DeleteResult<ProductAttributeViewModel>();

            FindResult<SubCategoryAttributeMapViewModel> mapResult = subCategoryAttributeMapRepository.FindBy(x => x.ProductAttributeId == productAttributeResult.Entity.ProductAttributeId);

            if (mapResult.Success && mapResult.Entities.Count > 0)
            {

                foreach (SubCategoryAttributeMapViewModel map in mapResult.Entities)
                {

                    EntityOperationResultBase deleteMapResult = subCategoryAttributeMapRepository.Delete(map.SubCategoryAttributeMapId);

                    if (!deleteMapResult.Success)
                    {
                        deleteResult.ErrorMessage = string.Format("Not able to delete all mappings");

                        return deleteResult;
                    }


                }

            }

            EntityOperationResultBase attributeDeleteResult = productAttributeRepository.Delete(id);

            return deleteResult;

        }


        public FindResult<CategorySubCategoryAttributeValuesViewModel> GetAllCategorySubCategoryAttributesValueList(Guid categorySubCategoryMapId)
        {

            FindResult<CategorySubCategoryAttributeValuesViewModel> result = new FindResult<CategorySubCategoryAttributeValuesViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                var categorySubCategoryMapResult = dbContext.CategorySubCategoryMapSet.Where(x=>x.CategorySubCategoryMapId == categorySubCategoryMapId).FirstOrDefault();


                Guid categoryId = Guid.Empty;
                Guid subCategoryId = Guid.Empty;

                if(categorySubCategoryMapResult == null)
                {
                    result.Success = false;

                    return result;
                }
                
                categoryId = categorySubCategoryMapResult.CategoryId;

                subCategoryId = categorySubCategoryMapResult.SubCategoryId;




                var prodAttributes = (from pa in dbContext.ProductAttributeSet
                                     join sca in dbContext.SubCategoryAttributeMapSet
                                     on pa.ProductAttributeId equals sca.ProductAttributeId
                                     where sca.SubCategoryId == subCategoryId
                                     select new CategorySubCategoryAttributeValuesViewModel
                                     {
                                         AttributeName = pa.AttributeName,
                                         ProductAttributeId = pa.ProductAttributeId,
                                          CategorySubCategoryMapId = sca.SubCategoryAttributeMapId,

                                     }).ToList();


                List<AttributeValueList> attributeValueLists = dbContext.AttributeValueListSet.ToList();


                foreach (var pa in prodAttributes)
                {
                    var attributeValueList = (from attvl in attributeValueLists
                                             where attvl.SubCategoryAttributeMapID == pa.CategorySubCategoryMapId
                                             && attvl.CategoryId == categoryId
                                             select new AttributeValueItem
                                             {
                                                 AttributeValue = attvl.AttributeValue,
                                                 AttributeValueListId = attvl.AttributeValueListId
                                             }).ToList();

                    pa.AttributeValues = attributeValueList;
                }


                result.Entities = prodAttributes;


                result.Success = true;

            }

            return result;
        }
    }
}
