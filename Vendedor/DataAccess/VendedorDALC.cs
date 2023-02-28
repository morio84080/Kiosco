using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Vendedor.Entities;

namespace Vendedor.DataAccess
{
    public class VendedorDALC : SqlDataComponent
    {
        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPVendedoresListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public VendedorEntity GetByID(int CodiVend)
        {
            VendedorEntity usEty = new VendedorEntity();
            SqlCommand cmd = new SqlCommand("SPVendedorPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = CodiVend;
            usEty = DataConvert.ToVendedor(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPvendedoresCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public int getLocalidad(int CodiVend)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPvendedorGetLoca");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodiVend", SqlDbType.NVarChar).Value = CodiVend;

                cmd.Parameters.Add(new SqlParameter("@Ret", SqlDbType.Int));
                cmd.Parameters["@Ret"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                return Convert.ToInt32(cmd.Parameters["@Ret"].Value);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public void Insert(VendedorEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPvendedorAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ApelVend", SqlDbType.VarChar).Value = Ety.ApelVend;
                cmd.Parameters.Add("@NombVend", SqlDbType.VarChar).Value = Ety.NombVend;
                cmd.Parameters.Add("@DireVend", SqlDbType.VarChar).Value = Ety.DireVend;
                cmd.Parameters.Add("@TeleVend", SqlDbType.VarChar).Value = Ety.TeleVend;
                cmd.Parameters.Add("@UserVend", SqlDbType.NVarChar).Value = Ety.UserVend;
                cmd.Parameters.Add("@PassVend", SqlDbType.NVarChar).Value = Ety.PassVend;
                cmd.Parameters.Add("@MailVend", SqlDbType.NVarChar).Value = Ety.MailVend;
                cmd.Parameters.Add("@PerfVend", SqlDbType.Int).Value = Ety.PerfilVend;


                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(VendedorEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPvendedorModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ApelVend", SqlDbType.VarChar).Value = Ety.ApelVend;
                cmd.Parameters.Add("@NombVend", SqlDbType.VarChar).Value = Ety.NombVend;
                cmd.Parameters.Add("@DireVend", SqlDbType.VarChar).Value = Ety.DireVend;
                cmd.Parameters.Add("@TeleVend", SqlDbType.VarChar).Value = Ety.TeleVend;
                cmd.Parameters.Add("@UserVend", SqlDbType.NVarChar).Value = Ety.UserVend;
                cmd.Parameters.Add("@PassVend", SqlDbType.NVarChar).Value = Ety.PassVend;
                cmd.Parameters.Add("@MailVend", SqlDbType.NVarChar).Value = Ety.MailVend;
                cmd.Parameters.Add("@PerfVend", SqlDbType.Int).Value = Ety.PerfilVend;
                cmd.Parameters.Add("@CodiVend", SqlDbType.Int).Value = Ety.CodiVend;
                cmd.Parameters.Add("@EstaVend", SqlDbType.Bit).Value = Ety.EstaVend;


                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
