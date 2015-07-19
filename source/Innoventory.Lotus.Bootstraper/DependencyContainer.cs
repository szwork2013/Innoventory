using Innoventory.Lotus.Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.BusinessTransition;

namespace Innoventory.Lotus.Bootsraper
{
    public class DependencyContainer
    {
        public static CompositionContainer Initialize(AggregateCatalog catalog)
        {

            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(AddressRepository).Assembly));

            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(AttributeValueListRepository).Assembly));

            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(SubCategoryRepository).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(CategoryRepository).Assembly));

            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(CategorySubCategoryMapRepository).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SubCategoryTransition).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
