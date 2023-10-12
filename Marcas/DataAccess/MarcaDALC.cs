using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Marcas.Entities;

namespace Marcas.DataAccess
{
    public class MarcaDALC : SqlDataComponent
    {
        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPMarcasListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPMarcaCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public void Insert(MarcaEntity rEty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPMarcaAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DescMarc", SqlDbType.VarChar, 30).Value = rEty.DescMarc;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(MarcaEntity rEty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPMarcaModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodiMarc", SqlDbType.Int).Value = rEty.CodiMarc;
                cmd.Parameters.Add("@DescMarc", SqlDbType.VarChar, 30).Value = rEty.DescMarc;
                cmd.Parameters.Add("@ActivoMarc", SqlDbType.Bit).Value = rEty.ActivoMarc;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public MarcaEntity GetByID(int MarcaID)
        {
            MarcaEntity usEty = new MarcaEntity();
            SqlCommand cmd = new SqlCommand("SPMarcaPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = MarcaID;
            usEty = DataConvert.ToMarca(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

    }
}
