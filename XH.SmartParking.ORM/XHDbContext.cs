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
            // 转换器 页面 --> 数据库的转换
            // 数据库-- > 页面的转换
            // 转换图标 十六进制的转换 &#xe7ff;
            // 第一种写法
            //ValueConverter iconValueConverter = new ValueConverter<string, string>(
            //    m2d => string.IsNullOrEmpty(m2d) ? null : ((int)m2d.ToArray()[0]).ToString("x"),
            //    d2m => d2m == null ? "" : ((char)int.Parse(d2m, NumberStyles.HexNumber)).ToString());
            // 第二种写法
            //ValueConverter iconValueConverter = new ValueConverter<string, string>(
            //    // 返回整数后的十六进制字符串表示（小写）存入数据库。
            //    m2d => string.IsNullOrEmpty(m2d) ? null : (int.Parse(m2d)).ToString("x"),
            //    // 返回十六进制整数后对应的Unicode字符的字符串表示 显示界面上
            //    d2m => string.IsNullOrEmpty(d2m) ? "" : ((char)int.Parse(d2m, NumberStyles.HexNumber)).ToString());
            // 第三种写法
            ValueConverter iconValueConverter = new ValueConverter<string, string>(
                // 返回整数后的十六进制字符串表示（小写）存入数据库。
                m2d => string.IsNullOrEmpty(m2d) ? null : ((int)m2d.ToArray()[0]).ToString("x"),
                // 返回十六进制整数后对应的Unicode字符的字符串表示 显示界面上
                d2m => string.IsNullOrEmpty(d2m) ? null : ((char)Convert.ToInt32(d2m, 16)).ToString());
            modelBuilder.Entity<SysMenu>()
                .Property(m => m.MenuIcon)
                .HasConversion(iconValueConverter);
        }


        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
    }
}
