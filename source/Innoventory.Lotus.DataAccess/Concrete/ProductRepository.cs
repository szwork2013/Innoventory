using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductRepository : GenericRepository<Product, ProductViewModel>, IProductRepository
    {

       
    }
}
