using System;
using System.Data;
using Vendedor.Entities;

namespace Vendedor.DataAccess
{
    public class DataConvert
    {
        public DataConvert(){}

        #region Vendedor


        public static VendedorEntity[] ToVendedorCollection(DataSet ds)
        {
            int n;
            VendedorEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new VendedorEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToVendedor(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new VendedorEntity[0];
                return ret;
            }
        }

        public static VendedorEntity ToVendedor(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToVendedor(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static VendedorEntity ToVendedor(DataRow dr)
        {
            VendedorEntity ret = new VendedorEntity();

            ret.CodiVend = Convert.ToInt32(dr["CodiVend"]);
            ret.ApelVend = Convert.ToString(dr["ApelVend"]);
            ret.EstaVend = Convert.ToBoolean(dr["EstaVend"]);
            ret.DireVend = Convert.ToString(dr["DireVend"]);
            ret.MailVend = Convert.ToString(dr["MailVend"]);
            ret.NombPerf = Convert.ToString(dr["NombPerfi"]);
            ret.NombVend = Convert.ToString(dr["NombVend"]);
            ret.PassVend = Convert.ToString(dr["PassVend"]);
            ret.TeleVend = Convert.ToString(dr["TeleVend"]);
            ret.UserVend = Convert.ToString(dr["UserVend"]);
            ret.PerfilVend = Convert.ToInt32(dr["PerfilVend"]);

            return ret;
        }


        #endregion      
    }
}
