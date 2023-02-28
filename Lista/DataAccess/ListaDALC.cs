using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Lista.Entities;

namespace Lista.DataAccess
{
    public class ListaDALC : SqlDataComponent
    {
        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPListasCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPListasListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ListaEntity GetByID(int ID)
        {
            ListaEntity usEty = new ListaEntity();
            SqlCommand cmd = new SqlCommand("SPListaPorCod");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToLista(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public void Insert(ListaEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPListaAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NombList", SqlDbType.VarChar, 15).Value = Ety.NombList;
                cmd.Parameters.Add("@PorcList", SqlDbType.Real).Value = Ety.PorcList;
                cmd.Parameters.Add("@PosuList", SqlDbType.Real).Value = Ety.PosuList;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(ListaEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPListaModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodiList", SqlDbType.Int).Value = Ety.CodiList;
                cmd.Parameters.Add("@NombList", SqlDbType.VarChar, 15).Value = Ety.NombList;
                cmd.Parameters.Add("@ActivoList", SqlDbType.Bit).Value = Ety.ActivoList;
                cmd.Parameters.Add("@PorcList", SqlDbType.Real).Value = Ety.PorcList;
                cmd.Parameters.Add("@PosuList", SqlDbType.Real).Value = Ety.PosuList;

                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
