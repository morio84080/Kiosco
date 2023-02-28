using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Cliente.Entities;

namespace Cliente.DataAccess
{
    public class ClienteDALC : SqlDataComponent
    {
        public DataSet DS_GetAllCondIva()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPCondIVAListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPClientesCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPClientesListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByLoca(int CodiLoca)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPclientePorLoca");
            cmd.Parameters.Add("@CodiLoca", SqlDbType.Int).Value = CodiLoca;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRaso(string RazonSocial)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPclientePorRaso");
            cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = RazonSocial;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRasoAndLoca(string RazonSocial, int Localidad)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPclientePorRasoAndLoca");
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
            SqlCommand cmd = new SqlCommand("SPclientePorRasoAndVend");
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
            SqlCommand cmd = new SqlCommand("SPclientePorVend");
            cmd.Parameters.Add("@VendClie", SqlDbType.Int).Value = userId;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ClienteEntity GetByID(int ID)
        {
            ClienteEntity usEty = new ClienteEntity();
            SqlCommand cmd = new SqlCommand("SPClientePorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToCliente(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public void Insert(ClienteEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPClienteAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LocaClie", SqlDbType.Int).Value = Ety.LocaClie;
                cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = Ety.RasoClie;
                cmd.Parameters.Add("@CuitClie", SqlDbType.VarChar).Value = Ety.CuitClie;
                cmd.Parameters.Add("@DireClie", SqlDbType.VarChar).Value = Ety.DireClie;
                cmd.Parameters.Add("@TeleClie", SqlDbType.VarChar).Value = Ety.TeleClie;
                cmd.Parameters.Add("@MailClie", SqlDbType.VarChar).Value = Ety.MailClie;
                cmd.Parameters.Add("@CondIvaClie", SqlDbType.SmallInt).Value = Ety.CondIvaClie;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(ClienteEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPClienteModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LocaClie", SqlDbType.Int).Value = Ety.LocaClie;
                cmd.Parameters.Add("@RasoClie", SqlDbType.VarChar).Value = Ety.RasoClie;
                cmd.Parameters.Add("@CuitClie", SqlDbType.VarChar).Value = Ety.CuitClie;
                cmd.Parameters.Add("@DireClie", SqlDbType.VarChar).Value = Ety.DireClie;
                cmd.Parameters.Add("@TeleClie", SqlDbType.VarChar).Value = Ety.TeleClie;
                cmd.Parameters.Add("@MailClie", SqlDbType.VarChar).Value = Ety.MailClie;
                cmd.Parameters.Add("@IdClie", SqlDbType.Int).Value = Ety.IdClie;
                cmd.Parameters.Add("@EstaClie", SqlDbType.Bit).Value = Ety.EstaClie;
                cmd.Parameters.Add("@CondIvaClie", SqlDbType.SmallInt).Value = Ety.CondIvaClie;
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
                SqlCommand comm = new SqlCommand("SPproximoCodiCliente");
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
