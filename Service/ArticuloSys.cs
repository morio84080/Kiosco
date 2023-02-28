using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Articulo.Business;
using Articulo.Entities;
using Movimiento.Business;
using System.Web.Script.Serialization;

namespace Service
{
    public class ArticuloSys
    {
        static string response = string.Empty;
        public static string GetArticuloPorCodBarra(string barCode)
        {

            try
            {
                ArticuloBUS sys = new ArticuloBUS();
                MovimientoBus movBus = new MovimientoBus();
                response = "0|";
                ArticuloEntity entity = new ArticuloEntity();
                entity = sys.getArticuloPorCodBarra(barCode);

                string fechaUpd=string.Empty;
                try
                {
                    fechaUpd = movBus.getLastMovementUpdatedByProduct(entity.IDArti).FechaMovi.ToString("dd-MM-yyyy");
                }
                catch {
                    fechaUpd=string.Empty;
                }


                response += entity.RubrArti + "^" + entity.DescRubro + "^" + entity.DescArti + "^" + entity.BaseArti + "^" + entity.SugeArti + "^" + entity.StockArti + "^" + entity.IDArti + "^" + entity.PorcGananciaArti + "^" + entity.porcIVAArti + "^" + fechaUpd ;

            }
            catch (Exception ex)
            {
                response = "-1|" + ex.Message;
            }
            return response;
        }

        //public string ArticuloUpdate(string DescArti, string BaseArti, string PorcGananciaArti, string PorcIvaArti, string SugeArti, int IdArti, int userId) 
        public string ArticuloUpdate(string DescArti, double BaseArti, double PorcGananciaArti, decimal PorcIvaArti, double SugeArti, int IdArti, int userId)         
        {
            try 
            {
                //double baseArti = double.Parse( BaseArti);
                //double porcGanancia = double.Parse(PorcGananciaArti);
                //decimal porcIva = Convert.ToDecimal(PorcIvaArti);
                //double suge = double.Parse(SugeArti);

                response = "0|Registro guardado con éxito!!";
                ArticuloBUS sys = new ArticuloBUS();
                ArticuloEntity artOld = new ArticuloEntity();
                ArticuloEntity art = new ArticuloEntity();
                art = sys.getArticuloID(IdArti);
                artOld = sys.getArticuloID(IdArti);
                art.BaseArti = BaseArti;// baseArti;
                art.DescArti = DescArti;
                art.PorcGananciaArti = PorcGananciaArti;// porcGanancia;
                art.porcIVAArti = PorcIvaArti;// porcIva;
                art.PrintArti = true;
                art.SugeArti = SugeArti; //suge;

                sys.ArticuloUpdate(art, artOld, userId);

            }
            catch (Exception ex)
            {
                response = "-1|" + ex.Message;
            }

            return response;
        }
    }
}
