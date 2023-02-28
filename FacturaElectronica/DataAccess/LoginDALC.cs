using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using FacturaElectronica.Entities;

namespace FacturaElectronica.DataAccess
{
    public class LoginDALC : SqlDataComponent
    {
        public int checkLogin()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcheckLogin");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Ret", SqlDbType.Int));
                cmd.Parameters["@Ret"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                return Convert.ToInt32(cmd.Parameters["@Ret"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(LoginEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPupdateLogin");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.SmallInt).Value = Ety.id;
                cmd.Parameters.Add("@generationTime", SqlDbType.DateTime).Value = Ety.generationTime;
                cmd.Parameters.Add("@expirationTime", SqlDbType.DateTime).Value = Ety.expirationTime;
                cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = Ety.token;
                cmd.Parameters.Add("@sign", SqlDbType.VarChar).Value = Ety.sign;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LoginEntity Get()
        {
            LoginEntity usEty = new LoginEntity();
            SqlCommand cmd = new SqlCommand("SPLoginGet");
            cmd.CommandType = CommandType.StoredProcedure;
            usEty = DataConvert.ToLogin(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }
    }
}
