using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Stock.Entities;

namespace Stock.DataAccess
{
    public class StockDALC : SqlDataComponent
    {
        public DataSet DS_stockPorTipoMovGetAll(int tipoMov)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPstockListarPorTipoMov");
            cmd.Parameters.Add("@TipoMovSTK", SqlDbType.Int).Value = tipoMov;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public int Insert(StockEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPstockAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TipoIngresoSTK", SqlDbType.Bit).Value = Ety.TipoIngresoSTK;
                cmd.Parameters.Add("@TipoMovSTK", SqlDbType.Int).Value = Ety.TipoMovSTK;
                cmd.Parameters.Add("@ArticuloSTK", SqlDbType.Int).Value = Ety.ArticuloSTK;
                cmd.Parameters.Add("@CantidadSTK", SqlDbType.Int).Value = Ety.CantidadSTK;
                cmd.Parameters.Add("@DetalleSTK", SqlDbType.NVarChar).Value = Ety.DetalleSTK;
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

        public StockEntity GetStockByID(int ID)
        {
            StockEntity usEty = new StockEntity();
            SqlCommand cmd = new SqlCommand("SPstockPorID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdStk", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToStock(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public void Eliminar(StockEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPstockEliminar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TipoIngresoSTK", SqlDbType.Bit).Value = Ety.TipoIngresoSTK;
                cmd.Parameters.Add("@ArticuloSTK", SqlDbType.Int).Value = Ety.ArticuloSTK;
                cmd.Parameters.Add("@CantidadSTK", SqlDbType.Int).Value = Ety.CantidadSTK;
                cmd.Parameters.Add("@IdSTK", SqlDbType.Int).Value = Ety.IdSTK;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int AlarmaStockMinimo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AlarmaStockMinimo");
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
