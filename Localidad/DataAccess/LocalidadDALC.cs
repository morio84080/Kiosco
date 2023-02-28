using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Localidad.Entities;

namespace Localidad.DataAccess
{
    public class LocalidadDALC : SqlDataComponent
    {
        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPlocalidadesCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPlocalidadesListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public LocalidadEntity GetByID(int ID)
        {
            LocalidadEntity usEty = new LocalidadEntity();
            SqlCommand cmd = new SqlCommand("SPLocalidadPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToLocalidad(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public void Insert(LocalidadEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPLocalidadAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NombLoca", SqlDbType.VarChar, 30).Value = Ety.NombLoca;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(LocalidadEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPLocalidadModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodiLoca", SqlDbType.Int).Value = Ety.CodiLoca;
                cmd.Parameters.Add("@NombLoca", SqlDbType.VarChar, 30).Value = Ety.NombLoca;
                cmd.Parameters.Add("@ActivoLoca", SqlDbType.Bit).Value = Ety.ActivoLoca;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
