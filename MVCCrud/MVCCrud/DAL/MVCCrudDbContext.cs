using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MVCCrud.Models.CrudModel;

namespace MVCCrud.DAL
{
    public class MVCCrudDbContext:DbContext
    {
        public MVCCrudDbContext():base("MVCCrudConnection")
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}