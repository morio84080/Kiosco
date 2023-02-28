using System;
using System.Data;
using Lista.Entities;

namespace Lista.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Lista


        public static ListaEntity[] ToListaCollection(DataSet ds)
        {
            int n;
            ListaEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ListaEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToLista(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ListaEntity[0];
                return ret;
            }
        }

        public static ListaEntity ToLista(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToLista(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ListaEntity ToLista(DataRow dr)
        {
            ListaEntity ret = new ListaEntity();

            ret.CodiList = Convert.ToInt32(dr["CodiList"]);
            ret.NombList = Convert.ToString(dr["NombList"]);
            ret.ActivoList = Convert.ToBoolean(dr["ActivoList"]);
            ret.PorcList = Convert.ToDouble(dr["PorcList"]);
            ret.PosuList = Convert.ToDouble(dr["PosuList"]);

            return ret;
        }


        #endregion      
        
    }
}
