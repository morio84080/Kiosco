using System;
using System.Data;
using Cliente.Entities;

namespace Cliente.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Cliente


        public static ClienteEntity[] ToClienteCollection(DataSet ds)
        {
            int n;
            ClienteEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ClienteEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToCliente(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ClienteEntity[0];
                return ret;
            }
        }

        public static ClienteEntity ToCliente(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToCliente(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ClienteEntity ToCliente(DataRow dr)
        {
            ClienteEntity ret = new ClienteEntity();

            ret.LocaClie = Convert.ToInt32(dr["LOCACLIE"]);
            ret.DireClie = Convert.ToString(dr["DIRECLIE"]);
            ret.RasoClie = Convert.ToString(dr["RASOCLIE"]);
            ret.CuitClie = Convert.ToString(dr["CUITCLIE"]);
            ret.TeleClie = Convert.ToString(dr["TELECLIE"]);
            ret.IdClie = Convert.ToInt32(dr["IDCLIE"]);
            ret.EstaClie = Convert.ToBoolean(dr["ELIMINADOCLIE"]);
            ret.NombLoca = Convert.ToString(dr["NOMBLOCA"]);
            ret.MailClie = Convert.ToString(dr["EMAILCLIE"]);
            ret.CondIvaClie = (short)Convert.ToInt32(dr["CONDIVACLIE"]);

            try  {ret.NombCondicionIVA= Convert.ToString(dr["NOMBRECIVA"]); }
            catch  {}

            return ret;
        }


        #endregion      
        
    }
}
