using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Innoventory.Lotus.Core.Extensions;

namespace Innoventory.Lotus.Core
{
    public class MefDependencyResolver
    {
        CompositionContainer _container;
        public MefDependencyResolver(CompositionContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.GetExportedValueByType(serviceType);
        }


        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetExportedValuesByType(serviceType);
        }
    }
}
