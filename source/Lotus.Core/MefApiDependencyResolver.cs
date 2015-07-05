using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Innoventory.Lotus.Core.Extensions;
using System.Web.Http.Dependencies;

namespace Innoventory.Lotus.Core
{
    public class MefApiDependencyResolver : IDependencyResolver
    {
        CompositionContainer _container;
        public MefApiDependencyResolver(CompositionContainer container)
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

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
