using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;

namespace Vendedor.DataAccess
{
    public class PerfilDALC : SqlDataComponent
    {
        public DataSet GetAll_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPPerfilesListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPPerfilesCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }
    }
}
