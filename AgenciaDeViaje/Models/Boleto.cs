using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaDeViaje.Models
{
    public class Boleto
    {
        
        public int Id { get; set; }
        public int tipo { get; set; }
        public int RefIdCliente { get; set; }
        public int RefIdVuelo { get; set; }
        // Navigation properties

        public virtual Cliente Cliente { get; set; }
        public virtual Vuelo Vuelo { get; set; }
        public Boleto(){
        if(Id!=0){
            this.BoletoCargar();
    }
        }
        

        public void BoletoCargar()
        {
            AgenciaDB db=new AgenciaDB();
            ServicioWeb.ServicioDeComunicacionSoapClient servicio = new ServicioWeb.ServicioDeComunicacionSoapClient();
            Cliente = db.Clientes.Where(p=>p.Id==RefIdCliente).First();
            Vuelo vueloAux = new Vuelo();
            var aux =servicio.TodosVuelos().Where(p => p.Id == RefIdVuelo).First();
            vueloAux.Id=aux.Id;
            vueloAux.Destino=servicio.Aeropuertos().Where(a=>a.Id==(Int32)aux.DestinoReference.EntityKey.EntityKeyValues.First().Value).First().Lugar ;
            vueloAux.Procedencia = servicio.Aeropuertos().Where(a => a.Id == (Int32)aux.ProcedenciaReference.EntityKey.EntityKeyValues.First().Value).First().Lugar;
            vueloAux.Salida=aux.Salida;
            vueloAux.Llegada=aux.Llegada;
            Vuelo = vueloAux;
            
        }
    }

}