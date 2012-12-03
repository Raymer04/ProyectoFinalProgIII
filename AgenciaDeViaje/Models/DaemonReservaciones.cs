using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace AgenciaDeViaje.Models
{
    public class DaemonReservaciones
    {
        public DaemonReservaciones()
        {
            ThreadStart job = new ThreadStart(Accion);
            Thread thread = new Thread(job);
            thread.Start();

        }

        private void Accion()
        {
            AgenciaDB db = new AgenciaDB();
            for (int i = 0; i < i + 2; i++)
            {

                try
                {
                    foreach (var b in db.Boletos.Where(p => p.tipo == 2).ToList())
                    {
                        TimeSpan diff = DateTime.Now -
                       Convert.ToDateTime(b.fecha);

                        if (diff.Days >= 2)
                        {
                            b.BoletoCargar();

                            enviarCorreo(b.Cliente.correo, "Este es un correo para informarle que su reservacion ha expirado ya que sobrepasa las 48 horas habiles");
                            db.Boletos.Remove(b);
                            db.SaveChanges();
                            foreach (var c in db.Boletos.Where(p => p.tipo == 3 && p.RefIdVuelo == b.RefIdVuelo).ToList())
                            {
                                c.BoletoCargar();
                                enviarCorreo(c.Cliente.correo, "Este es un correo para informarle que tenemos un asiento disponible para su solicitud ampliacion de vuelo");

                            }

                        }

                    }
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(300000);
            }
        }

        public void enviarCorreo(string email, string cuerpo)
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