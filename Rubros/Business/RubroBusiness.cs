using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Rubros.DataAccess;
using Rubros.Entities;
using System.Windows.Forms;
using Movimiento.Business;
using Movimiento.DataAccess;
using Movimiento.Entities;

namespace Rubros.Business
{
    public class RubroBusiness
    {
        public DataTable getAllRubros_DT()
        {
            return new RubroDALC().DS_GetAll().Tables[0];
        }

        public int LlenarComboRubro(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ListaGetCombo_DT();
                cbo.DisplayMember = "DESCRUBR";
                cbo.ValueMember = "CODIRUBR";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Rubro");
                return -1;

            }

        }

        public DataTable ListaGetCombo_DT()
        {
            RubroDALC DALC = new RubroDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public void RubroInsert(RubroEntity Ety, int userId)
        {
            //new RubroDALC().Insert(rEty);

            RubroDALC Dac = new RubroDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            try
            {
                Dac.BeginTrans();
                movDac.BindTrans(Dac.ActiveConnection, Dac.ActiveTransaction);

                //Modifica Nuevo Articulo
                Dac.Insert(Ety);

                //Crea Moviemento
                mov.ClaveIniMovi = Ety.CodiRub;
                mov.ClaveFinMovi = 0;
                mov.TipoMovi =24;
                mov.ValorFinMovi = Ety.DescRubr;
                mov.ValorIniMovi = String.Empty;
                mov.RealIniMovi = (double)Ety.PorcDtoRubr; //25-05-2021
                mov.RealFinMovi = (double)Ety.PorcGananciaRubr;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                Dac.CommitTrans();

            }
            catch (Exception ex)
            {
                Dac.RollBackTrans();
                throw ex;
            }

        }

        public void RubroUpdate(RubroEntity Ety, RubroEntity oldEty, int userId,bool actualizaPrecio)
        {
            //new RubroDALC().Update(rEty);
            RubroDALC Dac = new RubroDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            try
            {
                Dac.BeginTrans();
                movDac.BindTrans(Dac.ActiveConnection, Dac.ActiveTransaction);

                //Modifica Nuevo Articulo
                Dac.Update(Ety,actualizaPrecio);

                //Crea Moviemento
                mov.ClaveIniMovi = Ety.CodiRub;
                mov.ClaveFinMovi = 0;
                mov.TipoMovi = 25;
                mov.ValorFinMovi = Ety.DescRubr;
                mov.ValorIniMovi = oldEty.DescRubr;
                //mov.RealIniMovi = (double)oldEty.PorcGananciaRubr;
                mov.RealIniMovi = (double)Ety.PorcDtoRubr; //25-05-2021
                mov.RealFinMovi = (double)Ety.PorcGananciaRubr;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                Dac.CommitTrans();

            }
            catch (Exception ex)
            {
                Dac.RollBackTrans();
                throw ex;
            }

        }

        public RubroEntity getRubroID(int userID)
        {
            return new RubroDALC().GetByID(userID);
        }

    }
}
