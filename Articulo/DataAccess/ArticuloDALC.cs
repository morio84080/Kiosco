using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Xml;
using Articulo.Entities;

namespace Articulo.DataAccess
{
    public class ArticuloDALC : SqlDataComponent
    {
        public DataSet GetCombo_DS()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPArticuloCombo");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRubro(int CodiRubro)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorRubro");
            cmd.Parameters.Add("@RubrArti", SqlDbType.Int).Value = CodiRubro;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRubros(string rubros)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorRubros");
            cmd.Parameters.Add("@rubros", SqlDbType.VarChar).Value = rubros;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByCodBarra(string CodBarra)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorCoBarra");
            cmd.Parameters.Add("@CodBarra", SqlDbType.VarChar).Value = CodBarra;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }
        public DataSet DS_GetByPrint()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticulosParaPrint");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ArticuloEntity[] GetByCodRubro(int CodiRubro)
        {
            SqlCommand cmd = new SqlCommand("SParticuloPorRubro");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("RubrArti", SqlDbType.Decimal).Value = CodiRubro;
            ArticuloEntity[] Ety = DataConvert.ToArticuloCollection(this.ExecuteDataSet(cmd));
            CloseConexion();
            return Ety;
        }

        public DataSet DS_GetByLikeDesc(string Desc)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorDesc");
            cmd.Parameters.Add("@DescArti", SqlDbType.VarChar).Value = Desc;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public DataSet DS_GetByRubroAndLikeDesc(string Desc, int rubro)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorRubroAndDesc");
            cmd.Parameters.Add("@DescArti", SqlDbType.VarChar).Value = Desc;
            cmd.Parameters.Add("@RubrArti", SqlDbType.Int).Value = rubro;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ArticuloEntity GetByCodiAndRubro(int CodiRubro, int Codigo)
        {
            ArticuloEntity usEty = new ArticuloEntity();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorCodiAndRubro");
            cmd.Parameters.Add("@RubrArti", SqlDbType.Int).Value = CodiRubro;
            cmd.Parameters.Add("@CodiArti", SqlDbType.Int).Value = Codigo;
            cmd.CommandType = CommandType.StoredProcedure;
            usEty = DataConvert.ToArticulo(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }
        public ArticuloEntity GetByBarCode(string Codigo)
        {
            ArticuloEntity usEty = new ArticuloEntity();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SParticuloPorCoBarra");
            cmd.Parameters.Add("@CodBarra", SqlDbType.VarChar).Value = Codigo;
            cmd.CommandType = CommandType.StoredProcedure;
            usEty = DataConvert.ToArticulo(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public DataSet DS_GetAll()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SPArticulosListar");
            cmd.CommandType = CommandType.StoredProcedure;
            ds = this.ExecuteDataSet(cmd);
            CloseConexion();
            return ds;
        }

        public ArticuloEntity GetByID(int ID)
        {
            ArticuloEntity usEty = new ArticuloEntity();
            SqlCommand cmd = new SqlCommand("SParticuloPorID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            usEty = DataConvert.ToArticulo(this.ExecuteDataSet(cmd));
            CloseConexion();
            return usEty;
        }

        public int Insert(ArticuloEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPArticuloAgregar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RubrArti", SqlDbType.Int).Value = Ety.RubrArti;
                cmd.Parameters.Add("@MarcaArti", SqlDbType.Int).Value = Ety.MarcaArti;
                cmd.Parameters.Add("@CobaArti", SqlDbType.VarChar).Value = Ety.CoBaArti;
                cmd.Parameters.Add("@DescArti", SqlDbType.VarChar).Value = Ety.DescArti;
                cmd.Parameters.Add("@BaseArti", SqlDbType.Real).Value = Ety.BaseArti;
                cmd.Parameters.Add("@SugeArti", SqlDbType.Real).Value = Ety.SugeArti;
                cmd.Parameters.Add("@PorcGananciaArti", SqlDbType.Real).Value = Ety.PorcGananciaArti;
                cmd.Parameters.Add("@PorcIvaArti", SqlDbType.Decimal).Value = Ety.porcIVAArti;
                cmd.Parameters.Add("@StockArti", SqlDbType.Int).Value = Ety.StockArti;
                cmd.Parameters.Add("@StockMinArti", SqlDbType.Int).Value = Ety.StockMinArti;
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

        public void Update(ArticuloEntity Ety)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPArticuloModificar");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RubrArti", SqlDbType.Int).Value = Ety.RubrArti;
                cmd.Parameters.Add("@MarcaArti", SqlDbType.Int).Value = Ety.MarcaArti;
                cmd.Parameters.Add("@CobaArti", SqlDbType.VarChar).Value = Ety.CoBaArti;
                cmd.Parameters.Add("@DescArti", SqlDbType.VarChar).Value = Ety.DescArti;
                cmd.Parameters.Add("@BaseArti", SqlDbType.Real).Value = Ety.BaseArti;
                cmd.Parameters.Add("@PorcGananciaArti", SqlDbType.Real).Value = Ety.PorcGananciaArti;
                cmd.Parameters.Add("@PorcIvaArti", SqlDbType.Decimal).Value = Ety.porcIVAArti;
                cmd.Parameters.Add("@SugeArti", SqlDbType.Real).Value = Ety.SugeArti;
                cmd.Parameters.Add("@StockArti", SqlDbType.Int).Value = Ety.StockArti;
                cmd.Parameters.Add("@IdArti", SqlDbType.Int).Value = Ety.IDArti;
                cmd.Parameters.Add("@EstaArti", SqlDbType.Bit).Value = Ety.EstaArti;
                cmd.Parameters.Add("@PrintArti", SqlDbType.Bit).Value = Ety.PrintArti;
                cmd.Parameters.Add("@StockMinArti", SqlDbType.Int).Value = Ety.StockMinArti;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SetPrint(int idArti, bool print)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPsetArticuloPrint");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idArti", SqlDbType.Int).Value = idArti;
                cmd.Parameters.Add("@print", SqlDbType.Bit).Value = print;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ActualizarPrecioPorTipo(int idArti, short tipoUpdate, decimal valor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SPactualizarPrecioPorTipo");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idArti", SqlDbType.Int).Value = idArti;
                cmd.Parameters.Add("@tipoUpd", SqlDbType.SmallInt).Value = tipoUpdate;
                cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
                this.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int NextCodiArti(int RubrArti)
        {
            try
            {
                SqlCommand comm = new SqlCommand("SPproximoCodiArti");
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@RubrArti", SqlDbType.Int));
                comm.Parameters["@RubrArti"].Value = RubrArti;
                comm.Parameters.Add(new SqlParameter("@ret", SqlDbType.Int));
                comm.Parameters["@ret"].Direction = ParameterDirection.Output;
                this.ExecuteNonQuery(comm);
                int resp = Convert.ToInt32(comm.Parameters["@ret"].Value);
                CloseConexion();
                return resp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
