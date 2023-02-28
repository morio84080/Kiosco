using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Proveedor.Entities;

namespace Proveedor.DataAccess
{
    public class ProveedorDALC : SqlDataComponent
    {
        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorsCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorsListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByLoca(int CodiLoca)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorPorLoca");
            cmd.Parameters.Add("@CodiLoca", SqlDbType.Int).Value = CodiLoca;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRaso(string RazonSocial)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorPorRaso");
            cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = RazonSocial;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRasoAndLoca(string RazonSocial, int Localidad)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorPorRasoAndLoca");
            cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = RazonSocial;
            cmd.Parameters.Add("@LocaClie", SqlDbType.Int).Value = Localidad;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRasoAndVend(string RazonSocial, int Vendedor)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorPorRasoAndVend");
            cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = RazonSocial;
            cmd.Parameters.Add("@VendClie", SqlDbType.Int).Value = Vendedor;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByUser(int userId)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPProveedorPorVend");
            cmd.Parameters.Add("@VendClie", SqlDbType.Int).Value = userId;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ProveedorEntity GetByID(int ID)
        {
            ProveedorEntity usEty = new ProveedorEntity();
            SqlCommand cmd = new SqlCommand("SPProveedorPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToProveedor(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public void Insert(ProveedorEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPProveedorAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LocaProv", SqlDbType.Int).Value = Ety.LocaProv;
                cmd.Parameters.Add("@RasoProv", SqlDbType.VarChar).Value = Ety.RasoProv;
                cmd.Parameters.Add("@CuitProv", SqlDbType.VarChar).Value = Ety.CuitProv;
                cmd.Parameters.Add("@DireProv", SqlDbType.VarChar).Value = Ety.DireProv;
                cmd.Parameters.Add("@TeleProv", SqlDbType.VarChar).Value = Ety.TeleProv;
                cmd.Parameters.Add("@MailProv", SqlDbType.VarChar).Value = Ety.MailProv;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(ProveedorEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPProveedorModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LocaProv", SqlDbType.Int).Value = Ety.LocaProv;
                cmd.Parameters.Add("@RasoProv", SqlDbType.VarChar).Value = Ety.RasoProv;
                cmd.Parameters.Add("@CuitProv", SqlDbType.VarChar).Value = Ety.CuitProv;
                cmd.Parameters.Add("@DireProv", SqlDbType.VarChar).Value = Ety.DireProv;
                cmd.Parameters.Add("@TeleProv", SqlDbType.VarChar).Value = Ety.TeleProv;
                cmd.Parameters.Add("@MailProv", SqlDbType.VarChar).Value = Ety.MailProv;
                cmd.Parameters.Add("@IdProv", SqlDbType.Int).Value = Ety.IdProv;
                cmd.Parameters.Add("@EstaProv", SqlDbType.Bit).Value = Ety.EstaProv;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int NextCodiClie(int locaClie)
        {
            try
            {
                SqlCommand comm = new SqlCommand("SPproximoCodiProveedor");
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@LocaClie", SqlDbType.Int));
                comm.Parameters["@LocaClie"].Value = locaClie;
                comm.Parameters.Add(new SqlParameter("@ret", SqlDbType.Int));
                comm.Parameters["@ret"].Direction = ParameterDirection.Output;
                this.ExecuteNonQuery(comm);
                int resp = Convert.ToInt32(comm.Parameters["@ret"].Value);
                CloseConexion();
                return resp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
