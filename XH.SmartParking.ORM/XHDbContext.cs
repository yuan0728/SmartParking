using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;

namespace XH.SmartParking.ORM
{
    public class XHDbContext : DbContext
    {
        public XHDbContext(DbContextOptions<XHDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=LITTLESEAPAD;Initial Catalog=XHSmartParking;Persist Security Info=True;User ID=sa;Password=abc123;Trust Server Certificate=True");
        }

        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
    }
}
