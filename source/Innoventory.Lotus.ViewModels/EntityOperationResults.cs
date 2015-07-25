using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class EntityOperationResultBase
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }
    }

    public class UpdateResult<ViewModel>:EntityOperationResultBase
    {
        public ViewModel Entity { get; set; }

    }

    public class GetEntityResult<ViewModel> : EntityOperationResultBase
    {
        public ViewModel Entity { get; set; }
    }

    public class FindResult<ViewModel> : EntityOperationResultBase
    {
        public List<ViewModel> Entities { get; set; }

        public long Count
        {
            get
            {
                if(Entities != null && Entities.Count > 0)
                {
                    return Entities.Count;
                }

                return 0;
            }
        }
    }

    public class DeleteResult<ViewModel> : EntityOperationResultBase
    {
        public ViewModel Entity { get; set; }
    }

    public class PreCacheResult<ViewModel>: EntityOperationResultBase
    {
        public long Count { get; set; }

        public bool Caching { get; set; }
    }
}
