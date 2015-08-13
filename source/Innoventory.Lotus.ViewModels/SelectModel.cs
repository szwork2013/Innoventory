using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class SelectEntityModel<Entity> where Entity : class, IIdentifiable, IDisplayName, new()
    {
        [DataMember(Name = "entityId")]
        public Guid EntityId { get; set; }

        [DataMember(Name = "entityName")]
        public string EntityName { get; set; }

        public SelectEntityModel(Entity entity)
        {
            EntityId = entity.EntityId;

            EntityName = entity.DisplayName;//entity.GetType().GetProperty(nameProperty).GetValue(entity).ToString();
        }
    }


    public class SelectEntityModelListResult<Entity> : GetEntityResult<Entity> where Entity : class, IIdentifiable, IDisplayName, new()
    {
        private List<SelectEntityModel<Entity>> _entityList;
        public List<SelectEntityModel<Entity>> EntityList { get { return _entityList; } }

        public SelectEntityModelListResult(List<Entity> entityList)
        {
            _entityList = new List<SelectEntityModel<Entity>>();

            foreach (var item in entityList)
            {
                AddEntity(item);
            }
        }
        public Entity AddEntity(Entity entity)
        {
            _entityList.Add(new SelectEntityModel<Entity>(entity));

            return entity;
        }

    }
}
