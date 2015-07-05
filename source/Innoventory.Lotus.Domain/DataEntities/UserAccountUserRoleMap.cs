using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class UserAccountUserRoleMap
    {
        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }


        [Key]
        [Column(Order = 2)]
        public Guid UserRoleId { get; set; }


        [ForeignKey("UserId")]
        public virtual UserAccount UserAccounts { get; set; }


        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRoles { get; set; }



    }
}
