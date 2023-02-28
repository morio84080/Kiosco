using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Articulo.DataAccess;
using Articulo.Entities;
using System.Windows.Forms;
using Movimiento.DataAccess;
using Movimiento.Entities;
using Stock.DataAccess;
using Stock.Entities;

namespace Articulo.Business
{
    public class ArticuloBUS
    {
        public int LlenarComboArticulo(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ArticuloGetCombo_DT();
                cbo.DisplayMember = "DESCARTI";
                cbo.ValueMember = "IDARTI";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Articulo");
                return -1;

            }

        }

        public DataTable ArticuloGetCombo_DT()
        {
            ArticuloDALC DALC = new ArticuloDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public DataTable getAllArticulos_DT()
        {
            return new ArticuloDALC().DS_GetAll().Tables[0];
        }

        public ArticuloEntity getArticuloID(int ID)
        {
            return new ArticuloDALC().GetByID(ID);
        }

        public ArticuloEntity getArticuloPorCodBarra(string codigo)
        {
            if (codigo.Length == 13 && codigo.Substring(0, 2) == "20")
            {
                ArticuloEntity articulo = new ArticuloDALC().GetByBarCode(codigo.Substring(0,7));
                if (articulo != null)
                {
                    //double kgs = Math.Round(Convert.ToDouble(codigo.Substring(7, 6)) / 10000, 3);
                    //double importe = kgs * articulo.SugeArti;
                    double importe = Math.Round(Convert.ToDouble(codigo.Substring(7, 6)) / 1000, 3);
                    //articulo.SugeArti = Math.Round(importe, 2,MidpointRounding.AwayFromZero);
                    articulo.SugeArti = Truncate(importe,2);
                }
                else articulo = new ArticuloDALC().GetByBarCode(codigo);

                return articulo;
            }
            else
                return new ArticuloDALC().GetByBarCode(codigo);
        }

        public static double Truncate(double value, int decimalPlaces)
        {
            double integralValue = Math.Truncate(value);

            double fraction = value - integralValue;

            int factor = (int)Math.Pow(10, decimalPlaces);

            double truncatedFraction = Math.Truncate(fraction * factor) / factor;

            double result = integralValue + truncatedFraction;

            return result;
        } 
        public DataTable getByLikeDesc_DT(string Descripcion)
        {
            return new ArticuloDALC().DS_GetByLikeDesc(Descripcion).Tables[0];
        }

        public DataTable getByRubroAndLikeDesc_DT(string Descripcion, int rubro)
        {
            return new ArticuloDALC().DS_GetByRubroAndLikeDesc(Descripcion,rubro).Tables[0];
        }
        
        public DataTable getByRubro_DT(int CodiRubro)
        {
            return new ArticuloDALC().DS_GetByRubro(CodiRubro).Tables[0];
        }

        public DataTable getByRubros_DT(string rubros)
        {
            return new ArticuloDALC().DS_GetByRubros(rubros).Tables[0];
        }
        public DataTable getByCodBarra_DT(string CodBarra)
        {
            return new ArticuloDALC().DS_GetByCodBarra(CodBarra).Tables[0];
        }

        public DataTable getByPrint_DT()
        {
            return new ArticuloDALC().DS_GetByPrint().Tables[0];
        }

        public ArticuloEntity getByCodiAndRubro_DT(int CodiRubro, int Codigo)
        {
            return new ArticuloDALC().GetByCodiAndRubro(CodiRubro, Codigo);
        }
        public void ArticuloInsert(ArticuloEntity Ety, int userId)
        {
            ArticuloDALC ArtDac = new ArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();
            StockEntity stock = new StockEntity();
            StockDALC stockDac = new StockDALC();
            
            
            try
            {
                ArtDac.BeginTrans();
                movDac.BindTrans(ArtDac.ActiveConnection, ArtDac.ActiveTransaction);
                stockDac.BindTrans(ArtDac.ActiveConnection, ArtDac.ActiveTransaction);
                
                //Graba Nuevo Articulo
                int ArticuloID= ArtDac.Insert(Ety);

                //Crea Movimiento de Stock Inicial
                stock.ArticuloSTK = ArticuloID;
                stock.CantidadSTK = Ety.StockArti;
                stock.DetalleSTK = "Nuevo Articulo (Stock Inicial)";
                stock.TipoIngresoSTK = false; //false --> Ingreso true --> Egreso
                stock.TipoMovSTK = 1; // Stock Inicial
                stockDac.Insert(stock);

                //Crea Moviemento
                //mov.ClaveFinMovi = Ety.RubrArti;
                //mov.ClaveIniMovi = Ety.CodiArti;
                //mov.TipoMovi = 1; //Alta Articulo
                //mov.ValorFinMovi = Ety.PorcGananciaArti.ToString();
                //mov.ValorIniMovi = Ety.porcIVAArti.ToString();
                //mov.RealIniMovi = Ety.BaseArti;
                //mov.RealFinMovi = Ety.SugeArti;
                //mov.VendMovi = userId;

                mov.ClaveIniMovi = ArticuloID;
                mov.ClaveFinMovi = Ety.porcIVAArti;                
                mov.TipoMovi = 1; //Alta Articulo
                mov.ValorFinMovi = Ety.PorcGananciaArti.ToString();
                mov.ValorIniMovi = Ety.RubrArti.ToString() +"|"+Ety.CoBaArti;
                mov.RealIniMovi = Ety.BaseArti;
                mov.RealFinMovi = Ety.SugeArti;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                ArtDac.CommitTrans();
            
            }
            catch(Exception ex)
            {
                ArtDac.RollBackTrans();
                throw ex;
            }

        }

        public void ArticuloUpdate(ArticuloEntity Ety, ArticuloEntity OldArt , int userId)
        {
            ArticuloDALC ArtDac = new ArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            try
            {
                ArtDac.BeginTrans();
                movDac.BindTrans(ArtDac.ActiveConnection, ArtDac.ActiveTransaction);

                //Modifica Nuevo Articulo
                ArtDac.Update(Ety);

                //Crea Moviemento
                //mov.ClaveFinMovi = Ety.RubrArti;
                //mov.ClaveIniMovi = OldArt.RubrArti;
                //mov.TipoMovi = (Ety.EstaArti == false ? 2 : 3); //Modificar/Eliminar Articulo
                //mov.ValorFinMovi = Ety.CodiArti.ToString();
                //mov.ValorIniMovi = OldArt.CodiArti.ToString();
                //mov.RealIniMovi = Ety.BaseArti;
                //mov.RealFinMovi = Ety.SugeArti;
                //mov.VendMovi = userId;
                mov.ClaveIniMovi = Ety.IDArti;
                mov.ClaveFinMovi = Ety.porcIVAArti;
                mov.TipoMovi = (Ety.EstaArti == false ? 2 : 3); //Modificar/Eliminar Articulo
                mov.ValorFinMovi = Ety.PorcGananciaArti.ToString();
                mov.ValorIniMovi = Ety.RubrArti.ToString() + "|" + Ety.CoBaArti;
                mov.RealIniMovi = Ety.BaseArti;
                mov.RealFinMovi = Ety.SugeArti;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                ArtDac.CommitTrans();

            }
            catch (Exception ex)
            {
                ArtDac.RollBackTrans();
                throw ex;
            }
        }


        public void ArticuloUpdatePrecio(List<IdsArticuloEntity> idsLst, short tipoUpdate, int userId, decimal valor)
        {
            ArticuloDALC ArtDac = new ArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            try
            {
                ArtDac.BeginTrans();
                movDac.BindTrans(ArtDac.ActiveConnection, ArtDac.ActiveTransaction);

                foreach (IdsArticuloEntity id in idsLst)
                {
                    ArtDac.ActualizarPrecioPorTipo(id.idArti,tipoUpdate,valor);
                }

                

                mov.ClaveIniMovi = tipoUpdate;
                mov.ClaveFinMovi = valor;
                mov.TipoMovi =27; 
                mov.ValorFinMovi = string.Empty;
                mov.ValorIniMovi = string.Empty;
                mov.RealIniMovi =0;
                mov.RealFinMovi = 0;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                ArtDac.CommitTrans();

            }
            catch (Exception ex)
            {
                ArtDac.RollBackTrans();
                throw ex;
            }
        }

        public void ArticuloUpdateRubro(List<IdsArticuloEntity> idsLst, short tipoUpdate, int userId, decimal valor)
        {
            ArticuloDALC ArtDac = new ArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            try
            {
                ArtDac.BeginTrans();
                movDac.BindTrans(ArtDac.ActiveConnection, ArtDac.ActiveTransaction);

                foreach (IdsArticuloEntity id in idsLst)
                {
                    ArtDac.ActualizarPrecioPorTipo(id.idArti, tipoUpdate, valor);

                    mov = new MovimientoEntity();
                    mov.ClaveIniMovi = tipoUpdate;
                    mov.ClaveFinMovi = id.idArti;
                    mov.TipoMovi = 28;
                    mov.ValorFinMovi = valor.ToString();
                    mov.ValorIniMovi = string.Empty;
                    mov.RealIniMovi = 0;
                    mov.RealFinMovi = 0;
                    mov.VendMovi = userId;
                    movDac.Insert(mov);
                }

                ArtDac.CommitTrans();

            }
            catch (Exception ex)
            {
                ArtDac.RollBackTrans();
                throw ex;
            }
        }

        public int ProximoCodigo(int RubrArti)
        {
            try
            {
                return new ArticuloDALC().NextCodiArti(RubrArti);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obteniendo código --> " + ex.Message);
                return -1;

            }

        }

        public void SetPrint(int articulo, bool print)
        {
            try
            {
                new ArticuloDALC().SetPrint(articulo, print);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error setando estado --> " + ex.Message);
            }

        }

        public ArticuloEntity[] getByCodiRubro(int Codigo)
        {
            return new ArticuloDALC().GetByCodRubro(Codigo);
        }

    }
}
