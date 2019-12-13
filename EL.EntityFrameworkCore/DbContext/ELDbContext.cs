using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EL.Entity;

namespace EL.EntityFrameworkCore
{
    public class ELDbContext : DbContext
    {
        public ELDbContext(DbContextOptions<ELDbContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        public DbSet<LogEntity> Logs { get; set; }
    }
}
