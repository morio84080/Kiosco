using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Ventas.Entities;


namespace Ventas.DataAccess
{
    public class VentaDALC : SqlDataComponent
    {
        public DataSet DS_GetByDateAndVend(DateTime fechaIni, DateTime fechaFin)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPventaPorFechaVend");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@F1", SqlDbType.DateTime).Value = fechaIni;
            cmd.Parameters.Add("@F2", SqlDbType.DateTime).Value = fechaFin;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_TipoFacturaGetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPtipoFacturaListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_TipoFacturaElecGetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPtipoFacturaElecListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public VentaEntity GetByID(decimal ID)
        {
            VentaEntity Ety = new VentaEntity();
            SqlCommand cmd = new SqlCommand("SPFILTROVTA");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Decimal).Value = ID;
            Ety = DataConvert.ToVenta(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public decimal Insert(VentaEntity Ety, int cliente, string retira)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPventaAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TotaVta", SqlDbType.Real).Value = Ety.TotaVta;
                cmd.Parameters.Add("@TipoVta", SqlDbType.Bit).Value = Ety.TipoVta;
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente;
                cmd.Parameters.Add("@TicketFiscal", SqlDbType.Decimal).Value = Ety.TicketFiscal;
                cmd.Parameters.Add("@Retira", SqlDbType.VarChar).Value = retira;
                cmd.Parameters.Add("@Letra", SqlDbType.VarChar).Value = Ety.LetraVta;
                cmd.Parameters.Add("@Condicion", SqlDbType.SmallInt).Value = Ety.TipoPagoVta;
                cmd.Parameters.Add("@Cae", SqlDbType.VarChar).Value = Ety.CAEVta;
                cmd.Parameters.Add("@fechaVto", SqlDbType.SmallDateTime).Value = Ety.FechVtoCAEVta;
                cmd.Parameters.Add(new SqlParameter("@Ret", SqlDbType.Decimal));
                cmd.Parameters["@Ret"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                return Convert.ToDecimal(cmd.Parameters["@Ret"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void Update(VentaEntity Ety)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SPventaModificar");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@NumeVta", SqlDbType.Decimal).Value = Ety.NumeVta;
        //        cmd.Parameters.Add("@LocaVta", SqlDbType.Int).Value = Ety.LocaVta;
        //        cmd.Parameters.Add("@ClieVta", SqlDbType.Int).Value = Ety.ClieVta;
        //        cmd.Parameters.Add("@FechaVta", SqlDbType.DateTime).Value = Ety.FechVta;
        //        cmd.Parameters.Add("@TotaVta", SqlDbType.Real).Value = Ety.TotaVta;
        //        cmd.Parameters.Add("@DescuentoVta", SqlDbType.Real).Value = Ety.DescuentoVta;

        //        this.ExecuteNonQuery(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public void NotaCredito(decimal numeVenta, decimal numeNC)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAgregarNotaCredito");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NUMEVTA", SqlDbType.Decimal).Value = numeVenta;
                cmd.Parameters.Add("@NUMENC", SqlDbType.Decimal).Value = numeNC;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int numeVenta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPventaEliminar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeVear", SqlDbType.Decimal).Value = numeVenta;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InsertVtaToCtaCte(decimal numeVenta, int cliente, string retira)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPventaAgregarCtaCte");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeVta", SqlDbType.Decimal).Value = numeVenta;
                cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = cliente;
                cmd.Parameters.Add("@retira", SqlDbType.VarChar).Value = retira;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void NotaCredito(NotaDeCreditoEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAgregarNotaCredito");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NUMEVTA", SqlDbType.Decimal).Value = Ety.NumeVtaNocr;
                cmd.Parameters.Add("@NUMENC", SqlDbType.Decimal).Value = Ety.TicketFiscalNocr;
                cmd.Parameters.Add("@CAE", SqlDbType.VarChar).Value = Ety.CaeNocr;
                cmd.Parameters.Add("@FECHAVTOCAE", SqlDbType.SmallDateTime).Value = Ety.FechaNocr;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public decimal ObtenerInteres(short rubroId, short tipoPagoId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPinteresPorRubroTipoPago");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RubroId", SqlDbType.SmallInt).Value = rubroId;
                cmd.Parameters.Add("@TipoPagoId", SqlDbType.SmallInt).Value = tipoPagoId;
                cmd.Parameters.Add(new SqlParameter("@PorcInteres", SqlDbType.Decimal));
                cmd.Parameters["@PorcInteres"].Direction = ParameterDirection.Output;

                this.ExecuteNonQuery(cmd);
                return Convert.ToDecimal(cmd.Parameters["@PorcInteres"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
