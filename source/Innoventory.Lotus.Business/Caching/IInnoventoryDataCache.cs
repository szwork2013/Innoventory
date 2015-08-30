using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.Repository
{
    public interface IInnoventoryDataCache<T>
    {
       PreCacheResult<T> RunPrecache();

    }
}
