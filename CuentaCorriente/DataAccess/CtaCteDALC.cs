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
    public class CtaCteDALC : SqlDataComponent
    {
        public DataSet DS_GetCtaCteByClie(int CodiClie, DateTime FechaIni, DateTime FechaFin)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("CONSULTA_QCTACTECLIE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CLIENTE", SqlDbType.Int).Value = CodiClie;
            cmd.Parameters.Add("@FECH1", SqlDbType.SmallDateTime).Value = FechaIni;
            cmd.Parameters.Add("@FECH2", SqlDbType.SmallDateTime).Value = FechaFin;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public SaldosEntity SaldoBase(int CodiClie, DateTime Fecha)
        {
            try
            {
                SaldosEntity saldos = new SaldosEntity();
                SqlCommand cmd = new SqlCommand("QSALDOBASE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CLIE", SqlDbType.Int).Value = CodiClie;
                cmd.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = Fecha;
                cmd.Parameters.Add(new SqlParameter("@ING1", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@EGR1", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@EGR2", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@SALDO", SqlDbType.Real));
                cmd.Parameters["@ING1"].Direction = ParameterDirection.Output;
                cmd.Parameters["@EGR1"].Direction = ParameterDirection.Output;
                cmd.Parameters["@EGR2"].Direction = ParameterDirection.Output;
                cmd.Parameters["@SALDO"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                saldos.Compras = Convert.ToDouble(cmd.Parameters["@EGR1"].Value);
                saldos.Debitos = Convert.ToDouble(cmd.Parameters["@EGR2"].Value);
                saldos.Creditos = Convert.ToDouble(cmd.Parameters["@ING1"].Value);
                saldos.Saldo = Convert.ToDouble(cmd.Parameters["@SALDO"].Value);
                return saldos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SaldosEntity SaldoClie(int LocaClie, int CodiClie, DateTime Fecha)
        {
            try
            {
                SaldosEntity saldos = new SaldosEntity();
                SqlCommand cmd = new SqlCommand("SPSALDOCLIE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CLIE", SqlDbType.Int).Value = CodiClie;
                cmd.Parameters.Add("@LOCA", SqlDbType.Int).Value = LocaClie;
                cmd.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = Fecha;
                cmd.Parameters.Add(new SqlParameter("@ING", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@EGR1", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@EGR2", SqlDbType.Real));
                cmd.Parameters.Add(new SqlParameter("@SALDO", SqlDbType.Real));
                cmd.Parameters["@ING"].Direction = ParameterDirection.Output;
                cmd.Parameters["@EGR1"].Direction = ParameterDirection.Output;
                cmd.Parameters["@EGR2"].Direction = ParameterDirection.Output;
                cmd.Parameters["@SALDO"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                saldos.Compras = (cmd.Parameters["@EGR1"].Value!= DBNull.Value? Convert.ToDouble(cmd.Parameters["@EGR1"].Value):0);
                saldos.Debitos = (cmd.Parameters["@EGR2"].Value != DBNull.Value ? Convert.ToDouble(cmd.Parameters["@EGR2"].Value) : 0);
                saldos.Creditos = (cmd.Parameters["@ING"].Value != DBNull.Value ? Convert.ToDouble(cmd.Parameters["@ING"].Value) : 0);
                saldos.Saldo = (cmd.Parameters["@SALDO"].Value != DBNull.Value ? Convert.ToDouble(cmd.Parameters["@SALDO"].Value) : 0);
                return saldos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public decimal SaldoActual(int cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPsaldoActualCliente");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente;
                cmd.Parameters.Add(new SqlParameter("@saldoActual", SqlDbType.Decimal));
                cmd.Parameters["@saldoActual"].Direction = ParameterDirection.Output;
                cmd.Parameters["@saldoActual"].Precision = 18;
                cmd.Parameters["@saldoActual"].Scale = 2;
                this.ExecuteNonQuery(cmd);
                return Convert.ToDecimal(cmd.Parameters["@saldoActual"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
