using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EL.Common;

namespace EL.EntityFrameworkCore
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ELDbContext>
    {
        public ELDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ELDbContext>();
            var connection = new ConfigHelper().GetValue<string>("ELConnection");
            builder.UseMySql(connection);
            return new ELDbContext(builder.Options);
        }
    }
}
