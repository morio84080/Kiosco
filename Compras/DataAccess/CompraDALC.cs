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
    public class CompraDALC : SqlDataComponent
    {
        public DataSet DS_GetAllByDate(DateTime fechaIni, DateTime fechaFin)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("spListarComprasPorFecha");
            cmd.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = fechaIni;
            cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = fechaFin;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public CompraEntity GetByID(int ID)
        {
            CompraEntity Ety = new CompraEntity();
            SqlCommand cmd = new SqlCommand("spCompraById");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = ID;
            Ety = DataConvert.ToCompra(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }
        public int Insert(CompraEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcompraAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaComp", SqlDbType.DateTime).Value = Ety.FechComp;
                cmd.Parameters.Add("@ProveComp", SqlDbType.Int).Value = Ety.ProveComp;
                cmd.Parameters.Add("@SubtotaComp", SqlDbType.Real).Value = Ety.SubtotalComp;
                cmd.Parameters.Add("@IvaComp", SqlDbType.Real).Value = Ety.IvaComp;
                cmd.Parameters.Add("@RetComp", SqlDbType.Real).Value = Ety.RetComp;
                cmd.Parameters.Add("@TotaComp", SqlDbType.Real).Value = Ety.TotalComp;
                cmd.Parameters.Add("@ObseComp", SqlDbType.VarChar).Value = Ety.ObsComp;
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

        public void Update(CompraEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcompraModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdComp", SqlDbType.Int).Value = Ety.NumeComp;
                cmd.Parameters.Add("@FechaComp", SqlDbType.DateTime).Value = Ety.FechComp;
                cmd.Parameters.Add("@ProveComp", SqlDbType.Int).Value = Ety.ProveComp;
                cmd.Parameters.Add("@SubtotaComp", SqlDbType.Real).Value = Ety.SubtotalComp;
                cmd.Parameters.Add("@IvaComp", SqlDbType.Real).Value = Ety.IvaComp;
                cmd.Parameters.Add("@RetComp", SqlDbType.Real).Value = Ety.RetComp;
                cmd.Parameters.Add("@TotaComp", SqlDbType.Real).Value = Ety.TotalComp;
                cmd.Parameters.Add("@ObseComp", SqlDbType.VarChar).Value = Ety.ObsComp;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int numeCompra)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPcompraEliminar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NUMECOAR", SqlDbType.Decimal).Value = numeCompra;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
