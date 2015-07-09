using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Core.Contracts
{
    public interface IIdentifiable
    {
        Guid EntityId { get; set; }
    }
}
