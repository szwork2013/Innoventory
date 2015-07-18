using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(ISubCategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryRepository : GenericRepository<SubCategory, SubCategoryViewModel>, ISubCategoryRepository
    {
        ICategoryRepository _categoryRepository;

        ICategorySubCategoryMapRepository _categorySubCategoryMapRepo;

        public SubCategoryRepository()
        {
            _categoryRepository = new CategoryRepository();
            _categorySubCategoryMapRepo = new CategorySubCategoryMapRepository();
        }
        protected override SubCategoryViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;

            SubCategory sc = subCategorySet.FirstOrDefault(x => x.SubCategoryId == id);

            SubCategoryViewModel scvm = new SubCategoryViewModel();

            if (sc != null)
            {

                scvm = ObjectMapper.PropertyMap(sc, scvm);

            }

            return scvm;
        }

        protected override List<SubCategoryViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<SubCategory> entitySet = dbContext.SubCategorySet;

            List<SubCategory> subCategories = entitySet.ToList();

            List<SubCategoryViewModel> retList = new List<SubCategoryViewModel>();

            foreach (SubCategory subCategory in subCategories)
            {
                SubCategoryViewModel scvm = new SubCategoryViewModel();

                ObjectMapper.PropertyMap(subCategory, scvm);

                //CategoryViewModel cvm = _categoryRepository.FindById()

                List<CategoryViewModel> categories =  GetCategories(dbContext, subCategory.SubCategoryId);

                StringBuilder categoryString = new StringBuilder();

                categories.ForEach(x => categoryString.Append(x.CategoryName + ","));

                scvm.SelectedCategories = categoryString.ToString();

                retList.Add(scvm);
            }

            return retList;
        }

        private List<CategoryViewModel> GetCategories(InnoventoryDBContext dbContext,  Guid guid)
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


        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;
            SubCategory subCategory = subCategorySet.FirstOrDefault(x => x.SubCategoryId == id);

            if (subCategory != null)
            {
                subCategorySet.Remove(subCategory);
                dbContext.SaveChanges();
            }

            return true;
        }


        protected override bool AddEntity(InnoventoryDBContext dbContext, SubCategoryViewModel viewModel)
        {
            DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;
            SubCategory subCategory = new SubCategory();
            SubCategory newSubCategory = ObjectMapper.PropertyMap(viewModel, subCategory);

            subCategorySet.Add(subCategory);
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

                    _categorySubCategoryMapRepo.Update(dbContext, mapViewModel);
                }
            }

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SubCategoryViewModel viewModel)
        {
            DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;
            SubCategory subCategory = new SubCategory();
            ObjectMapper.PropertyMap(viewModel, subCategory);

            subCategorySet.Attach(subCategory);
            dbContext.Entry<SubCategory>(subCategory).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<SubCategoryViewModel> Find(InnoventoryDBContext dbContext, Func<SubCategoryViewModel, bool> predicate)
        {
            DbSet<SubCategory> subCategorySet = dbContext.SubCategorySet;
            List<SubCategoryViewModel> retList = GetEntities(dbContext).Where(predicate).ToList();

            return retList;
        }

        public SubCategoryCategories GetSubCategoryCategories(Guid subCategoryId)
        {
            SubCategoryCategories subCategoryCategories = new SubCategoryCategories();

            GetEntityResult<SubCategoryViewModel> entityResult = this.FindById(subCategoryId);
            if(entityResult.Success && entityResult.Entity != null)
            {
                subCategoryCategories.SubCategory = entityResult.Entity;
            }
            else
            {
                throw new Exception("No subcategory found with the matching sub category id");
            }

            subCategoryCategories.CategorySelections = GetCategorySelections(subCategoryId);

            //List<CategoryViewModel> 

            return subCategoryCategories;
        }

        private List<CategorySelectionViewModel> GetCategorySelections(Guid subCategoryId)
        {
            List<CategorySelectionViewModel> categorySelections = new List<CategorySelectionViewModel>();
            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                List<CategoryViewModel> selectedCategories = GetCategories(dbContext, subCategoryId);

                List<Guid> selectedCategoryIds = selectedCategories.Select(x=>x.CategoryId).ToList();

                FindResult<CategoryViewModel> categoryResult = _categoryRepository.GetAll();
                List<CategoryViewModel> allCategories = new List<CategoryViewModel>();

                if(categoryResult != null && categoryResult.Success)
                {
                    allCategories = categoryResult.Entities;
                }

                foreach (var category in allCategories)
                {
                    CategorySelectionViewModel selectionViewModel = new CategorySelectionViewModel();

                    selectionViewModel.CategoryVM = category;

                    if(selectedCategoryIds.Contains(category.CategoryId))
                    {
                        selectionViewModel.IsSelected = true;
                    }

                    categorySelections.Add(selectionViewModel);
                }

            }

            return categorySelections;
        }
    }
}
