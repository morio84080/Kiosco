using System;
using System.Data;
using FacturaElectronica.Entities;

namespace FacturaElectronica.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region FacturaElectronica
        
        public static LoginEntity[] ToLoginCollection(DataSet ds)
        {
            int n;
            LoginEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new LoginEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToLogin(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new LoginEntity[0];
                return ret;
            }
        }

        public static LoginEntity ToLogin(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToLogin(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static LoginEntity ToLogin(DataRow dr)
        {
            LoginEntity ret = new LoginEntity();

            ret.id = (short) Convert.ToInt32( (dr["id"]));
            ret.sign = Convert.ToString(dr["sign"]);
            ret.token = Convert.ToString(dr["token"]);
            ret.expirationTime = Convert.ToDateTime(dr["expirationTime"]);
            ret.generationTime = Convert.ToDateTime(dr["generationTime"]);

            return ret;
        }


        #endregion      
        
    }
}
