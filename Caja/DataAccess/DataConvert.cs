using System;
using System.Data;
using Caja.Entities;

namespace Caja.DataAccess
{
    public class DataConvert
    {
        public DataConvert() { }

        #region Caja


        public static CajaEntity[] ToCajaCollection(DataSet ds)
        {
            int n;
            CajaEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new CajaEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToCaja(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new CajaEntity[0];
                return ret;
            }
        }

        public static CajaEntity ToCaja(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToCaja(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static CajaEntity ToCaja(DataRow dr)
        {
            CajaEntity ret = new CajaEntity();

            ret.EliminadoCaja = Convert.ToBoolean(dr["ELIMINADOCAJA"]);
            ret.FechaCaja = Convert.ToDateTime(dr["FECHACAJA"]);
            ret.IdCaja = Convert.ToDecimal(dr["IDCAJA"].ToString());
            ret.OriDesCaja = Convert.ToInt32(dr["ORIDESCAJA"].ToString());
            ret.PorcIvaCaja = Convert.ToDecimal(dr["PORCIVACAJA"]);
            ret.TotalCaja = Convert.ToDecimal(dr["TOTALCAJA"]);
            ret.SubtotalCaja = Convert.ToDecimal(dr["SUBTOTALCAJA"]);
            ret.IvaCaja = Convert.ToDecimal(dr["IVACAJA"]);
            ret.DetalleCaja = Convert.ToString(dr["DETALLECAJA"]);
            ret.TipoCaja = Convert.ToBoolean(dr["TIPOCAJA"]);
            ret.NroFactCaja = Convert.ToString(dr["NROFACTCAJA"]);
            return ret;
        }


        #endregion      

        #region Cierre Caja


        public static CierreCajaEntity[] ToCierreCajaCollection(DataSet ds)
        {
            int n;
            CierreCajaEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new CierreCajaEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToCierreCaja(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new CierreCajaEntity[0];
                return ret;
            }
        }

        public static CierreCajaEntity ToCierreCaja(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToCierreCaja(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static CierreCajaEntity ToCierreCaja(DataRow dr)
        {
            CierreCajaEntity ret = new CierreCajaEntity();

            ret.IdCica = Convert.ToInt32(dr["IDCICA"].ToString());
            ret.FechaCica = Convert.ToDateTime(dr["FECHACICA"]);
            ret.EfectivoCica = Convert.ToDecimal(dr["EFECTIVOCICA"].ToString());
            ret.TarjDebitoCica = Convert.ToDecimal(dr["TARJDEBITOCICA"]);
            ret.TarjCreditoCica = Convert.ToDecimal(dr["TARJCREDITOCICA"]);
            ret.MercadoPagoCica = Convert.ToDecimal(dr["MERCADOPAGOCICA"]);
            ret.CtaCteCica = Convert.ToDecimal(dr["CTACTECICA"]);
            ret.SaldoCica = Convert.ToDecimal(dr["SALDOCICA"]);
            ret.TotalVtaCica = Convert.ToDecimal(dr["TOTALVTACICA"]);
            ret.TotalNotaCreditoCica = Convert.ToDecimal(dr["TOTALNOTACREDITOCICA"]);
            ret.IngresoCajaCica = Convert.ToDecimal(dr["INGRESOSCAJACICA"]);
            ret.EgresoCajaCica= Convert.ToDecimal(dr["EGRESOSCAJACICA"]);

            return ret;
        }


        #endregion      
    }
}
