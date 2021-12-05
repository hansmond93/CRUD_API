using CRUD_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CRUD_Infrastructure.Data
{
    public class CrudAPIContext : DbContext
    {
        public CrudAPIContext(DbContextOptions<CrudAPIContext> options) : base(options)
        {

        }

        public DbSet<Model> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
