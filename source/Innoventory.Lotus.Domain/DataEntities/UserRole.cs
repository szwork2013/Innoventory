using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class UserRole
    {
        [Key]
        public Guid UserRoleId { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }
        [StringLength(100)]
        public string RoleDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        public virtual List<UserAccountUserRoleMap> UserAccountRoleMaps { get; set; }

    }
}
