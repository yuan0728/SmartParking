using System.ComponentModel.DataAnnotations.Schema;

namespace XH.SmartParking.Entities
{
    [Table("role_menu")]
    //[PrimaryKey("RoleId", "MenuId")]  // EFCore7.0及以后版本
    public class RoleMenu
    {
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("menu_id")]
        public int MenuId { get; set; }

        [NotMapped]
        public SysRole SysRole { get; set; }
    }
}