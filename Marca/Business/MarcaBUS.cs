using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Marca.DataAccess;
using System.Windows.Forms;

namespace Marca.Business
{
    public class MarcaBUS
    {
        public int LlenarComboMarca(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ListaGetCombo_DT();
                cbo.DisplayMember = "NOMBREMARC";
                cbo.ValueMember = "IDMARC";
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
    }
}
