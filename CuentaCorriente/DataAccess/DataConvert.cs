using System;
using System.Data;
using CuentaCorriente.Entities;

namespace CuentaCorriente.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region PagoClie


        public static PagoClieEntity[] ToPagoClieCollection(DataSet ds)
        {
            int n;
            PagoClieEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new PagoClieEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToPagoClie(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new PagoClieEntity[0];
                return ret;
            }
        }

        public static PagoClieEntity ToPagoClie(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToPagoClie(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static PagoClieEntity ToPagoClie(DataRow dr)
        {
            PagoClieEntity ret = new PagoClieEntity();

            ret.FechaPACL = Convert.ToDateTime(dr["FECHPACL"]);
            ret.ImpoPACL = Convert.ToDouble(dr["IMPOPACL"]);
            ret.NumePACL = Convert.ToInt32(dr["NUMEPACL"].ToString());
            ret.CliePACL = Convert.ToInt32(dr["CLIEPACL"]);
            ret.DetaPACL = Convert.ToString(dr["DETAPACL"]);
            ret.EliminadoPACL = Convert.ToBoolean(dr["ELIMINADOPACL"]);
            try { ret.RasoClie = Convert.ToString(dr["RASOCLIE"]); }
            catch { }
            return ret;
        }


        #endregion      
        
    }
}
