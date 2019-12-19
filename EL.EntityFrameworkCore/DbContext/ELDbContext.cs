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
            // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //手动多对多映射
            modelBuilder.Entity<RoleMenuEntity>().HasKey(p => new { p.RoleId, p.MenuId });
            modelBuilder.Entity<RoleMenuEntity>().HasOne(pt => pt.Role).WithMany(p => p.RoleMenus).HasForeignKey(pt => pt.RoleId);
            modelBuilder.Entity<RoleMenuEntity>().HasOne(pt => pt.Menu).WithMany(p => p.RoleMenus).HasForeignKey(pt => pt.MenuId);
        }
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<RoleMenuEntity> RoleMenus { get; set; }
    }
}
