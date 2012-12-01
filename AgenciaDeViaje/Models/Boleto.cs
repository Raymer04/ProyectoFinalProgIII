using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public int tipo { get; set; }

        // Navigation properties

        public virtual Cliente Cliente { get; set; }
        public virtual Vuelo Vuelo { get; set; }
    }

}