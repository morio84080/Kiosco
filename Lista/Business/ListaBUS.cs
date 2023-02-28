using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Lista.DataAccess;
using Lista.Entities;
using System.Windows.Forms;

namespace Lista.Business
{
    public class ListaBUS
    {
        public int LlenarComboLista(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ListaGetCombo_DT();
                cbo.DisplayMember = "NOMBLIST";
                cbo.ValueMember = "CODILIST";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Lista");
                return -1;

            }

        }

        public DataTable ListaGetCombo_DT()
        {
            ListaDALC DALC = new ListaDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public DataTable getAllListas_DT()
        {
            return new ListaDALC().DS_GetAll().Tables[0];
        }

        public ListaEntity getListaID(int ID)
        {
            return new ListaDALC().GetByID(ID);
        }

        public void ListaInsert(ListaEntity Ety)
        {
            new ListaDALC().Insert(Ety);

        }

        public void ListaUpdate(ListaEntity Ety)
        {
            new ListaDALC().Update(Ety);

        }
    }
}
