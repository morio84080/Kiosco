using System;
using System.Data;
using Movimiento.Entities;

namespace Movimiento.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Movimientos


        public static MovimientoEntity[] ToMovimientoCollection(DataSet ds)
        {
            int n;
            MovimientoEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new MovimientoEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToMovimiento(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new MovimientoEntity[0];
                return ret;
            }
        }

        public static MovimientoEntity ToMovimiento(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToMovimiento(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static MovimientoEntity ToMovimiento(DataRow dr)
        {
            MovimientoEntity ret = new MovimientoEntity();

            ret.ClaveFinMovi = Convert.ToDecimal(dr["ClaveFinMovi"]);
            ret.ClaveIniMovi = Convert.ToDecimal(dr["ClaveIniMovi"]);
            ret.IdMovi = Convert.ToInt32(dr["IdMovi"]);
            ret.RealFinMovi = Convert.ToDouble(dr["RealFinMovi"]);
            ret.RealIniMovi = Convert.ToDouble(dr["RealIniMovi"]);
            ret.TipoMovi = Convert.ToInt32(dr["TipoMovi"]);
            ret.ValorFinMovi = Convert.ToString(dr["ValorFinMovi"]);
            ret.ValorIniMovi = Convert.ToString(dr["ValorIniMovi"]);
            ret.VendMovi = Convert.ToInt32(dr["VendMovi"]);
            ret.FechaMovi = Convert.ToDateTime(dr["FechaMovi"]);

            return ret;
        }


        #endregion      
        
    }
}
