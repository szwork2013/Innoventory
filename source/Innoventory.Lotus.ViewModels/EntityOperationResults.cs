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
    }

    public class DeleteResult<ViewModel> : EntityOperationResultBase
    {
        public ViewModel Entity { get; set; }
    }
}
