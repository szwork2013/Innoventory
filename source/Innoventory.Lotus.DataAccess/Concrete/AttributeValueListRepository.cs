using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    [Export(typeof(IAttributeValueListRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttributeValueListRepository : GenericRepository<AttributeValueList>, IAttributeValueListRepository
    {
        public Address FindById(Guid attributeValueId)
        {
            return GetAll().FirstOrDefault(x => x.AttributeValueListId == attributeValueId);
        }
    }
}
