using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class UserRoleViewModel
    {

        public Guid UserRoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        public List<UserAccountUserRoleMapViewModel> UserAccountRoleMaps { get; set; }

    }
}
