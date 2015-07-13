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
    public class UserAccountViewModel:IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid UserAccountId { get; set; }

        [DisplayName("User Name")]
        [DataMember]
        public string UserName { get; set; }

        [DisplayName("Email ID")]
        [DataMember]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataMember]
        public string Password { get; set; }

        [DisplayName("Secret Question ID")]
        [DataMember]
        public Guid SecretQuestionID { get; set; }

        [DisplayName("Secret Question Answer")]
        [DataMember]
        public string SecretAnswer { get; set; }
        
        [DisplayName("User Status ID")]
        [DataMember]
        public short UserStatusID { get; set; }

        [DisplayName("Contact 1")]
        [DataMember]
        public string Contact1 { get; set; }

        [DisplayName("Contact 2")]
        [DataMember]
        public string Contact2 { get; set; }
        
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }

        public List<UserAccountUserRoleMapViewModel> UserAccountRoleMaps { get; set; }


        public Guid EntityId
        {
            get
            {
                return UserAccountId;
            }
            set
            {
                UserAccountId = value;
            }
        }
    }
}
