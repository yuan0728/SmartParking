using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 转换器  数据库-->页面的转换
            // 页面 --> 数据库的转换
            // 转换图标 十六进制的转换
            ValueConverter iconValueConverter = new ValueConverter<string, string>(
                p2d => string.IsNullOrEmpty(p2d) ? null : ((int)p2d.ToArray()[0]).ToString("x"),
                d2p => d2p == null ? "" : ((char)int.Parse(d2p, NumberStyles.HexNumber)).ToString());
            modelBuilder.Entity<SysMenu>()
                .Property(m => m.MenuIcon)
                .HasConversion(iconValueConverter);
        }


        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
    }
}
