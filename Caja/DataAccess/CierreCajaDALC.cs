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
    public class CierreCajaDALC : SqlDataComponent
    {
        public DataSet DS_GetByDate(DateTime fechaIni, DateTime fechaFin)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPcierreCajaPorPeriodo");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fechaIni", SqlDbType.DateTime).Value = fechaIni;
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = fechaFin;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public int Insert(CierreCajaEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcierreCajaAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@efectivo", SqlDbType.Decimal).Value = Ety.EfectivoCica;
                cmd.Parameters.Add("@tarjcredito", SqlDbType.Decimal).Value = Ety.TarjCreditoCica;
                cmd.Parameters.Add("@tarjdebito", SqlDbType.Decimal).Value = Ety.TarjDebitoCica;
                cmd.Parameters.Add("@mercadoPago", SqlDbType.Decimal).Value = Ety.MercadoPagoCica;
                cmd.Parameters.Add("@ctacte", SqlDbType.Decimal).Value = Ety.CtaCteCica;
                cmd.Parameters.Add("@saldo", SqlDbType.Decimal).Value = Ety.SaldoCica;
                cmd.Parameters.Add("@totalvta", SqlDbType.Decimal).Value = Ety.TotalVtaCica;
                cmd.Parameters.Add("@totalnc", SqlDbType.Decimal).Value = Ety.TotalNotaCreditoCica;
                cmd.Parameters.Add("@ingresos", SqlDbType.Decimal).Value = Ety.IngresoCajaCica;
                cmd.Parameters.Add("@egresos", SqlDbType.Decimal).Value = Ety.EgresoCajaCica;


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

        public CierreCajaEntity GetByID(int ID)
        {
            CierreCajaEntity Ety = new CierreCajaEntity();
            SqlCommand cmd = new SqlCommand("SPCajaGetByCierre");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idCierre", SqlDbType.Int).Value = ID;
            Ety = DataConvert.ToCierreCaja(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public CierreCajaEntity GetLast()
        {
            CierreCajaEntity Ety = new CierreCajaEntity();
            SqlCommand cmd = new SqlCommand("SPCierreCajaUltimo");
            cmd.CommandType = CommandType.StoredProcedure;
            Ety = DataConvert.ToCierreCaja(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }
    }
}
