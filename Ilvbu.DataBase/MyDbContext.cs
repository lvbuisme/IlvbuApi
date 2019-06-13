using Ilvbu.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.DataBase
{
    public class MyDbContext : DbContext
    {

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet< WxLoginRecord> WxLoginRecord { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseMySql("Data Source=ilvbu.xyz;port=3306;sslmode=none;Initial Catalog=ilvbu;user id=root;password=123456;charset=utf8");//配置连接字符串
        //}

        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
