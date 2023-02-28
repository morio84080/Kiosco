using System;
using System.Data;
using Stock.Entities;

namespace Stock.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Stock


        public static StockEntity[] ToStockCollection(DataSet ds)
        {
            int n;
            StockEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new StockEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToStock(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new StockEntity[0];
                return ret;
            }
        }

        public static StockEntity ToStock(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToStock(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static StockEntity ToStock(DataRow dr)
        {
            StockEntity ret = new StockEntity();

            ret.ArticuloSTK = Convert.ToInt32(dr["ARTICULOSTK"]);
            ret.CantidadSTK = Convert.ToInt32(dr["CANTIDADSTK"]);
            ret.DetalleSTK = Convert.ToString(dr["DETALLESTK"]);
            ret.FechaSTK = Convert.ToDateTime(dr["FECHASTK"]);
            ret.IdSTK = Convert.ToInt32(dr["IDSTK"]);
            ret.TipoIngresoSTK = Convert.ToBoolean(dr["TIPOINGRESOSTK"]);
            ret.TipoMovSTK = Convert.ToInt32(dr["TIPOMOVSTK"]);
            ret.EliminadoSTK = Convert.ToBoolean(dr["ELIMINADOSTK"]);

            return ret;
        }


        #endregion      
        
    }
}
