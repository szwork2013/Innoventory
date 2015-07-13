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
    [Export(typeof(ICategorySubCategoryMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategorySubCategoryMapRepository : GenericRepository<CategorySubCategoryMap, CategorySubCategoryMapViewModel>,
                                                    ICategorySubCategoryMapRepository
    {
        ICategoryRepository _categoryRespository;
        ISubCategoryRepository _subCategoryRepository;

        public CategorySubCategoryMapRepository()
            : base()
        {
            _categoryRespository = new CategoryRepository();

            _subCategoryRepository = new SubCategoryRepository();
        }
        protected override CategorySubCategoryMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<CategorySubCategoryMap> dbSet = dbContext.CategorySubCategoryMapSet;
            CategorySubCategoryMap catSubCatMap = dbSet.FirstOrDefault(x => x.CategorySubCategoryMapId == id);
            CategorySubCategoryMapViewModel catSubCatMapVM = new CategorySubCategoryMapViewModel();

            ObjectMapper.PropertyMap(catSubCatMap, catSubCatMapVM);
            return catSubCatMapVM;
        }

        protected override List<CategorySubCategoryMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<CategorySubCategoryMap> dbSet = dbContext.CategorySubCategoryMapSet;

            List<CategorySubCategoryMap> catSubcatMaps = dbSet.ToList();

            List<CategorySubCategoryMapViewModel> vmList = new List<CategorySubCategoryMapViewModel>();

            foreach (CategorySubCategoryMap map in catSubcatMaps)
            {
                CategorySubCategoryMapViewModel vm = new CategorySubCategoryMapViewModel();

                ObjectMapper.PropertyMap(map, vm);

                GetEntityResult<CategoryViewModel> categoryResult = _categoryRespository.FindById(map.CategoryId);

                if (categoryResult != null && categoryResult.Success)
                {
                    vm.Category = categoryResult.Entity;
                }

                GetEntityResult<SubCategoryViewModel> subCategoryResult = _subCategoryRepository.FindById(map.SubCategoryId);

                if (subCategoryResult != null && subCategoryResult.Success)
                {
                    vm.SubCategory = subCategoryResult.Entity;
                }

                vmList.Add(vm);
            }

            return vmList;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<CategorySubCategoryMap> dbSet = dbContext.CategorySubCategoryMapSet;
            CategorySubCategoryMap map = dbSet.FirstOrDefault(x => x.CategorySubCategoryMapId == id);

            if (map != null)
            {
                dbSet.Remove(map);
                dbContext.SaveChanges();
            }

            return true;
        }



        protected override bool AddEntity(InnoventoryDBContext dbContext, CategorySubCategoryMapViewModel viewModel)
        {
            DbSet<CategorySubCategoryMap> dbSet = dbContext.CategorySubCategoryMapSet;
            CategorySubCategoryMap map = new CategorySubCategoryMap();

            ObjectMapper.PropertyMap(viewModel, map);

            dbSet.Add(map);
            dbContext.SaveChanges();
            return true;

        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CategorySubCategoryMapViewModel viewModel)
        {
            DbSet<CategorySubCategoryMap> dbSet = dbContext.CategorySubCategoryMapSet;
            CategorySubCategoryMap map = new CategorySubCategoryMap();

            ObjectMapper.PropertyMap(viewModel, map);

            dbSet.Attach(map);
            dbContext.Entry(map).State = EntityState.Modified;
            dbContext.SaveChanges();

            return true;
        }

        protected override List<CategorySubCategoryMapViewModel> Find(InnoventoryDBContext dbContext, Func<CategorySubCategoryMapViewModel, bool> predicate)
        {
            List<CategorySubCategoryMapViewModel> retList = GetEntities(dbContext).Where(predicate).ToList();

            return retList;
        }
    }
}
