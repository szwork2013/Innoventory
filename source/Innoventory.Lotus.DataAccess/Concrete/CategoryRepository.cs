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



        protected override CategoryViewModel GetEntity( Guid id)
        {
            DbSet<Category> entitySet = DbContext.CategorySet;

            Category dmCategory = entitySet.FirstOrDefault(x => x.CategoryId == id);

            CategoryViewModel catVM = new CategoryViewModel();

            CategoryViewModel categoryVM = ObjectMapper.PropertyMap(dmCategory, catVM);

            return categoryVM;

        }

        protected override IList<CategoryViewModel> GetEntities()
        {
            DbSet<Category> entitySet = DbContext.CategorySet;

            List<Category> categories = entitySet.ToList();

            List<CategoryViewModel> retList = new List<CategoryViewModel>();

            foreach (Category category in categories)
            {
                CategoryViewModel catVM = new CategoryViewModel ();


                retList.Add(ObjectMapper.PropertyMap(category, catVM));
                
            }

            return retList;
        }

        protected override IList<CategoryViewModel> Find(Expression<Func<Category, bool>> predicate)
        {
            List<Category> categories = DbContext.CategorySet.Where(predicate).ToList();

            List<CategoryViewModel> retList = new List<CategoryViewModel>();

            foreach (Category category in categories)
            {
                CategoryViewModel catVM = new CategoryViewModel();


                retList.Add(ObjectMapper.PropertyMap(category, catVM));

            }

            return retList;
        }

        protected override void DeleteEntity( Guid id)
        {
            DbSet<Category> entitySet = DbContext.CategorySet;

            CategoryViewModel categoryVM = GetEntity(id);

            Category category = GetDomainEntity(categoryVM);

            entitySet.Remove(category);
            DbContext.SaveChanges();
        }

        protected override bool AddEntity( CategoryViewModel viewModel)
        {
            Category category = GetDomainEntity(viewModel);
            DbContext.CategorySet.Add(category);

            DbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(CategoryViewModel viewModel)
        {
            DbSet<Category> entitySet = DbContext.CategorySet;

            Category category = GetDomainEntity(viewModel);

            entitySet.Attach(category);

            DbContext.Entry(category).State = EntityState.Modified;

            DbContext.SaveChanges();

            return true;
            
        }


    }
}
