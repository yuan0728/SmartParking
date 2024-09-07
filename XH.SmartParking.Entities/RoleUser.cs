using System.ComponentModel.DataAnnotations.Schema;

namespace XH.SmartParking.Entities
{
    [Table("role_user")]
    public class RoleUser
    {
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        [NotMapped]
        public SysRole SysRole { get; set; }
        [NotMapped]
        public SysUser User { get; set; }
    }
}