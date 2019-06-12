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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Data Source=localhost;port=3306;sslmode=none;Initial Catalog=ilvbu;user id=root;password=Cpic1234;charset=utf8");//配置连接字符串
        }

    }
}
