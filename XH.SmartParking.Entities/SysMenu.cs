using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Entities
{
    [Table("menus")]
    public class SysMenu
    {
        [Key]
        [Column("menu_id")]
        public int MenuId { get; set; }
        [Column("menu_header")]
        public string MenuHeader { get; set; }
        [Column("target_view")]
        public string? TargetView { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("menu_icon")]
        public string? MenuIcon { get; set; }
        [Column("_index")]
        public int Index { get; set; }
        [Column("menu_type")]
        public int? MenuType { get; set; }
        [Column("state")]
        public int? State { get; set; }
    }
}
