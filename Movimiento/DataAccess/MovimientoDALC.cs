using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Movimiento.Entities;

namespace Movimiento.DataAccess
{
    public class MovimientoDALC : SqlDataComponent
    {
        public int  Insert(MovimientoEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPMovimientoAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TipoMovi", SqlDbType.Int).Value = Ety.TipoMovi;
                cmd.Parameters.Add("@VendMovi", SqlDbType.Int).Value = Ety.VendMovi;
                cmd.Parameters.Add("@ClaveIniMovi", SqlDbType.Decimal).Value = Ety.ClaveIniMovi;
                cmd.Parameters.Add("@ClaveFinMovi", SqlDbType.Decimal).Value = Ety.ClaveFinMovi;
                cmd.Parameters.Add("@ValorIniMovi", SqlDbType.NVarChar).Value = Ety.ValorIniMovi;
                cmd.Parameters.Add("@ValorFinMovi", SqlDbType.NVarChar).Value = Ety.ValorFinMovi;
                cmd.Parameters.Add("@RealIniMovi", SqlDbType.Real).Value = Ety.RealIniMovi;
                cmd.Parameters.Add("@RealFinMovi", SqlDbType.Real).Value = Ety.RealFinMovi;
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

        public MovimientoEntity lastMovementUpdateByProduct(int idarti)
        {
            try
            {
                MovimientoEntity ety = new MovimientoEntity();
                SqlCommand cmd = new SqlCommand("SPlastMovementUpdateByProduct");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idArti", SqlDbType.Int).Value = idarti;

                ety = DataConvert.ToMovimiento(this.ExecuteDataSet(cmd));
                CloseConexion();
                return ety;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
