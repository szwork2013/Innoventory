using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class UserAccountViewModel
    {
        [Key]
        public Guid UserAccountId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid SecretQuestionID { get; set; }
        public string SecretAnswer { get; set; }
        public short UserStatusID { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<UserAccountUserRoleMapViewModel> UserAccountRoleMaps { get; set; }

    }
}
