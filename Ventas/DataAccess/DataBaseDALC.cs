using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;

namespace Ventas.DataAccess
{
    public class DataBaseDALC : SqlDataComponent
    {
        public void Backup()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPbackup");
                cmd.CommandType = CommandType.StoredProcedure;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
