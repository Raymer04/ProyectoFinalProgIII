using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                new System.Threading.TimerCallback(Accion), null, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0,0,10, 0));


        }

        private void Accion(object state){

            string basedirectory = AppDomain.CurrentDomain.BaseDirectory;

            string config_path = System.IO.Path.Combine(basedirectory, "Config-lapso.xml");

            System.Xml.Linq.XDocument config = System.Xml.Linq.XDocument.Load(config_path);

            TimeSpan diff = DateTime.Now -
            Convert.ToDateTime(config.Root.Element("ultima-hora").Value);

            if (diff.Seconds >= 10)
            {
                System.Diagnostics.Process.Start(@"D:\WINDOWS\NOTEPAD.EXE");
            } 


}


    }
}