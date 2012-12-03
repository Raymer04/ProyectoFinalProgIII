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
        public List<Vuelo> VuelosIdaVuelta(int procedencia, int destino, DateTime fechaS,DateTime fechaLl)
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

            Application["MyThread"] = new System.Threading.Timer(
                new System.Threading.TimerCallback(Accion), null, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 10, 0));          
            AgenciaViajeEntities ave = new AgenciaViajeEntities();
            LineaAereaEntities le = new LineaAereaEntities();
            int idAvion = (int)le.Vueloes.Where(p => p.Id == idVuelo).First().AvionReference.EntityKey.EntityKeyValues.First().Value;
            int primero=le.Avions.Where(p=>p.Id==idAvion).First().CapacidadPasajeros;
            int segundo = ave.Boletoes.Where(p => p.RefIdVuelo == idVuelo && p.tipo!=3).Count();
            int retorno = primero - segundo;
            return 0;
        }

        private void Accion(object state)
        {
            AgenciaViajeEntities db = new AgenciaViajeEntities();
            try
            {
                foreach (var b in db.Boletoes.ToList())
                {
                    TimeSpan diff = DateTime.Now -
                   Convert.ToDateTime(b.fecha);

                    if (diff.Days >= 10)
                    {
                        enviarCorreo(db.Clientes.Where(c => c.Id == b.RefIdCliente && b.tipo == 3).First().correo, "Este es un correo para informarle que su reservacion ha expirado ya que sobrepasa las 48 horas habiles");
                        Boleto boleto = db.Boletoes.Where(c => c.Id == b.RefIdCliente && b.tipo == 3).First();
                        db.DeleteObject(boleto);
                        db.SaveChanges();
                        enviarCorreo(db.Clientes.Where(c => c.Id == b.RefIdCliente && b.tipo == 2).First().correo, "Este es un correo para informarle que tenemos un asiento disponible para su solicitud ampliacion de vuelo");
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }



        public void enviarCorreo(string email,string cuerpo)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress("aerocaribedom@gmail.com");
            correo.To.Add(email);
            correo.Subject = "Correo de lista de espera";
            correo.Body = cuerpo;
            correo.IsBodyHtml = false;
            correo.Priority = System.Net.Mail.MailPriority.Normal;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("aerocaribedom@gmail.com", "aero0000");
            smtp.Send(correo);

        }
    }
}