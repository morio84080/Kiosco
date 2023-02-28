using System;
using System.Data;
using Articulo.Entities;

namespace Articulo.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Articulo


        public static ArticuloEntity[] ToArticuloCollection(DataSet ds)
        {
            int n;
            ArticuloEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ArticuloEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToArticulo(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ArticuloEntity[0];
                return ret;
            }
        }

        public static ArticuloEntity ToArticulo(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToArticulo(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ArticuloEntity ToArticulo(DataRow dr)
        {
            ArticuloEntity ret = new ArticuloEntity();

            ret.RubrArti = Convert.ToInt32(dr["RubrArti"]);
            ret.MarcaArti = Convert.ToInt32(dr["MarcaArti"]);
            ret.CoBaArti = Convert.ToString(dr["CoBaArti"]);
            ret.DescArti = Convert.ToString(dr["DescArti"]);
            ret.EstaArti = Convert.ToBoolean(dr["EstaArti"]);
            ret.BaseArti = Convert.ToDouble(dr["BaseArti"]);
            try
            { ret.SugeArti = Convert.ToDouble(dr["SugeArti"]); }
            catch { ret.SugeArti = 0; }
            ret.IDArti = Convert.ToInt32(dr["IDArti"]);
            ret.StockArti = Convert.ToInt32(dr["StockArti"]);
            ret.StockMinArti = Convert.ToInt32(dr["StockMinArti"]);
            try { ret.DescRubro = Convert.ToString(dr["DescRubr"]); } catch { }
            try { ret.FechaUpdArti = Convert.ToDateTime(dr["FechaUpdArti"]); }
            catch { }
            try
            {
                ret.PrintArti = Convert.ToBoolean(dr["PrintArti"]);
            }
            catch { }
            try
            {
                ret.PorcGananciaArti = Convert.ToDouble(dr["PorcGananciaArti"]);
            }
            catch { }
            try
            {
                ret.porcIVAArti = Convert.ToDecimal(dr["PORCIVAARTI"]);
            }
            catch { }

            return ret;
        }


        #endregion      
        
    }
}
