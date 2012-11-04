using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace AgenciaDeViaje.Models
{
    public class AgenciaDB: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Vuelo> Vueloes { get; set; }
    }
}