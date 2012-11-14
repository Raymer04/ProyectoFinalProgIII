using System;
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

        public int ProcedenciaID { get; set; }
        public Aeropuerto Procedencia { get; set; }

        public int DestinoID { get; set; }
        public Aeropuerto Destino { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaSalida { get; set; }

        public String HoraSalida { get; set; }
       
        public Int32 Duracion { get; set; }

        public int AvionID { get; set; }
        public Avion Avion { get; set;}
    }
}