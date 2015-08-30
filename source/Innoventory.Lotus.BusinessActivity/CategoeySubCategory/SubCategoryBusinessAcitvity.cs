using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Common;
using System.Data.Entity;

namespace Innoventory.Lotus.BusinessActivity
{
    [Export(typeof(ISubCategoryBusinessAcitvity))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryBusinessAcitvity : ISubCategoryBusinessAcitvity
    {
        [Import]
        ISubCategoryRepository subCategoryRepository;

        [Import]
        ICategoryRepository categoryRepository;

        [Import]
        ICategorySubCategoryMapRepository categorySubCategoryMapRepo;


        //public SubCategoryActivity(ISubCategoryRepository subCategoryRepository, 
        //                            ICategoryRepository categoryRepository,
        //                            ICategorySubCategoryMapRepository categorySubCategoryMapRepo)
        //{
        //    this.subCategoryRepository = subCategoryRepository;
        //    this.categoryRepository = categoryRepository;
        //    this.categorySubCategoryMapRepo = categorySubCategoryMapRepo;
        //}

        public SubCategoryCategories GetSubCategoryCategories(Guid subCategoryId)
        {
            SubCategoryCategories subCategoryCategories = new SubCategoryCategories();

            GetEntityResult<SubCategoryViewModel> entityResult = subCategoryRepository.FindById(subCategoryId);

            if (entityResult.Success && entityResult.Entity != null)
            {
                subCategoryCategories.SubCategory = entityResult.Entity;
                subCategoryCategories.SubCategory.CategoryIds = new List<Guid>();
            }
            else
            {
                throw new Exception("No subcategory found with the matching sub category id");
            }

            subCategoryCategories.CategorySelections = GetCategorySelections(subCategoryId);

            foreach (var item in subCategoryCategories.CategorySelections)
            {
                if (item.IsSelected)
                {
                    subCategoryCategories.SubCategory.CategoryIds.Add(item.CategoryVM.CategoryId);
                }
            }

            //List<CategoryViewModel> 

            return subCategoryCategories;
        }

        public FindResult<SubCategoryViewModel> GetAllSubcategoriesByCategory(Guid id)
        {
            FindResult<SubCategoryViewModel> entityResult = new FindResult<SubCategoryViewModel>() { Success = false };

            List<SubCategoryViewModel> subCategories = new List<SubCategoryViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                var query = from c in dbContext.CategorySet
                            join csbmap in dbContext.CategorySubCategoryMapSet
                            on c.CategoryId equals csbmap.CategoryId
                            join sb in dbContext.SubCategorySet
                            on csbmap.SubCategoryId equals sb.SubCategoryId
                            where c.CategoryId == id
                            select sb;

                foreach (var item in query)
                {
                    subCategories.Add(ObjectMapper.PropertyMap(item, new SubCategoryViewModel()));
                }

                entityResult.Entities = subCategories;
                entityResult.Success = true;
            }

            return entityResult;
        }

        private List<CategorySelectionViewModel> GetCategorySelections(Guid subCategoryId)
        {
            List<CategorySelectionViewModel> categorySelections = new List<CategorySelectionViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                List<CategoryViewModel> selectedCategories = GetCategories(dbContext, subCategoryId);

                List<Guid> selectedCategoryIds = selectedCategories.Select(x => x.CategoryId).ToList();

                FindResult<CategoryViewModel> categoryResult = categoryRepository.GetAll();
                List<CategoryViewModel> allCategories = new List<CategoryViewModel>();

                if (categoryResult != null && categoryResult.Success)
                {
                    allCategories = categoryResult.Entities;
                }

                foreach (var category in allCategories)
                {
                    CategorySelectionViewModel selectionViewModel = new CategorySelectionViewModel();

                    selectionViewModel.CategoryVM = category;

                    if (selectedCategoryIds.Contains(category.CategoryId))
                    {
                        selectionViewModel.IsSelected = true;
                    }

                    categorySelections.Add(selectionViewModel);
                }

            }

            return categorySelections;
        }

        public List<CategoryViewModel> GetCategories(InnoventoryDBContext dbContext, Guid guid)
        {

            List<CategoryViewModel> retResult = new List<CategoryViewModel>();

            var query = from category in dbContext.CategorySet.ToList()
                        join map in dbContext.CategorySubCategoryMapSet.ToList()
                        on category.CategoryId equals map.CategoryId
                        join sc in dbContext.SubCategorySet.ToList()
                        on map.SubCategoryId equals sc.SubCategoryId
                        where (sc.SubCategoryId == guid)
                        select category;


            foreach (var item in query)
            {
                CategoryViewModel cvm = new CategoryViewModel();

                ObjectMapper.PropertyMap(item, cvm);

                retResult.Add(cvm);
            }

            return retResult;

        }


