using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cliente.DataAccess;
using Cliente.Entities;
using System.Windows.Forms;

namespace Cliente.Business
{
    public class ClienteBUS
    {
        public int LlenarComboCondIva(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.CondicionIVAGetCombo_DT();
                cbo.DisplayMember = "NOMBRECIVA";
                cbo.ValueMember = "IDCIVA";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando lista de Condiciones de Iva");
                return -1;
            }

        }

        public DataTable CondicionIVAGetCombo_DT()
        {
            ClienteDALC DALC = new ClienteDALC();
            return DALC.DS_GetAllCondIva().Tables[0];
        }

        public int LlenarComboCliente(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.ClienteGetCombo_DT();
                cbo.DisplayMember = "RASOCLIE";
                cbo.ValueMember = "IDCLIE";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error cargando lista de Clientes");
                return -1;

            }

        }

        public int ProximoCodigo(int LocaClie)
        {
            try
            {
                return new ClienteDALC().NextCodiClie(LocaClie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obteniendo código --> " + ex.Message);
                return -1;

            }
            
        }

        public DataTable ClienteGetCombo_DT()
        {
            ClienteDALC DALC = new ClienteDALC();
            return DALC.GetCombo_DS().Tables[0];
        }

        public DataTable getAllClientes_DT()
        {
            return new ClienteDALC().DS_GetAll().Tables[0];
        }

        public DataTable getByLoca_DT(int CodiLoca)
        {
            return new ClienteDALC().DS_GetByLoca(CodiLoca).Tables[0];
        }

        public DataTable getByRaso_DT(string RazonSocial)
        {
            return new ClienteDALC().DS_GetByRaso(RazonSocial).Tables[0];
        }
        public DataTable getByRasoAndVend_DT(string RazonSocial, int vendedor)
        {
            return new ClienteDALC().DS_GetByRasoAndVend(RazonSocial,vendedor).Tables[0];
        }

        public DataTable getByRasoAndLoca_DT(string RazonSocial, int localidad)
        {
            return new ClienteDALC().DS_GetByRasoAndLoca(RazonSocial, localidad).Tables[0];
        }

        public DataTable getByVend_DT(int VendClie)
        {
            return new ClienteDALC().DS_GetByUser(VendClie).Tables[0];
        }


        public ClienteEntity getClienteID(int ID)
        {
            return new ClienteDALC().GetByID(ID);
        }

        public void ClienteInsert(ClienteEntity Ety)
        {
            new ClienteDALC().Insert(Ety);

        }

        public void ClienteUpdate(ClienteEntity Ety)
        {
            new ClienteDALC().Update(Ety);

        }
    }
}
