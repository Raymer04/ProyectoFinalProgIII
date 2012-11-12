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
        public List<Vuelo> VuelosDisponibles(String procedencia, String destino, DateTime fecha)
        {
            LineaEntities lineab = new LineaEntities();

            List<Vuelo> vuelos = lineab.Vueloes.Where(v => v.Aeropuerto1.Lugar == destino && v.Aeropuerto.Lugar == procedencia).ToList();
           
            return vuelos;
        }

        [WebMethod]
        public List<Aeropuerto> Aeropuertos()
        {
            LineaEntities lineab = new LineaEntities();

            List<Aeropuerto> aeropuertos = lineab.Aeropuertoes.ToList();

            return aeropuertos;
        }



        [WebMethod]
        public List<Vuelo> TodosVuelos()
        {

            LineaEntities lineab = new LineaEntities();


            List<Vuelo> vuelos = lineab.Vueloes.ToList();

            return vuelos;
        }

        [WebMethod]
        public int asientosDisponibles(int idVuelo)
        {

            int disponibles = 1;

            return disponibles;
        }
    }
}