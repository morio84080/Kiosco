using System;
using System.Data;
using Rubros.Entities;

namespace Rubros.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Rubros


        public static RubroEntity[] ToRubroCollection(DataSet ds)
        {
            int n;
            RubroEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new RubroEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToRubro(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new RubroEntity[0];
                return ret;
            }
        }

        public static RubroEntity ToRubro(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToRubro(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static RubroEntity ToRubro(DataRow dr)
        {
            RubroEntity ret = new RubroEntity();

            ret.CodiRub = Convert.ToInt32(dr["CodiRubr"]);
            ret.DescRubr = Convert.ToString(dr["DescRubr"]);
            ret.PorcGananciaRubr = Convert.ToDecimal(dr["PorcGananciaRubr"]);
            ret.ActivoRubr = Convert.ToBoolean(dr["ActivoRubr"]);

            try
            {
                ret.PorcDtoRubr = Convert.ToDecimal(dr["PorcDtoRubr"]);
            }
            catch { }

            return ret;
        }


        #endregion      
        
    }
}
