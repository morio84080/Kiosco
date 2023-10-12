using System;
using System.Data;
using Marcas.Entities;

namespace Marcas.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Marcas


        public static MarcaEntity[] ToMarcaCollection(DataSet ds)
        {
            int n;
            MarcaEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new MarcaEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToMarca(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new MarcaEntity[0];
                return ret;
            }
        }

        public static MarcaEntity ToMarca(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToMarca(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static MarcaEntity ToMarca(DataRow dr)
        {
            MarcaEntity ret = new MarcaEntity();

            ret.CodiMarc = Convert.ToInt32(dr["CodiMarc"]);
            ret.DescMarc = Convert.ToString(dr["DescMarc"]);
            ret.ActivoMarc = Convert.ToBoolean(dr["ActivoMarc"]);

            return ret;
        }


        #endregion      
        
    }
}
