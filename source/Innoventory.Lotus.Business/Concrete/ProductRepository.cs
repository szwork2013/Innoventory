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
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductRepository : GenericRepository<Product, ProductViewModel>, IProductRepository
    {


        protected Product GetDomainEntity(ProductViewModel viewModel)
        {
            Product product = GetProduct(viewModel);

            return product;
        }

        private Product GetProduct(ProductViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            Product product = new Product
            {
                CategorySubCategoryMapId = viewModel.CategorySubCategoryMapId,
                Description = viewModel.Description,
                ImageId = viewModel.ImageId,
                ItemType = viewModel.ItemType,
                ModifiedOn = DateTime.Now,
                ProductId = viewModel.ProductId,
                ProductName = viewModel.ProductName,
                Remarks = viewModel.Remarks,
                VolumeMeasureId = viewModel.VolueMeasureId,
            };
           

            return product;

        }

        private ProductViewModel GetProductViewModel(Product product)
        {
            if (product == null)
                return null;

            ProductViewModel productViewModel = new ProductViewModel
            {
                CategorySubCategoryMapId = product.CategorySubCategoryMapId,
                Description = product.Description,
                ImageId = product.ImageId,
                ItemType = product.ItemType,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Remarks = product.Remarks,
                VolueMeasureId = product.VolumeMeasureId,
            };

            return productViewModel;
        }

        protected override ProductViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Product> entitySet = dbContext.ProductSet;

            Product dmProduct = entitySet.FirstOrDefault(x => x.ProductId == id);

            ProductViewModel productVM = GetProductViewModel(dmProduct);

            return productVM;

        }

        protected override List<ProductViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Product> entitySet = dbContext.ProductSet;

            List<Product> products = entitySet.ToList();

            List<ProductViewModel> retList = new List<ProductViewModel>();

            foreach (Product product in products)
            {
                ProductViewModel pVM = GetProductViewModel(product);

                retList.Add(ObjectMapper.PropertyMap(product, pVM));

            }

            return retList;
        }

        protected override List<ProductViewModel> Find(InnoventoryDBContext dbContext, Func<ProductViewModel, bool> predicate)
        {

            List<ProductViewModel> products = (GetEntities(dbContext)).Where(predicate).ToList();

            return products;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Product> entitySet = dbContext.ProductSet;

            //ProductViewModel productVM = GetEntity(dbContext, id);


            Product product = entitySet.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                entitySet.Remove(product);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductViewModel viewModel)
        {
            Product product = GetDomainEntity(viewModel);
            dbContext.ProductSet.Add(product);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductViewModel viewModel)
        {
            DbSet<Product> entitySet = dbContext.ProductSet;

            Product product = GetDomainEntity(viewModel);

            entitySet.Attach(product);

            dbContext.Entry(product).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }
    }
}
