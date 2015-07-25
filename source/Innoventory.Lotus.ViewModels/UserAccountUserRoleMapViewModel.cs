using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class UserAccountUserRoleMapViewModel:IIdentifiable
    {

        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }


        public Guid UserRoleId { get; set; }

        
        public UserAccountViewModel UserAccounts { get; set; }

        public UserRoleViewModel UserRoles { get; set; }




        public Guid EntityId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
