using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ventas.DataAccess;
using Ventas.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;
using System.Windows.Forms;

namespace Ventas.Business
{
    public class VentaBUS
    {
        public int LlenarComboTipoFactura(ComboBox cbo, bool soloFactElec)
        {
            try
            {
                cbo.DataSource = this.TipoFacturaGetCombo_DT(soloFactElec);
                cbo.DisplayMember = "NOMBRETIFA";
                cbo.ValueMember = "IDTIFA";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando Tipo de venta");
                return -1;

            }

        }

        public DataTable TipoFacturaGetCombo_DT(bool soloFactElec)
        {
            try
            {
                VentaDALC DALC = new VentaDALC();
                if (soloFactElec)
                    return DALC.DS_TipoFacturaElecGetAll().Tables[0];
                else
                    return DALC.DS_TipoFacturaGetAll().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable VentasGetFechaAndVend_DT(DateTime fechaIni, DateTime fechaFin)
        {
            VentaDALC DALC = new VentaDALC();
            return DALC.DS_GetByDateAndVend(fechaIni,fechaFin).Tables[0];
        }

        public VentaEntity getVentaID(decimal ID)
        {
            return new VentaDALC().GetByID(ID);
        }

        public void EiminarVenta(int numeVenta)
        {
            new VentaDALC().Delete(numeVenta);
        }

        public void AgregarVentaEnCtaCte(decimal numeVenta, int cliente, string retira)
        {
            new VentaDALC().InsertVtaToCtaCte(numeVenta,cliente,retira);
        }

        public void AgregarNotaCredito(decimal numeVenta, decimal numeNC)
        {
            new VentaDALC().NotaCredito(numeVenta,numeNC);
        }

        public void BackupBD()
        {
            new DataBaseDALC().Backup();
        }

        public decimal ProcesarVenta(List<VtaArtEntity> listArt, VentaEntity venta, int userID, int clieId, string retira)
        {
            VentaDALC ventaDac = new VentaDALC();
            VtaArtDALC vtaArtDac = new VtaArtDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                ventaDac.BeginTrans();
                movDac.BindTrans(ventaDac.ActiveConnection, ventaDac.ActiveTransaction);
                vtaArtDac.BindTrans(ventaDac.ActiveConnection, ventaDac.ActiveTransaction);

                if (listArt.Count <= 0) throw new Exception("No hay items cargados");
                decimal nroVta = ventaDac.Insert(venta,clieId, retira);

                //Crea Moviemento general de la venta
                mov.ClaveIniMovi = nroVta;
                mov.ClaveFinMovi = clieId;//desde el 01/03/2021
                mov.TipoMovi = 12;
                mov.ValorIniMovi = venta.TipoVta.ToString();
                mov.ValorFinMovi = venta.TipoPagoVta.ToString();//desde el 01/03/2021
                mov.RealIniMovi = venta.TotaVta;
                mov.RealFinMovi = 0;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                foreach (VtaArtEntity arti in listArt)
                {
                    arti.NumeVear = nroVta;
                    vtaArtDac.Insert(arti);

                    
                    //Crea Moviemento venta-Articulo
                    mov = new MovimientoEntity();
                    mov.ClaveIniMovi = nroVta;
                    mov.ClaveFinMovi =  movID;
                    mov.TipoMovi = 13;
                    mov.ValorIniMovi = arti.ArtiVear.ToString();
                    mov.ValorFinMovi = string.Empty;
                    mov.RealIniMovi = arti.PrecVear;
                    mov.RealFinMovi = arti.CantVear;
                    mov.VendMovi = userID;
                    movDac.Insert(mov);

                }
                ventaDac.CommitTrans();
                return nroVta;

            }
            catch (Exception ex)
            {
                ventaDac.RollBackTrans();
                throw ex;
            }
        }

        #region ModificarVEnta
        /*
        public void ModificarVenta(List<VtaArtEntity> listArt, List<VtaArtEntity> listArtOld, VentaEntity venta, int userID)
        {
            VentaDALC ventaDac = new VentaDALC();
            VtaArtDALC vtaArtDac = new VtaArtDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                ventaDac.BeginTrans();
                movDac.BindTrans(ventaDac.ActiveConnection, ventaDac.ActiveTransaction);
                vtaArtDac.BindTrans(ventaDac.ActiveConnection, ventaDac.ActiveTransaction);

                ventaDac.Update(venta);

                //Crea Moviemento general de la venta
                mov.ClaveIniMovi = venta.NumeVta;
                mov.ClaveFinMovi = 0;
                mov.TipoMovi = 14;
                mov.ValorIniMovi = venta.DescuentoVta.ToString();
                mov.ValorFinMovi = string.Empty;
                mov.RealIniMovi = venta.TotaVta;
                mov.RealFinMovi = 0;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                //Vemos si hay articulos nuevos
                foreach (VtaArtEntity arti in listArt)
                {
                    bool nuevo = true;
                    //Busca si es nuevo
                    foreach (VtaArtEntity artiOld in listArtOld)
                    {
                        if (artiOld.ArtiVear == arti.ArtiVear && artiOld.CantVear == arti.CantVear && artiOld.RubrVear == arti.RubrVear)
                        {
                            nuevo = false;
                            break;
                        }
                    }

                    if (nuevo)
                    {
                        arti.NumeVear = venta.NumeVta;
                        vtaArtDac.Insert(arti);

                        //Crea Moviemento venta-Articulo
                        mov = new MovimientoEntity();
                        mov.ClaveIniMovi = venta.NumeVta;
                        mov.ClaveFinMovi = movID;
                        mov.TipoMovi = 15;
                        mov.ValorIniMovi = arti.RubrVear.ToString();
                        mov.ValorFinMovi = arti.ArtiVear.ToString();
                        mov.RealIniMovi = arti.PrecVear;
                        mov.RealFinMovi = arti.CantVear;
                        mov.VendMovi = userID;
                        movDac.Insert(mov);
                    }

                }

                //Vemos si hay articulos para eliminar
                foreach (VtaArtEntity artiOld in listArtOld)                
                {
                    bool eliminar = true;
                    //Busca si es nuevo
                    foreach (VtaArtEntity arti in listArt)
                    {
                        if (artiOld.ArtiVear == arti.ArtiVear && artiOld.CantVear == arti.CantVear && artiOld.RubrVear == arti.RubrVear)
                        {
                            eliminar = false;
                            break;
                        }
                    }

                    if (eliminar)
                    {
                        artiOld.NumeVear = venta.NumeVta;
                        vtaArtDac.Delete(artiOld);

                        //Crea Moviemento venta-Articulo
                        mov = new MovimientoEntity();
                        mov.ClaveIniMovi = venta.NumeVta;
                        mov.ClaveFinMovi = movID;
                        mov.TipoMovi = 16;
                        mov.ValorIniMovi = artiOld.RubrVear.ToString();
                        mov.ValorFinMovi = artiOld.ArtiVear.ToString();
                        mov.RealIniMovi = artiOld.PrecVear;
                        mov.RealFinMovi = artiOld.CantVear;
                        mov.VendMovi = userID;
                        movDac.Insert(mov);
                    }

                }

                ventaDac.CommitTrans();

            }
            catch (Exception ex)
            {
                ventaDac.RollBackTrans();
                throw ex;
            }
        }
         */
        #endregion

        public void AgregarNotaCredito(NotaDeCreditoEntity ety, int userID)
        {
            VentaDALC Dac = new VentaDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                Dac.BeginTrans();
                movDac.BindTrans(Dac.ActiveConnection, Dac.ActiveTransaction);

                Dac.NotaCredito(ety);

                //Crea Moviemento general de la NotaCredito
                mov.ClaveIniMovi = ety.NumeVtaNocr;
                mov.ClaveFinMovi = ety.TicketFiscalNocr;
                mov.TipoMovi = 118;
                mov.ValorIniMovi = ety.CaeNocr;
                mov.ValorFinMovi = String.Empty;
                mov.RealIniMovi = 0;
                mov.RealFinMovi = 0;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                Dac.CommitTrans();

            }
            catch (Exception ex)
            {
                Dac.RollBackTrans();
                throw ex;
            }
        }
    }
}
