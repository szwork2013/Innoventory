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

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ICategoryRepository))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CategoryRepository : GenericRepository<Category, CategoryViewModel>, ICategoryRepository
    {

        protected override CategoryViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            Category dmCategory = entitySet.FirstOrDefault(x => x.CategoryId == id);

            CategoryViewModel catVM = new CategoryViewModel();

            CategoryViewModel categoryVM = ObjectMapper.PropertyMap(dmCategory, catVM);

            return categoryVM;

        }

        protected override List<CategoryViewModel> Find(InnoventoryDBContext dbContext, Func<CategoryViewModel, bool> predicate)
        {

            List<CategoryViewModel> categories = (GetEntities(dbContext)).Where(predicate).ToList();

            return categories;
        }


        protected override List<CategoryViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            List<Category> categories = entitySet.OrderBy(x => x.CategoryName).ToList();

            List<CategoryViewModel> retList = new List<CategoryViewModel>();

            categories.ForEach(x => retList.Add(ObjectMapper.PropertyMap(x, new CategoryViewModel())));


            return retList;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CategoryViewModel viewModel)
        {
            Category category = ObjectMapper.PropertyMap(viewModel, new Category()); ;
            dbContext.CategorySet.Add(category);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CategoryViewModel viewModel)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            Category category = ObjectMapper.PropertyMap(viewModel, new Category()); ;

            entitySet.Attach(category);

            dbContext.Entry(category).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            Category category = entitySet.FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                entitySet.Remove(category);
                dbContext.SaveChanges();
            }
            return true;
        }




    }
}
