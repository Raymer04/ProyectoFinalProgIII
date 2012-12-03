using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AgenciaDeViaje.Models;

namespace AgenciaDeViaje
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Application["MyThread"] = new System.Threading.Timer(
                new System.Threading.TimerCallback(Accion), null, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 10, 0)); 

            

        }

        private void Accion(object state)
        {
            AgenciaDB db = new AgenciaDB();
            try
            {
                //foreach (var b in db.Boletos.ToList())
                //{
                //    TimeSpan diff = DateTime.Now -
                //   Convert.ToDateTime(b.fecha);

                //    if (diff.Days >= 10)
                //    {
                //        enviarCorreo(db.Clientes.Where(c => c.Id == b.RefIdCliente && b.tipo == 3).First().correo, "Este es un correo para informarle que su reservacion ha expirado ya que sobrepasa las 48 horas habiles");
                //        Boleto boleto = db.Boletos.Where(c => c.Id == b.RefIdCliente && b.tipo == 3).First();
                //        db.Boletos.Remove(boleto);
                //        db.SaveChanges();
                //        db.SaveChanges();
                //        enviarCorreo(db.Clientes.Where(c => c.Id == b.RefIdCliente && b.tipo == 2).First().correo, "Este es un correo para informarle que tenemos un asiento disponible para su solicitud ampliacion de vuelo");
                //    }

                //}


                //foreach (var b in db.Boletos.Where(a => a.tipo == 3).ToList())
                //{
                //    TimeSpan diff = DateTime.Now -
                //   Convert.ToDateTime(b.fecha);
 
          
                //   if (diff.Seconds >= 10)
                //   {
                //        enviarCorreo(db.Clientes.Where(c=>c.Id==b.RefIdCliente).First().correo,"klk");
                //    }
 
                //}
                      enviarCorreo("saby.decrease@gmail.com");
            }
            catch (Exception ex) {
                
             Response.Redirect("Error.cshtml?source="+  
              HttpUtility.UrlEncode(Request.AppRelativeCurrentExecutionFilePath));
 

 

            }
            
        }



        public void enviarCorreo(string email)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress("aerocaribedom@gmail.com");
            correo.To.Add(email);
            correo.Subject = "Correo de lista de espera";
            correo.Body = "Este es un correo de aviso para informale que su reservacion ha expirado, ya que sobrepasa las 48 horas en lista de espera";
            correo.Body = string.Format("Enviado las {0}:{1} a traves de Aero Caribe",DateTime.Now.Hour,DateTime.Now.Minute);
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

       
        
