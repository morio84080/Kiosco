using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using CuentaCorriente.Entities;


namespace CuentaCorriente.DataAccess
{
    public class PagoClieDALC : SqlDataComponent
    {
        public DataSet DS_GetByFilers(DateTime? FechaIni, DateTime? FechaFin)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPpagoclieListPorFiltros");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
            cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public PagoClieEntity GetByUltimoPago(int clienteId)
        {
            PagoClieEntity Ety = new PagoClieEntity();
            SqlCommand cmd = new SqlCommand("SPpagoClienteGetLast");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;
            Ety = DataConvert.ToPagoClie(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public PagoClieEntity GetByID(int ID)
        {
            PagoClieEntity Ety = new PagoClieEntity();
            SqlCommand cmd = new SqlCommand("SPpagocliePorID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
            Ety = DataConvert.ToPagoClie(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public int Insert(PagoClieEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPpagoClieAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CliePACL", SqlDbType.Int).Value = Ety.CliePACL;
                cmd.Parameters.Add("@DetaPACL", SqlDbType.VarChar).Value = Ety.DetaPACL;
                cmd.Parameters.Add("@ImpoPACL", SqlDbType.Real).Value = Ety.ImpoPACL;
                cmd.Parameters.Add("@FechPACL", SqlDbType.DateTime).Value = Ety.FechaPACL;
                cmd.Parameters.Add("@TipoPACL", SqlDbType.SmallInt).Value = Ety.TipoPACL;
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

        public void Update(PagoClieEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPpagoModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumePACL", SqlDbType.Int).Value = Ety.NumePACL;
                cmd.Parameters.Add("@CliePACL", SqlDbType.Int).Value = Ety.CliePACL;
                cmd.Parameters.Add("@DetaPACL", SqlDbType.VarChar).Value = Ety.DetaPACL;
                cmd.Parameters.Add("@ImpoPACL", SqlDbType.Real).Value = Ety.ImpoPACL;
                cmd.Parameters.Add("@FechPACL", SqlDbType.DateTime).Value = Ety.FechaPACL;
                cmd.Parameters.Add("@EliminadoPACL", SqlDbType.Bit).Value = Ety.EliminadoPACL;
                cmd.Parameters.Add("@TipoPACL", SqlDbType.SmallInt).Value = Ety.TipoPACL;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet DS_Condicion(int tipo)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPtipoPagoList");
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }
    }
}
