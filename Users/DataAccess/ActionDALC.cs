using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Users.Entities;
using Conexion;


namespace Users.DataAccess
{
    public class ActionDALC : SqlDataComponent
    {
        public ActionEntity[] GetByCateID(int CategoryID)
        {
            ActionEntity[] ActCateEty;
            SqlCommand cmd = new SqlCommand("CategoryActionByCateID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CateID", SqlDbType.Int).Value = CategoryID;
            ActCateEty = DataConvert.ToActionCategoryCollection(this.ExecuteDataSet(cmd));
            CloseConexion();
            return ActCateEty;
        }

        public DataSet DT_GetByCateID(int CategoryID)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("CategoryActionByCateID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CateID", SqlDbType.Int).Value = CategoryID;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }
    }
}
