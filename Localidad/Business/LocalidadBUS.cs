using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Localidad.DataAccess;
using Localidad.Entities;
using System.Windows.Forms;

namespace Localidad.Business
{
    public class LocalidadBUS
    {
        public int LlenarComboLocalidad(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.LocalidadGetCombo_DT();
                cbo.DisplayMember = "NOMBLOCA";
                cbo.ValueMember = "CODILOCA";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Localidad");
                return -1;

            }

        }

        public DataTable LocalidadGetCombo_DT()
        {
            LocalidadDALC DALC = new LocalidadDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public DataTable getAllLocalidades_DT()
        {
            return new LocalidadDALC().DS_GetAll().Tables[0];
        }

        public LocalidadEntity getLocalidadID(int ID)
        {
            return new LocalidadDALC().GetByID(ID);
        }

        public void LocalidadInsert(LocalidadEntity Ety)
        {
            new LocalidadDALC().Insert(Ety);

        }

        public void LocalidadUpdate(LocalidadEntity Ety)
        {
            new LocalidadDALC().Update(Ety);

        }
    }
}
