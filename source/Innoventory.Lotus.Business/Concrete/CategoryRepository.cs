using Innoventory.Lotus.Business.Abstract;
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

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(ICategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategoryRepository : GenericRepository<Category, CategoryViewModel>, ICategoryRepository
    {

        protected override Category GetDomainEntity(CategoryViewModel viewModel)
        {
            Category category = ObjectMapper.PropertyMap(viewModel, new Category());

            return category;
        }



        protected override CategoryViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            Category dmCategory = entitySet.FirstOrDefault(x => x.CategoryId == id);

            CategoryViewModel catVM = new CategoryViewModel();

            CategoryViewModel categoryVM = ObjectMapper.PropertyMap(dmCategory, catVM);

            return categoryVM;

        }

        protected override IList<CategoryViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            List<Category> categories = entitySet.ToList();

            List<CategoryViewModel> retList = new List<CategoryViewModel>();

            foreach (Category category in categories)
            {
                CategoryViewModel catVM = new CategoryViewModel ();


                retList.Add(ObjectMapper.PropertyMap(category, catVM));
                
            }

            return retList;
        }

        protected override IList<CategoryViewModel> Find(InnoventoryDBContext dbContext, Expression<Func<Category, bool>> predicate)
        {
            List<Category> categories = dbContext.CategorySet.Where(predicate).ToList();

            List<CategoryViewModel> retList = new List<CategoryViewModel>();

            foreach (Category category in categories)
            {
                CategoryViewModel catVM = new CategoryViewModel();


                retList.Add(ObjectMapper.PropertyMap(category, catVM));

            }

            return retList;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            CategoryViewModel categoryVM = GetEntity(dbContext,id);

            Category category = GetDomainEntity(categoryVM);

            entitySet.Remove(category);
            dbContext.SaveChanges();

            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CategoryViewModel viewModel)
        {
            Category category = GetDomainEntity(viewModel);
            dbContext.CategorySet.Add(category);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CategoryViewModel viewModel)
        {
            DbSet<Category> entitySet = dbContext.CategorySet;

            Category category = GetDomainEntity(viewModel);

            entitySet.Attach(category);

            dbContext.Entry(category).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
           
        }


    }
}
