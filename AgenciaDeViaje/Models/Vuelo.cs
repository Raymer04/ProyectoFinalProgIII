using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Vuelo
    {
     
         public Vuelo()
        {
            this.Boleto = new HashSet<Boleto>();
        }
    
        // Primitive properties
    
        public int Id { get; set; }
        public string Procedencia { get; set; }
        public string Destino { get; set; }
        public System.DateTime Salida { get; set; }
        public System.DateTime Llegada { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<Boleto> Boleto { get; set; }
    }
}