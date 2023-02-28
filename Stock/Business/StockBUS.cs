using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Stock.DataAccess;
using Stock.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;

namespace Stock.Business
{
    public class StockBUS
    {
        public DataTable getAllStockPorTipoMov_DT(int tipoMov)
        {
            return new StockDALC().DS_stockPorTipoMovGetAll(tipoMov).Tables[0];
        }

        public StockEntity getStockID(int id)
        {
            return new StockDALC().GetStockByID(id);
        }

        public int AlarmaStockMinimo()
        {
            return new StockDALC().AlarmaStockMinimo();
        }

        public void StockInsert(StockEntity Ety, int userId)
        {
            StockDALC stockDac = new StockDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();
            StockEntity stock = new StockEntity();


            try
            {
                stockDac.BeginTrans();
                movDac.BindTrans(stockDac.ActiveConnection, stockDac.ActiveTransaction);

                //Graba Stock 
                int stockId= stockDac.Insert(Ety);



                //Crea Moviemento
                mov.ClaveFinMovi = Ety.ArticuloSTK;
                mov.ClaveIniMovi = stockId;
                switch (Ety.TipoMovSTK)
                {
                    case 2:
                        mov.TipoMovi = 5;
                        break;
                    case 4:
                        mov.TipoMovi =7;
                        break;
                }
                mov.ValorFinMovi = Ety.CantidadSTK.ToString();
                mov.ValorIniMovi = Ety.CantidadSTK.ToString();
                mov.RealIniMovi = 0;
                mov.RealFinMovi = 0;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                stockDac.CommitTrans();

            }
            catch (Exception ex)
            {
                stockDac.RollBackTrans();
                throw ex;
            }            

        }

        public void StockEliminar(StockEntity Ety, int userId)
        {
            StockDALC stockDac = new StockDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();
            StockEntity stock = new StockEntity();


            try
            {
                stockDac.BeginTrans();
                movDac.BindTrans(stockDac.ActiveConnection, stockDac.ActiveTransaction);

                //Graba Stock 
                stockDac.Eliminar(Ety);

                //Crea Moviemento
                mov.ClaveFinMovi = Ety.ArticuloSTK;
                mov.ClaveIniMovi = Ety.IdSTK;
                switch (Ety.TipoMovSTK)
                {
                    case 2:
                        mov.TipoMovi = 6; //BAJA COMPRA
                        break;
                    case 4:
                        mov.TipoMovi = 8; //BAJA AJUSTE
                        break;
                }
                mov.ValorFinMovi = Ety.CantidadSTK.ToString();
                mov.ValorIniMovi = Ety.CantidadSTK.ToString();
                mov.RealIniMovi = 0;
                mov.RealFinMovi = 0;
                mov.VendMovi = userId;
                movDac.Insert(mov);

                stockDac.CommitTrans();

            }
            catch (Exception ex)
            {
                stockDac.RollBackTrans();
                throw ex;
            }    

        }
    }
}
