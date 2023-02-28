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
    public class PerfilDALC : SqlDataComponent
    {
        //public CategoryAdminEntity[] GetAll()
        //{
        //    CategoryAdminEntity[] CateAdminEty;
        //    SqlCommand cmd = new SqlCommand("CategoryAdminGetAll");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    CateAdminEty = DataConvert.ToCategoryAdminCollection(this.ExecuteDataSet(cmd));
        //    CloseConexion();
        //    return CateAdminEty;
        //}

        public DataSet GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("CategoryAdminGetAll");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet GetAllAux()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("CategoryAdminGetAllAux");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public void InsertActionCateAdmin(int CategoryID, int ActionID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CategoryAdminActionInsert");
                cmd.CommandType = CommandType.StoredProcedure;
                //la tabla cards no tiene autonum por esa razon se agrega en el insert CardID
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(CategoryID);
                cmd.Parameters.Add("@ActionID", SqlDbType.Int).Value = Convert.ToInt32(ActionID);

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteActionCateAdmin(int CategoryID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CategoryAdminActionDelete");
                cmd.CommandType = CommandType.StoredProcedure;
                //la tabla cards no tiene autonum por esa razon se agrega en el insert CardID
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(CategoryID);

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
