using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Marcas.DataAccess;
using Marcas.Entities;
using System.Windows.Forms;

namespace Marcas.Business
{
    public class MarcaBusiness
    {
        public DataTable getAllMarcas_DT()
        {
            return new MarcaDALC().DS_GetAll().Tables[0];
        }

        public int LlenarComboMarca(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ListaGetCombo_DT();
                cbo.DisplayMember = "DESCMARC";
                cbo.ValueMember = "CODIMARC";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Marca");
                return -1;

            }

        }

        public DataTable ListaGetCombo_DT()
        {
            MarcaDALC DALC = new MarcaDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public void MarcaInsert(MarcaEntity rEty)
        {
            new MarcaDALC().Insert(rEty);

        }

        public void MarcaUpdate(MarcaEntity rEty)
        {
            new MarcaDALC().Update(rEty);

        }

        public MarcaEntity getMarcaID(int userID)
        {
            return new MarcaDALC().GetByID(userID);
        }

    }
}
