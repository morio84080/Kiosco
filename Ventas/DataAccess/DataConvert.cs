using System;
using System.Data;
using Ventas.Entities;

namespace Ventas.DataAccess
{
    public class DataConvert
    {
        public DataConvert(){}

        #region Ventas


        public static VentaEntity[] ToVentaCollection(DataSet ds)
        {
            int n;
            VentaEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new VentaEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToVenta(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new VentaEntity[0];
                return ret;
            }
        }

        public static VentaEntity ToVenta(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToVenta(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static VentaEntity ToVenta(DataRow dr)
        {
            VentaEntity ret = new VentaEntity();

            ret.EliminadoVta = Convert.ToBoolean(dr["EliminadoVta"]);
            ret.FechVta = Convert.ToDateTime(dr["FechVta"]);
            ret.NumeVta = long.Parse(dr["NUMEVTA"].ToString());
            ret.TotaVta = Convert.ToDouble(dr["TotaVta"]);
            ret.TipoVta = Convert.ToBoolean(dr["TIPOVTA"]);
            ret.LetraVta = dr["LETRAVTA"].ToString().Trim();
            ret.TipoPagoVta = (short)Convert.ToInt32(dr["TIPOPAGOVTA"]);
            try {
                ret.TicketFiscal=long.Parse(dr["TICKETFISCALVTA"].ToString());
            }
            catch { }

            try
            {
                ret.IdClie = Convert.ToInt32(dr["IdClie"].ToString());
            }
            catch { ret.IdClie = 0; }

            try
            {
                ret.NombreTipoPago = Convert.ToString(dr["NOMBRETIPA"].ToString());
            }
            catch { ret.IdClie = 0; }
            return ret;
        }


        #endregion      

        #region Ventas-Articulos


        public static VtaArtEntity[] ToVtaArtCollection(DataSet ds)
        {
            int n;
            VtaArtEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new VtaArtEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToVtaArt(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new VtaArtEntity[0];
                return ret;
            }
        }

        public static VtaArtEntity ToVtaArt(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToVtaArt(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static VtaArtEntity ToVtaArt(DataRow dr)
        {
            VtaArtEntity ret = new VtaArtEntity();

            ret.CantVear = Convert.ToInt32(dr["CantVear"]);
            ret.PrecVear = Convert.ToDouble(dr["PrecVear"]);
            ret.ArtiVear = Convert.ToInt32(dr["ArtiVear"]);
            ret.SubtotalVear = Convert.ToDouble(dr["SubTotaVear"]);
            ret.NumeVear = long.Parse(dr["NumeVear"].ToString());
            try
            {
                ret.DescArti = Convert.ToString(dr["DESCARTI"]);    
            }
            catch { }
            try
            {
                ret.IvaVear = Convert.ToDecimal(dr["IVAVEAR"]);
            }
            catch { }
            try
            {
                ret.PorcDtoVear = Convert.ToDecimal(dr["PORCDTOVEAR"]);
            }
            catch { }
            return ret;
        }


        #endregion      
        
    }
}
