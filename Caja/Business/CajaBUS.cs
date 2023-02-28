using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Caja.DataAccess;
using Caja.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;
using System.Windows.Forms;

namespace Caja.Business
{
    public class CajaBUS
    {

        public DataTable CierreCajaGetFecha_DT(DateTime fechaIni, DateTime fechaFin)
        {
            CierreCajaDALC DALC = new CierreCajaDALC();
            return DALC.DS_GetByDate(fechaIni, fechaFin).Tables[0];
        }


        public DataTable MovimientosCajaXcierre_DT(DateTime fechaIni, DateTime fechaFin, decimal saldoAnterior, int tipo)
        {
            CajaDALC DALC = new CajaDALC();
            return DALC.DS_MovimientosCajaXcierre(fechaIni, fechaFin, saldoAnterior,tipo).Tables[0];
        }

        public DataTable CajaGetFecha_DT(DateTime fechaIni, DateTime fechaFin, bool tipo)
        {
            CajaDALC DALC = new CajaDALC();
            return DALC.DS_GetByDate(fechaIni, fechaFin, tipo).Tables[0];
        }

        public int LlenarComboOrigenDestino(ComboBox cbo, bool valor)
        {
            try
            {
                cbo.DataSource = this.getByOrigenDestino_DT(valor);
                cbo.DisplayMember = "NOMBREODC";
                cbo.ValueMember = "IDODC";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando lista de Clientes");
                return -1;

            }

        }

        public DataTable getByOrigenDestino_DT(bool tipoCaja)
        {
            return new CajaDALC().DS_OriDesByTipoCaja(tipoCaja).Tables[0];
        }


        public CajaEntity getCajaByID(decimal ID)
        {
            return new CajaDALC().GetByID(ID);
        }

        public CierreCajaEntity getCierreCajaByID(int ID)
        {
            return new CierreCajaDALC().GetByID(ID);

        }

        public CierreCajaEntity getLastCierreCaja()
        {
            return new CierreCajaDALC().GetLast();

        }
        public decimal ProcesarCaja(CajaEntity caja, int userID)
        {
            CajaDALC cajaDac = new CajaDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                cajaDac.BeginTrans();
                movDac.BindTrans(cajaDac.ActiveConnection, cajaDac.ActiveTransaction);

                int ret = cajaDac.Insert(caja);

                //Crea Moviemento general de la NotaCredito
                mov.ClaveIniMovi = ret;
                mov.ClaveFinMovi = caja.IvaCaja;
                mov.TipoMovi = 66;
                mov.ValorIniMovi = caja.TipoCaja.ToString();
                mov.ValorFinMovi = caja.OriDesCaja.ToString();
                mov.RealIniMovi = (double)caja.SubtotalCaja;
                mov.RealFinMovi = (double)caja.TotalCaja;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                cajaDac.CommitTrans();
                return ret;

            }
            catch (Exception ex)
            {
                cajaDac.RollBackTrans();
                throw ex;
            }
        }

        public void ModificarCaja(CajaEntity caja, int userID)
        {
            CajaDALC cajaDac = new CajaDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                cajaDac.BeginTrans();
                movDac.BindTrans(cajaDac.ActiveConnection, cajaDac.ActiveTransaction);

                cajaDac.Update(caja);

                //Crea Moviemento general de la CAJA
                mov.ClaveIniMovi = caja.IdCaja;
                mov.ClaveFinMovi = caja.PorcIvaCaja;
                mov.TipoMovi = 67; //MODIFICACION CAJA
                mov.ValorIniMovi = caja.TipoCaja.ToString();
                mov.ValorFinMovi = caja.OriDesCaja.ToString();
                mov.RealIniMovi = (double)caja.SubtotalCaja;
                mov.RealFinMovi = (double)caja.TotalCaja;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);      

                cajaDac.CommitTrans();

            }
            catch (Exception ex)
            {
                cajaDac.RollBackTrans();
                throw ex;
            }
        }

        public void EliminarCaja(decimal id, int userID)
        {
            CajaDALC cajaDac = new CajaDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                cajaDac.BeginTrans();
                movDac.BindTrans(cajaDac.ActiveConnection, cajaDac.ActiveTransaction);

                cajaDac.Delete(id);

                //Crea Moviemento general de la CAJA
                mov.ClaveIniMovi = id;
                mov.ClaveFinMovi = 0;
                mov.TipoMovi = 68; //ELIMINAR CAJA
                mov.ValorIniMovi = string.Empty;
                mov.ValorFinMovi = string.Empty;
                mov.RealIniMovi = 0;
                mov.RealFinMovi = 0;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                cajaDac.CommitTrans();

            }
            catch (Exception ex)
            {
                cajaDac.RollBackTrans();
                throw ex;
            }
        }


        public decimal ProcesarCierreCaja(CierreCajaEntity caja, int userID)
        {
            CierreCajaDALC cajaDac = new CierreCajaDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                cajaDac.BeginTrans();
                movDac.BindTrans(cajaDac.ActiveConnection, cajaDac.ActiveTransaction);

                int ret = cajaDac.Insert(caja);

                //Crea Moviemento general de la NotaCredito
                mov.ClaveIniMovi = ret;
                mov.ClaveFinMovi = caja.TarjDebitoCica;
                mov.TipoMovi = 117;
                mov.ValorIniMovi = caja.TotalNotaCreditoCica.ToString();
                mov.ValorFinMovi = caja.TarjCreditoCica.ToString();
                mov.RealIniMovi = (double)caja.EfectivoCica;
                mov.RealFinMovi = (double)caja.TotalVtaCica;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                cajaDac.CommitTrans();
                return ret;

            }
            catch (Exception ex)
            {
                cajaDac.RollBackTrans();
                throw ex;
            }
        }
    }
}
