using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.UI.WebControls;


namespace ServicioWeb
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/servicioCom", Name = "ServicioDeComunicacion", Description = "web service de comunicacion Proyecto Final")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioDeComunicacion : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Vuelo> VuelosVuelta(int procedencia, int destino, DateTime fechaS, DateTime fechaLl)
        {

            LineaAereaEntities lineab = new LineaAereaEntities();
            List<Vuelo> vuelos = null;
            if (fechaLl != null)
            {
                vuelos = lineab.Vueloes.Where(v => v.Aeropuerto.Id == procedencia && v.Aeropuerto1.Id == destino
                   && v.FechaSalida == fechaLl).ToList();

            }
            return vuelos;
        }

        [WebMethod]
        public List<Vuelo> VuelosIda(int procedencia, int destino, DateTime fechaS)
        {

            LineaAereaEntities lineab = new LineaAereaEntities();
            List<Vuelo> vuelos = null;
            if (fechaS != null)
            {
                vuelos = lineab.Vueloes.Where(v => v.Aeropuerto.Id == destino && v.Aeropuerto1.Id == procedencia
                   && v.FechaSalida == fechaS).ToList();
            }
            return vuelos;
        }


        [WebMethod]
        public List<Aeropuerto> Aeropuertos()
        {
            LineaAereaEntities lineab = new LineaAereaEntities();

            List<Aeropuerto> aeropuertos = lineab.Aeropuertoes.ToList();

            return aeropuertos;
        }

        [WebMethod]
        public List<Vuelo> TodosVuelos()
        {

            LineaAereaEntities lineab = new LineaAereaEntities();


            List<Vuelo> vuelos = lineab.Vueloes.ToList();

            return vuelos;
        }

        [WebMethod]
        public int asientosDisponibles(int idVuelo)
        {
            AgenciaViajeEntities ave = new AgenciaViajeEntities();
            LineaAereaEntities le = new LineaAereaEntities();
            int idAvion = (int)le.Vueloes.Where(p => p.Id == idVuelo).First().AvionReference.EntityKey.EntityKeyValues.First().Value;
            int primero=le.Avions.Where(p=>p.Id==idAvion).First().CapacidadPasajeros;
            int segundo = ave.Boletoes.Where(p => p.RefIdVuelo == idVuelo && p.tipo!=3).Count();
            int retorno = primero - segundo;
            TimeSpan salida;
            TimeSpan.TryParse(le.Vueloes.Where(p => p.Id == idVuelo).First().HoraSalida,out salida);
            if(le.Vueloes.Where(p=>p.Id==idVuelo).First().FechaSalida<DateTime.Now.Date && salida<DateTime.Now.TimeOfDay){
                retorno = 0;
            }
            return retorno;
        }
        [WebMethod]
        public bool disponbilidadVuelo(int idVuelo) {
            LineaAereaEntities le = new LineaAereaEntities();
            TimeSpan salida;
            TimeSpan.TryParse(le.Vueloes.Where(p => p.Id == idVuelo).First().HoraSalida, out salida);
            if (le.Vueloes.Where(p => p.Id == idVuelo).First().FechaSalida < DateTime.Now.Date && salida < DateTime.Now.TimeOfDay)
            {
                return false;
            }
            return true;
        }

    }
}