﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LineaAerea.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        public Aeropuerto Procedencia { get; set; }
        public Aeropuerto Destino { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Salida")]
        public DateTime Salida { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Llegada")]
        public DateTime Llegada { get; set; }

        public Avion Avion { get; set;}
    }
}