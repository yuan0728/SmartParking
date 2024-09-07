using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Entities
{
    [Table("SysRole")]
    public class SysRole
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("role_name")]
        public string RoleName { get; set; }
        [Column("role_desc")]
        public string? RoleDesc { get; set; }
        [Column("state")]
        public int State { get; set; }


        [NotMapped]
        public List<RoleUser> Users { get; set; }
        [NotMapped]
        public List<RoleMenu> Menus { get; set; }
    }
}
