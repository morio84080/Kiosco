using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Proveedor.DataAccess;
using Proveedor.Entities;
using System.Windows.Forms;

namespace Proveedor.Business
{
    public class ProveedorBUS
    {
        public int LlenarComboProveedor(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ProveedorGetCombo_DT();
                cbo.DisplayMember = "RASOPROV";
                cbo.ValueMember = "IDPROV";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando combo Proveedor");
                return -1;

            }

        }

        public int ProximoCodigo(int LocaClie)
        {
            try
            {
                return new ProveedorDALC().NextCodiClie(LocaClie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obteniendo código --> " + ex.Message);
                return -1;

            }
            
        }

        public DataTable ProveedorGetCombo_DT()
        {
            ProveedorDALC DALC = new ProveedorDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public DataTable getAllProveedors_DT()
        {
            return new ProveedorDALC().DS_GetAll().Tables[0];
        }

        public DataTable getByLoca_DT(int CodiLoca)
        {
            return new ProveedorDALC().DS_GetByLoca(CodiLoca).Tables[0];
        }

        public DataTable getByRaso_DT(string RazonSocial)
        {
            return new ProveedorDALC().DS_GetByRaso(RazonSocial).Tables[0];
        }
        public DataTable getByRasoAndVend_DT(string RazonSocial, int vendedor)
        {
            return new ProveedorDALC().DS_GetByRasoAndVend(RazonSocial,vendedor).Tables[0];
        }

        public DataTable getByRasoAndLoca_DT(string RazonSocial, int localidad)
        {
            return new ProveedorDALC().DS_GetByRasoAndLoca(RazonSocial, localidad).Tables[0];
        }

        public DataTable getByVend_DT(int VendClie)
        {
            return new ProveedorDALC().DS_GetByUser(VendClie).Tables[0];
        }


        public ProveedorEntity getProveedorID(int ID)
        {
            return new ProveedorDALC().GetByID(ID);
        }

        public void ProveedorInsert(ProveedorEntity Ety)
        {
            new ProveedorDALC().Insert(Ety);

        }

        public void ProveedorUpdate(ProveedorEntity Ety)
        {
            new ProveedorDALC().Update(Ety);

        }
    }
}
