using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Compras.Entities;

namespace Compras.DataAccess
{
    public class CompraArticuloDALC : SqlDataComponent
    {
        public void Insert(CompraArticuloEntity Ety, bool actualizarPrecio)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcompartAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDCOAR", SqlDbType.Int).Value = Ety.NumeCoar;
                cmd.Parameters.Add("@ARTICOAR", SqlDbType.Int).Value = Ety.IdArtiCoar;
                cmd.Parameters.Add("@PRECCOAR", SqlDbType.Real).Value = Ety.PrecCoar;
                cmd.Parameters.Add("@CANTCOAR", SqlDbType.Int).Value = Ety.CantCoar;
                cmd.Parameters.Add("@TOTACOAR", SqlDbType.Real).Value = Math.Round(Ety.PrecCoar * Ety.CantCoar,2);
                cmd.Parameters.Add("@PORCIVA", SqlDbType.Real).Value = Ety.PorcIVA;
                cmd.Parameters.Add("@MODIFICAPRECIO", SqlDbType.Bit).Value = actualizarPrecio;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CompraArticuloEntity[] GetByID(int ID)
        {
            SqlCommand cmd = new SqlCommand("spCompraArticuloById");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NUME", SqlDbType.Int).Value = ID;
            CompraArticuloEntity[] Ety = DataConvert.ToCompraArticuloCollection(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public void Delete(CompraArticuloEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcomartEliminar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NUMECOAR", SqlDbType.Int).Value = Ety.NumeCoar;
                cmd.Parameters.Add("@ARTICOAR", SqlDbType.Int).Value = Ety.IdArtiCoar;
                cmd.Parameters.Add("@CANTCOAR", SqlDbType.Int).Value = Ety.CantCoar;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
