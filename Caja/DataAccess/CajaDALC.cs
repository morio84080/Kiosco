using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Caja.Entities;

namespace Caja.DataAccess
{
    public class CajaDALC : SqlDataComponent
    {
        public DataSet DS_GetByDate(DateTime fechaIni, DateTime fechaFin, bool tipo)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPcajaPorFecha");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@F1", SqlDbType.DateTime).Value = fechaIni;
            cmd.Parameters.Add("@F2", SqlDbType.DateTime).Value = fechaFin;
            cmd.Parameters.Add("@tipo", SqlDbType.Bit).Value = tipo;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_OriDesByTipoCaja(bool tipo)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPorigenDestinoByTipoCaja");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tipoCaja", SqlDbType.Bit).Value = tipo;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_MovimientosCajaXcierre(DateTime fechaIni, DateTime fechaFin, decimal saldoAnterior, int tipo)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPMovimientosCajaXcierre");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@iniDate", SqlDbType.DateTime).Value = fechaIni;
            cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = fechaFin;
            cmd.Parameters.Add("@saldoAnterior", SqlDbType.Decimal).Value = saldoAnterior;
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public int Insert(CajaEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcajaAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaCaja", SqlDbType.DateTime).Value = Ety.FechaCaja;
                cmd.Parameters.Add("@TipoCaja", SqlDbType.Bit).Value = Ety.TipoCaja;
                cmd.Parameters.Add("@OriDesCaja", SqlDbType.Int).Value = Ety.OriDesCaja;
                cmd.Parameters.Add("@NroFactCaja", SqlDbType.VarChar).Value = Ety.NroFactCaja;
                cmd.Parameters.Add("@DetalleCaja", SqlDbType.VarChar).Value = Ety.DetalleCaja;
                cmd.Parameters.Add("@SubtotaCaja", SqlDbType.Decimal).Value = Ety.SubtotalCaja;
                cmd.Parameters.Add("@PorcIvaCaja", SqlDbType.Decimal).Value = Ety.PorcIvaCaja;
                cmd.Parameters.Add("@IvaCaja", SqlDbType.Decimal).Value = Ety.IvaCaja;
                cmd.Parameters.Add("@TotaCaja", SqlDbType.Decimal).Value = Ety.TotalCaja;
                cmd.Parameters.Add("@TipoCtaCaja", SqlDbType.Bit).Value = Ety.TipoCtaCaja;
                
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

        public void Update(CajaEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcajaModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCaja", SqlDbType.Decimal).Value = Ety.IdCaja;
                cmd.Parameters.Add("@FechaCaja", SqlDbType.DateTime).Value = Ety.FechaCaja;
                cmd.Parameters.Add("@TipoCaja", SqlDbType.Bit).Value = Ety.TipoCaja;
                cmd.Parameters.Add("@OriDesCaja", SqlDbType.Int).Value = Ety.OriDesCaja;
                cmd.Parameters.Add("@NroFactCaja", SqlDbType.VarChar).Value = Ety.NroFactCaja;
                cmd.Parameters.Add("@DetalleCaja", SqlDbType.VarChar).Value = Ety.DetalleCaja;
                cmd.Parameters.Add("@SubtotaCaja", SqlDbType.Decimal).Value = Ety.SubtotalCaja;
                cmd.Parameters.Add("@PorcIvaCaja", SqlDbType.Decimal).Value = Ety.PorcIvaCaja;
                cmd.Parameters.Add("@IvaCaja", SqlDbType.Decimal).Value = Ety.IvaCaja;
                cmd.Parameters.Add("@TotaCaja", SqlDbType.Decimal).Value = Ety.TotalCaja;
                cmd.Parameters.Add("@TipoCtaCaja", SqlDbType.Bit).Value = Ety.TipoCtaCaja;

                this.ExecuteNonQuery(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(decimal id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcajaEliminar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCaja", SqlDbType.Decimal).Value = id;

                this.ExecuteNonQuery(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public CajaEntity GetByID(decimal ID)
        {
            CajaEntity Ety = new CajaEntity();
            SqlCommand cmd = new SqlCommand("SPcajaById");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Decimal).Value = ID;
            Ety = DataConvert.ToCaja(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }
    }
}
