using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Vendedor.DataAccess;
using Vendedor.Entities;
using System.Windows.Forms;

namespace Vendedor.Business
{
    public class VendedorBusiness
    {
        public DataTable getAllVendedores_DT()
        {
            return new VendedorDALC().DS_GetAll().Tables[0];
        }
        public VendedorEntity getVendedorID(int userID)
        {
            return new VendedorDALC().GetByID(userID);
        }

        public int VendedorGetLocalidad(int CodiVend)
        {
            return new VendedorDALC().getLocalidad(CodiVend);

        }
        public void VendedorInsert(VendedorEntity rEty)
        {
            new VendedorDALC().Insert(rEty);

        }
        public void VendedorUpdate(VendedorEntity rEty)
        {
            new VendedorDALC().Update(rEty);

        }
        public int LlenarComboPerfil(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.PerfilGetCombo_DT();
                cbo.DisplayMember = "NOMBPERFI";
                cbo.ValueMember = "CODIPERFI";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Perfil");
                return -1;

            }

        }

        public int LlenarComboVendedor(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.VendedorGetCombo_DT();
                cbo.DisplayMember = "NOMBVEND";
                cbo.ValueMember = "CODIVEND";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Vendedor");
                return -1;

            }

        }

        public DataTable PerfilGetAll_DT()
        {
            PerfilDALC proDALC = new PerfilDALC();
            return proDALC.GetAll_DS().Tables[0];
        }

        public DataTable PerfilGetCombo_DT()
        {
            PerfilDALC proDALC = new PerfilDALC();
            return proDALC.GetCombo_DS().Tables[0];
        }

        public DataTable VendedorGetCombo_DT()
        {
            VendedorDALC DALC = new VendedorDALC();
            return DALC.GetCombo_DS().Tables[0];
        }
    }
}
