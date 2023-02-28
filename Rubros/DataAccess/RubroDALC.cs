using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Rubros.Entities;

namespace Rubros.DataAccess
{
    public class RubroDALC : SqlDataComponent
    {
        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPRubrosListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPrubroCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public void Insert(RubroEntity rEty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPRubroAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DescRubr", SqlDbType.VarChar).Value = rEty.DescRubr;
                cmd.Parameters.Add("@PorcGananciaRubr", SqlDbType.Decimal).Value = rEty.PorcGananciaRubr;
                cmd.Parameters.Add("@PorcDtoRubr", SqlDbType.Decimal).Value = rEty.PorcDtoRubr;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(RubroEntity rEty, bool actualizaPrecio)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPRubroModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodiRubr", SqlDbType.Int).Value = rEty.CodiRub;
                cmd.Parameters.Add("@DescRubr", SqlDbType.VarChar, 30).Value = rEty.DescRubr;
                cmd.Parameters.Add("@ActivoRubr", SqlDbType.Bit).Value = rEty.ActivoRubr;
                cmd.Parameters.Add("@PorcGananciaRubr", SqlDbType.Decimal).Value = rEty.PorcGananciaRubr;
                cmd.Parameters.Add("@PorcDtoRubr", SqlDbType.Decimal).Value = rEty.PorcDtoRubr;
                cmd.Parameters.Add("@ActualizaPrecio", SqlDbType.BigInt).Value = actualizaPrecio;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public RubroEntity GetByID(int rubroID)
        {
            RubroEntity usEty = new RubroEntity();
            SqlCommand cmd = new SqlCommand("SPRubroPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = rubroID;
            usEty = DataConvert.ToRubro(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

    }
}
