using System;
using System.Data;
using Proveedor.Entities;

namespace Proveedor.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Proveedor


        public static ProveedorEntity[] ToProveedorCollection(DataSet ds)
        {
            int n;
            ProveedorEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ProveedorEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToProveedor(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ProveedorEntity[0];
                return ret;
            }
        }

        public static ProveedorEntity ToProveedor(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToProveedor(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ProveedorEntity ToProveedor(DataRow dr)
        {
            ProveedorEntity ret = new ProveedorEntity();

            ret.LocaProv = Convert.ToInt32(dr["LOCAPROV"]);
            ret.DireProv = Convert.ToString(dr["DIREPROV"]);
            ret.RasoProv = Convert.ToString(dr["RASOPROV"]);
            ret.CuitProv = Convert.ToString(dr["CUITPROV"]);
            ret.TeleProv = Convert.ToString(dr["TELEPROV"]);
            ret.IdProv = Convert.ToInt32(dr["IDPROV"]);
            ret.EstaProv = Convert.ToBoolean(dr["ELIMINADOPROV"]);
            ret.NombLoca = Convert.ToString(dr["NOMBLOCA"]);
            ret.MailProv = Convert.ToString(dr["EMAILPROV"]);

            return ret;
        }


        #endregion      
        
    }
}
