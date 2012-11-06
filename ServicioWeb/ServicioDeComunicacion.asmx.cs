﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

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
        public DataTable VuelosDisponibles(String procedencia, String destino, DateTime fecha)
        {
            LineaAereaEntities lineab = new LineaAereaEntities();

            DataTable vuelos = null;//lineab.Vuelos.Where(v => v.Destino.Lugar == destino && v.Procedencia.Lugar == procedencia);
            return vuelos;
        }
    }
}