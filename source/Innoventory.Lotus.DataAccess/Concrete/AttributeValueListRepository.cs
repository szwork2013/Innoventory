using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IAttributeValueListRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttributeValueListRepository : GenericRepository<AttributeValueList>, IAttributeValueListRepository
    {
        public AttributeValueList FindById(Guid attributeValueId)
        {
            return GetAll().FirstOrDefault(x => x.AttributeValueListId == attributeValueId);
        }
    }
}
