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
    public class UsersDALC: SqlDataComponent
    {
        public int LoginUser(string usuario)
        {

            SqlCommand comm = new SqlCommand("UserLogin");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@usuario", SqlDbType.NVarChar));
            comm.Parameters["@usuario"].Value = usuario;
            comm.Parameters.Add(new SqlParameter("@retvalue", SqlDbType.Int));
            comm.Parameters["@retvalue"].Direction = ParameterDirection.Output;
            this.ExecuteNonQuery(comm);
            int resp = (int)comm.Parameters["@retvalue"].Value;
            CloseConexion();
            return resp;

        }

        public DataTable Login(string usuario, string password)
        {
            DataTable dt = new DataTable();
            SqlCommand comm = new SqlCommand("UserLoginByPass");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@usuario", SqlDbType.NVarChar));
            comm.Parameters["@usuario"].Value = usuario;
            comm.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
            comm.Parameters["@password"].Value = password;
            comm.Parameters.Add(new SqlParameter("@retvalue", SqlDbType.Int));
            comm.Parameters["@retvalue"].Direction = ParameterDirection.Output;
            dt = this.ExecuteDataSet(comm).Tables[0];
            CloseConexion();
            return dt;
        }

        public UserEntity GetByUserName(string userName)
        {
            UserEntity usEty = new UserEntity();
            SqlCommand cmd = new SqlCommand("SPVendedorPorUserName");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 30).Value = userName;
            usEty = DataConvert.ToUser(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public UserEntity GetByID(int userID)
        {
            UserEntity usEty = new UserEntity();
            SqlCommand cmd = new SqlCommand("UserGetByID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
            usEty = DataConvert.ToUser(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }


        public UserEntity GetAll()
        {
            UserEntity usEty = new UserEntity();
            SqlCommand cmd = new SqlCommand("UserGetAll");
            cmd.CommandType = CommandType.StoredProcedure;
            usEty = DataConvert.ToUser(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("UserGetAll");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public int ExistsAction(int CodiVend, int CodiAcc)
        {
            SqlCommand cmd = new SqlCommand("SPobtenerPermisoPorAccion");
            cmd.CommandType = CommandType.StoredProcedure;
            //la tabla cards no tiene autonum por esa razon se agrega en el insert CardID
            cmd.Parameters.Add("@CodiVend", SqlDbType.Int).Value = CodiVend;
            cmd.Parameters.Add("@CodiAcc", SqlDbType.Int).Value =CodiAcc;

            cmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.Output;

            this.ExecuteNonQuery(cmd);

            return Convert.ToInt32(cmd.Parameters["@Ret"].Value);
        }

        public void Insert(UserEntity usEty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UsersInsert");
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@CategoryAdminID", SqlDbType.Int).Value = usEty.CategoryID;
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = usEty.Name;
                //cmd.Parameters.Add("@SurName", SqlDbType.NVarChar, 100).Value = usEty.Surname;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = usEty.UserName;
                //cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 30).Value = usEty.UserPassword;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(UserEntity usEty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UsersUpdate");
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = usEty.AdminID;
                //cmd.Parameters.Add("@CategoryAdminID", SqlDbType.Int).Value = usEty.categoryAdminID;
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = usEty.Name;
                //cmd.Parameters.Add("@SurName", SqlDbType.NVarChar, 100).Value = usEty.SurName;
                //cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 30).Value = usEty.UserPassword;
                //cmd.Parameters.Add("@Enabled", SqlDbType.Bit).Value = usEty.Enabled;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
