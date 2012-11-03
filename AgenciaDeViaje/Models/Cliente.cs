using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public DateTime fechaDeNacimiento { get; set;}
        public string correo { get; set; }
        public string password { get; set; }
        public List<Boleto> boletosComprados { get; set; }
        public List<Boleto> reservaciones { get; set; }
        public List<Boleto> espera { get; set; }
       

    }
}