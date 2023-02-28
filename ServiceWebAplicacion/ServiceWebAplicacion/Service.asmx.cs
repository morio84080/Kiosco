using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Service;
using Conexion;

namespace ServiceWebAplicacion
{

   

    /// <summary>
    /// Descripción breve de ServicioClientes
    /// </summary>
    [WebService(Namespace = "http://mywaysoft.com/")]   //puedes cambiar esta direccion
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]        

    public class ServicioClientes : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetArticuloPorCodBarra(string barCode)
        {

            return Service.ArticuloSys.GetArticuloPorCodBarra(barCode);
        }
        
        [WebMethod]
        //public string UpdateArticulo(string DescArti, string BaseArti, string PorcGananciaArti, string PorcIvaArti, string SugeArti, int IdArti, int userId)
        public string UpdateArticulo(string DescArti, double BaseArti, double PorcGananciaArti, double PorcIvaArti, double SugeArti, int IdArti, int userId)        
        {
            Service.ArticuloSys artSys = new ArticuloSys();
            return artSys.ArticuloUpdate(DescArti, BaseArti, PorcGananciaArti, (decimal)PorcIvaArti, SugeArti, IdArti, userId);
        }
    

    }
}
