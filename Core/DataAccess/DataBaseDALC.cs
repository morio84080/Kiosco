using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;

namespace Core.DataAccess
{
    public class DataBaseDALC : SqlDataComponent
    {
        public void BackupDiario(string path)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPbackupDiario");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PATH", SqlDbType.VarChar).Value = path;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
