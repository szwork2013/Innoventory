using Innoventory.Lotus.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Bootsraper
{
    public class DependencyContainer
    {
        public static CompositionContainer Initialize(AggregateCatalog catalog)
        {

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AddressRepository).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
