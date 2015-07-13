using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class UserRoleViewModel:IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid UserRoleId { get; set; }

        [DisplayName("Role Name")]
        [DataMember]
        public string RoleName { get; set; }

        [DisplayName("Role Description")]
        [DataMember]
        public string RoleDescription { get; set; }
        
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }
        
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        
        [DataMember]
        public Guid ModifiedBy { get; set; }

        public List<UserAccountUserRoleMapViewModel> UserAccountRoleMaps { get; set; }


        public Guid EntityId
        {
            get
            {
                return UserRoleId;
            }
            set
            {
                UserRoleId = value;
            }
        }
    }
}
