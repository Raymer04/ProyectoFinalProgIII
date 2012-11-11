using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public Vuelo vuelo { get; set; }
        public int tipo { get; set; }
    }

}