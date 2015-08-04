using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Core;
using Innoventory.Lotus.Database;

namespace Innoventory.Lotus.Business
{
    public class InnoventoryDataCache<T> : IInnoventoryDataCache<T>
    {

        public PreCacheResult<T> RunPrecache()
        {
            throw new NotImplementedException();
        }
    }
}
