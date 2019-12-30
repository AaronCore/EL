using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EL.Entity;

namespace EL.EntityFrameworkCore
{
    public class ELDbContext : DbContext
    {
        /*
         * EF Core文档：https://docs.microsoft.com/zh-cn/ef/core
         * 
         * 1.enable-migrations  创建迁移目录
         * 2.add-migration      名称
         * 3.update-database    更新到数据库
         * 
         */

        public ELDbContext(DbContextOptions<ELDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //表别名映射
            modelBuilder.Entity<LogEntity>().ToTable("sys_logs");
            modelBuilder.Entity<AccountEntity>().ToTable("sys_accounts");
            modelBuilder.Entity<RoleEntity>().ToTable("sys_roles");
            modelBuilder.Entity<MenuEntity>().ToTable("sys_menus");
            modelBuilder.Entity<RoleMenuEntity>().ToTable("sys_role_menus");
        }
    }
}
