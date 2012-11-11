using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LineaAerea.Models
{
    public class LineaAereaDB:DbContext
    {
        public DbSet<Aeropuerto> Aeropuerto { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Vuelo> Vuelo { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();   
        }
    }
}