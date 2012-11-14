using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineaAerea.Models
{
    public class Avion
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Int32 CapacidadPasajeros { get; set; }
    }
}