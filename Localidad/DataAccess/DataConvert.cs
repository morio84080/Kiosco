using System;
using System.Data;
using Localidad.Entities;

namespace Localidad.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Localidad


        public static LocalidadEntity[] ToLocalidadCollection(DataSet ds)
        {
            int n;
            LocalidadEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new LocalidadEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToLocalidad(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new LocalidadEntity[0];
                return ret;
            }
        }

        public static LocalidadEntity ToLocalidad(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToLocalidad(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static LocalidadEntity ToLocalidad(DataRow dr)
        {
            LocalidadEntity ret = new LocalidadEntity();

            ret.CodiLoca = Convert.ToInt32(dr["CodiLoca"]);
            ret.NombLoca = Convert.ToString(dr["NombLoca"]);
            ret.ActivoLoca = Convert.ToBoolean(dr["ActivoLoca"]);

            return ret;
        }


        #endregion      
        
    }
}
