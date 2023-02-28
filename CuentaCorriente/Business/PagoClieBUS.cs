using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CuentaCorriente.DataAccess;
using CuentaCorriente.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;
using System.Windows.Forms;

namespace CuentaCorriente.Business
{
    public class PagoClieBUS
    {
        public int LlenarComboCondicion(ComboBox cbo, int tipo)
        {
            try
            {
                cbo.DataSource = this.CondicionGetCombo_DT(tipo);
                cbo.DisplayMember = "NOMBRETIPA";
                cbo.ValueMember = "IDTIPA";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando Condición de venta");
                return -1;

            }

        }

        public DataTable CondicionGetCombo_DT(int tipo)
        {
            PagoClieDALC DALC = new PagoClieDALC();
            return DALC.DS_Condicion(tipo).Tables[0];
        }

        public DataTable getAllPorFiltros_DT(DateTime? FechaIni = null, DateTime? FechaFin = null)
        {
            return new PagoClieDALC().DS_GetByFilers(FechaIni, FechaFin).Tables[0];
        }

        public PagoClieEntity getByID(int id)
        {
            return new PagoClieDALC().GetByID(id);
        }

        public PagoClieEntity getUltimoPagoPorCliente(int clienteId)
        {
            return new PagoClieDALC().GetByUltimoPago(clienteId);
        }

        public void Insert(PagoClieEntity Ety, int userId)
        {
            PagoClieDALC pagoDac = new PagoClieDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();


            try
            {
                pagoDac.BeginTrans();
                movDac.BindTrans(pagoDac.ActiveConnection, pagoDac.ActiveTransaction);


                int nroPago = pagoDac.Insert(Ety);

                //Crea Moviemento
                mov.ClaveIniMovi =nroPago;
                mov.ClaveFinMovi =0;

                mov.TipoMovi = 21;

                mov.ValorFinMovi = Ety.DetaPACL;
                mov.ValorIniMovi = Ety.CliePACL.ToString();
                mov.RealIniMovi = Ety.ImpoPACL;
                mov.RealFinMovi = 0;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                pagoDac.CommitTrans();

            }
            catch (Exception ex)
            {
                pagoDac.RollBackTrans();
                throw ex;
            }

        }

        public void Update(PagoClieEntity Ety, PagoClieEntity oldEty, int userId)
        {
            PagoClieDALC pagoDac = new PagoClieDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();


            try
            {
                pagoDac.BeginTrans();
                movDac.BindTrans(pagoDac.ActiveConnection, pagoDac.ActiveTransaction);


                pagoDac.Update(Ety);

                //Crea Moviemento
                mov.ClaveIniMovi = Convert.ToInt32(Ety.NumePACL);
                mov.ClaveFinMovi = Ety.CliePACL;

                mov.TipoMovi = (Ety.EliminadoPACL?22:23);

                mov.ValorIniMovi = oldEty.DetaPACL.ToString();
                mov.ValorFinMovi = Ety.DetaPACL.ToString();
                mov.RealIniMovi = oldEty.ImpoPACL;
                mov.RealFinMovi = Ety.ImpoPACL;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                pagoDac.CommitTrans();

            }
            catch (Exception ex)
            {
                pagoDac.RollBackTrans();
                throw ex;
            }

        }

    }
}
