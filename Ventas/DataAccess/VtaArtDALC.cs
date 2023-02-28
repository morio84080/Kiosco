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
    public class VtaArtDALC : SqlDataComponent
    {
        public void Insert(VtaArtEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPvtaartAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NUMEVEAR", SqlDbType.Decimal).Value = Ety.NumeVear;
                cmd.Parameters.Add("@ARTIVEAR", SqlDbType.Int).Value = Ety.ArtiVear;
                cmd.Parameters.Add("@PRECVEAR", SqlDbType.Real).Value = Ety.PrecVear;
                cmd.Parameters.Add("@CANTVEAR", SqlDbType.Int).Value = Ety.CantVear;
                cmd.Parameters.Add("@SUBTOTVEAR", SqlDbType.Real).Value = Ety.SubtotalVear;
                cmd.Parameters.Add("@IVAVEAR", SqlDbType.Real).Value = Ety.IvaVear;
                cmd.Parameters.Add("@PORCDTOVEAR", SqlDbType.Decimal).Value = Ety.PorcDtoVear;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void Delete(VtaArtEntity Ety)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SPvtaartEliminar");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@NUMEVEAR", SqlDbType.Decimal).Value = Ety.NumeVear;
        //        cmd.Parameters.Add("@RUBRVEAR", SqlDbType.Int).Value = Ety.RubrVear;
        //        cmd.Parameters.Add("@ARTIVEAR", SqlDbType.Int).Value = Ety.ArtiVear;
        //        cmd.Parameters.Add("@CANTVEAR", SqlDbType.Int).Value = Ety.CantVear;
        //        this.ExecuteNonQuery(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public VtaArtEntity[] GetByID(decimal ID)
        {
            SqlCommand cmd = new SqlCommand("SPVTAARTI");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NUME", SqlDbType.Decimal).Value = ID;
            VtaArtEntity[] Ety = DataConvert.ToVtaArtCollection(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }
    }
}
