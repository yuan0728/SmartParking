using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Entities
{
    public class SysUser
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string? RealName { get; set; }

        public string? Password { get; set; }
        public string? Avatar { get; set; }

        public int? Status { get; set; }

        public int? Age { get; set; }

        public int? Gender { get; set; }

        public string? UserIcon { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Qq { get; set; }

        public string? WeChat { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        public int? LastModifyId { get; set; }

        //[NotMapped]
        //public List<RoleUser> Roles { get; set; }
    }
}
