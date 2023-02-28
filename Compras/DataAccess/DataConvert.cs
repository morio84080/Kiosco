using System;
using System.Data;
using Compras.Entities;

namespace Compras.DataAccess
{
    public class DataConvert
    {
        public DataConvert(){}

        #region Compras


        public static CompraEntity[] ToCompraCollection(DataSet ds)
        {
            int n;
            CompraEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new CompraEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToCompra(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new CompraEntity[0];
                return ret;
            }
        }

        public static CompraEntity ToCompra(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToCompra(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static CompraEntity ToCompra(DataRow dr)
        {
            CompraEntity ret = new CompraEntity();

            ret.EliminadoComp = Convert.ToBoolean(dr["ELIMINADOCOMP"]);
            ret.FechComp = Convert.ToDateTime(dr["FECHACOMP"]);
            ret.NumeComp = Convert.ToInt32(dr["IDCOMP"].ToString());
            ret.ProveComp = Convert.ToInt32(dr["PROVCOMP"].ToString());
            ret.TotalComp = Convert.ToDouble(dr["TOTALCOMP"]);
            ret.SubtotalComp = Convert.ToDouble(dr["SUBTOTCOMP"]);
            ret.IvaComp = Convert.ToDouble(dr["IVACOMP"]);
            ret.RetComp = Convert.ToDouble(dr["RETENCIONCOMP"]);
            ret.ObsComp = Convert.ToString(dr["OBSERVACOMP"]);
            return ret;
        }


        #endregion      

        #region Compras-Articulos


        public static CompraArticuloEntity[] ToCompraArticuloCollection(DataSet ds)
        {
            int n;
            CompraArticuloEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new CompraArticuloEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToCompraArticulo(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new CompraArticuloEntity[0];
                return ret;
            }
        }

        public static CompraArticuloEntity ToCompraArticulo(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToCompraArticulo(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static CompraArticuloEntity ToCompraArticulo(DataRow dr)
        {
            CompraArticuloEntity ret = new CompraArticuloEntity();

            ret.CantCoar = Convert.ToInt32(dr["CANTCOAR"]);
            ret.PrecCoar = Convert.ToDouble(dr["PRECIOCOAR"]);
            ret.TotaCoar = Convert.ToDouble(dr["TOTACOAR"]);
            ret.IdArtiCoar = Convert.ToInt32(dr["ARTICOAR"]);
            ret.NumeCoar = Convert.ToInt32(dr["IDCOMPCOAR"].ToString());
            try
            {
                ret.DescArti = Convert.ToString(dr["DESCARTI"]);    
            }
            catch { }
            return ret;
        }


        #endregion      
        
    }
}