        private void AddCategorySubCategoryMap(InnoventoryDBContext dbContext, SubCategoryViewModel viewModel)
        {
            if (viewModel.CategoryIds != null && viewModel.CategoryIds.Count > 0)
            {
                foreach (Guid categoryId in viewModel.CategoryIds)
                {
                    CategorySubCategoryMapViewModel mapViewModel = new CategorySubCategoryMapViewModel
                    {
                        CategorySubCategoryMapId = Guid.Empty,
                        CategoryId = categoryId,
                        SubCategoryId = viewModel.SubCategoryId,
                    };



                    categorySubCategoryMapRepo.Update(dbContext, mapViewModel);
                }
            }

        }

        private bool AddUpdateCategorySubCategoryMapRepo(SubCategoryViewModel viewModel)
        {
            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                using (DbContextTransaction transaction = dbContext.Database.BeginTransaction())
                {

                    DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;
                    SubCategory subCategory = new SubCategory();
                    ObjectMapper.PropertyMap(viewModel, subCategory);

                    FindResult<CategoryViewModel> categoryResult = categoryRepository.GetAll(dbContext);

                    FindResult<CategorySubCategoryMapViewModel> mapResult = categorySubCategoryMapRepo.FindBy(x => x.SubCategoryId == viewModel.SubCategoryId);

                    List<CategorySubCategoryMapViewModel> existingMappings = new List<CategorySubCategoryMapViewModel>();

                    existingMappings = mapResult.Entities;

                    List<Guid> deletionList = new List<Guid>();

                    List<Guid> newAdded = new List<Guid>();

                    foreach (var emapvm in existingMappings)
                    {
                        if (!viewModel.CategoryIds.Contains(emapvm.CategoryId))
                        {
                            deletionList.Add(emapvm.CategorySubCategoryMapId);
                        }
                    }


                    if (viewModel.CategoryIds != null && viewModel.CategoryIds.Count > 0)
                    {

                        foreach (var cId in viewModel.CategoryIds)
                        {
                            CategorySubCategoryMapViewModel existingMap = existingMappings.FirstOrDefault(x => x.SubCategoryId == viewModel.SubCategoryId && x.CategoryId == cId);

                            if (existingMap == null)
                            {
                                newAdded.Add(cId);
                            }
                        }

                    }

                    if (deletionList.Count > 0)
                    {
                        foreach (Guid mapid in deletionList)
                        {
                            categorySubCategoryMapRepo.Delete(mapid);
                        }
                    }

                    if (newAdded.Count > 0)
                    {
                        foreach (Guid categoryId in newAdded)
                        {
                            CategorySubCategoryMapViewModel catSubCatMapVM = new CategorySubCategoryMapViewModel
                            {

                                CategorySubCategoryMapId = Guid.Empty,
                                CategoryId = categoryId,
                                SubCategoryId = viewModel.SubCategoryId,

                            };

                            categorySubCategoryMapRepo.Update(dbContext, catSubCatMapVM);
                        }
                    }

                    subCategorySet.Attach(subCategory);

                    dbContext.Entry<SubCategory>(subCategory).State = EntityState.Modified;

                    dbContext.SaveChanges();

                    transaction.Commit();
                }
            }

            return true;
        }

        public UpdateResult<SubCategoryViewModel> UpdateSubCategory(SubCategoryViewModel subCategoryViewModel)
        {
            UpdateResult<SubCategoryViewModel> updateResult = new UpdateResult<SubCategoryViewModel>();

            if (subCategoryViewModel.SubCategoryId == Guid.Empty)
            {
                updateResult = CreateNewSubcategory(subCategoryViewModel);
            }
            else
            {

                bool success = AddUpdateCategorySubCategoryMapRepo(subCategoryViewModel);

                updateResult.Success = success;


            }

            return updateResult;
        }

        private UpdateResult<SubCategoryViewModel> CreateNewSubcategory(SubCategoryViewModel subCategoryViewModel)
        {
            UpdateResult<SubCategoryViewModel> updateResult = new UpdateResult<SubCategoryViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                updateResult = subCategoryRepository.Update(subCategoryViewModel);

                if (updateResult.Success)
                {
                    AddCategorySubCategoryMap(dbContext, subCategoryViewModel);
                }

                updateResult.Success = true;
                updateResult.ErrorMessage = string.Empty;
            }

            return updateResult;


        }

        public FindResult<SubCategoryViewModel> GetAllSubcategories()
        {
            return subCategoryRepository.GetAll();
        }


        public GetEntityResult<CategorySubCategoryMapViewModel> GetCategorySubCategoryMap(Guid categoryId, Guid subCategoryId)
        {
            FindResult<CategorySubCategoryMapViewModel> findResult = new FindResult<CategorySubCategoryMapViewModel>();

            findResult = categorySubCategoryMapRepo.FindBy(x => x.CategoryId == categoryId && x.SubCategoryId == subCategoryId);

            GetEntityResult<CategorySubCategoryMapViewModel> result = new GetEntityResult<CategorySubCategoryMapViewModel>();

            if (findResult.Success)
            {
                result.Entity = findResult.Entities.FirstOrDefault();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }
    }
}
