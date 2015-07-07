using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class UserAccountUserRoleMapViewModel
    {

        public Guid UserId { get; set; }


        public Guid UserRoleId { get; set; }



        public UserAccountViewModel UserAccounts { get; set; }

        public UserRoleViewModel UserRoles { get; set; }



    }
}
