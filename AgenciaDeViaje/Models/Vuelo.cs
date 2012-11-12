﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Vuelo
    {
        public int Id { get; set; }
        public int Procedencia {get; set; }
        public int Destino { get; set; }
        public DateTime Salida { get; set; }
        public DateTime Llegada { get; set; }
    
    }
}