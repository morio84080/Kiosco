using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Compras.DataAccess;
using Compras.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;

namespace Compras.Business
{
    public class CompraSystem
    {
        public DataTable getAllPorFecha_DT( DateTime FechaIni, DateTime FechaFin)
        {
            return new CompraDALC().DS_GetAllByDate(FechaIni, FechaFin).Tables[0];
        }

        public CompraArticuloEntity[] getCompArtByID(int ID)
        {
            return new CompraArticuloDALC().GetByID(ID);
        }

        public CompraEntity getCompraID(int ID)
        {
            return new CompraDALC().GetByID(ID);
        }

        public int ProcesarCompra(List<CompraArticuloEntity> listArt, CompraEntity compra, bool actualizarPrecio, int userID)
        {
            CompraDALC compraDac = new CompraDALC();
            CompraArticuloDALC compArtiDac = new CompraArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                compraDac.BeginTrans();
                movDac.BindTrans(compraDac.ActiveConnection, compraDac.ActiveTransaction);
                compArtiDac.BindTrans(compraDac.ActiveConnection, compraDac.ActiveTransaction);

                int nroCompra = compraDac.Insert(compra);

                //Crea Moviemento general de la compra
                mov.ClaveIniMovi = nroCompra;
                mov.ClaveFinMovi = compra.ProveComp;
                mov.TipoMovi = 5;
                mov.ValorIniMovi = compra.IvaComp.ToString();
                mov.ValorFinMovi = actualizarPrecio.ToString();
                mov.RealIniMovi = compra.TotalComp;
                mov.RealFinMovi = 0;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);

                foreach (CompraArticuloEntity arti in listArt)
                {
                    arti.NumeCoar = nroCompra;
                    compArtiDac.Insert(arti,actualizarPrecio);


                    //Crea Moviemento compra-Articulo
                    mov = new MovimientoEntity();
                    mov.ClaveIniMovi = nroCompra;
                    mov.ClaveFinMovi = movID;
                    mov.TipoMovi = 17; //ALTA COMPRRA-ARTICULO
                    mov.ValorIniMovi = arti.IdArtiCoar.ToString();
                    mov.ValorFinMovi = arti.PrecioVenta.ToString();
                    mov.RealIniMovi = arti.PrecCoar;
                    mov.RealFinMovi = arti.CantCoar;
                    mov.VendMovi = userID;
                    movDac.Insert(mov);

                }
                compraDac.CommitTrans();
                return nroCompra;

            }
            catch (Exception ex)
            {
                compraDac.RollBackTrans();
                throw ex;
            }
        }

        public void ModificarCompra(List<CompraArticuloEntity> listArt, List<CompraArticuloEntity> listArtOld, CompraEntity compra, bool actualizarPrecio, int userID)
        {
            CompraDALC compraDac = new CompraDALC();
            CompraArticuloDALC comArtDac = new CompraArticuloDALC();
            MovimientoDALC movDac = new MovimientoDALC();
            MovimientoEntity mov = new MovimientoEntity();

            int movID = 0;
            try
            {
                compraDac.BeginTrans();
                movDac.BindTrans(compraDac.ActiveConnection, compraDac.ActiveTransaction);
                comArtDac.BindTrans(compraDac.ActiveConnection, compraDac.ActiveTransaction);

                compraDac.Update(compra);

                //Crea Moviemento general de la compra
                mov.ClaveIniMovi = compra.NumeComp;
                mov.ClaveFinMovi = compra.ProveComp;
                mov.TipoMovi = 18; //MODIFICACION COMPRA
                mov.ValorIniMovi = compra.IvaComp.ToString();
                mov.ValorFinMovi =actualizarPrecio.ToString();
                mov.RealIniMovi = compra.TotalComp;
                mov.RealFinMovi = compra.SubtotalComp;
                mov.VendMovi = userID;
                movID = movDac.Insert(mov);


                //Vemos si hay articulos para eliminar
                foreach (CompraArticuloEntity artiOld in listArtOld)
                {
                    bool eliminar = true;
                    //Busca si es nuevo
                    foreach (CompraArticuloEntity arti in listArt)
                    {
                        if (artiOld.IdArtiCoar == arti.IdArtiCoar && artiOld.CantCoar == arti.CantCoar & artiOld.PrecCoar == arti.PrecCoar)
                        {
                            eliminar = false;
                            break;
                        }
                    }

                    if (eliminar)
                    {
                        artiOld.NumeCoar = compra.NumeComp;
                        comArtDac.Delete(artiOld);

                        //Crea Moviemento venta-Articulo
                        mov = new MovimientoEntity();
                        mov.ClaveIniMovi = compra.NumeComp;
                        mov.ClaveFinMovi = movID;
                        mov.TipoMovi = 20;
                        mov.ValorIniMovi = artiOld.IdArtiCoar.ToString();
                        mov.ValorFinMovi = string.Empty;
                        mov.RealIniMovi = artiOld.PrecCoar;
                        mov.RealFinMovi = artiOld.CantCoar;
                        mov.VendMovi = userID;
                        movDac.Insert(mov);
                    }

                }

                //Vemos si hay articulos nuevos
                foreach (CompraArticuloEntity arti in listArt)
                {
                    bool nuevo = true;
                    //Busca si es nuevo
                    foreach (CompraArticuloEntity artiOld in listArtOld)
                    {
                        if (artiOld.IdArtiCoar == arti.IdArtiCoar && artiOld.CantCoar == arti.CantCoar & artiOld.PrecCoar == arti.PrecCoar)
                        {
                            nuevo = false;
                            break;
                        }
                    }

                    if (nuevo)
                    {
                        arti.NumeCoar = compra.NumeComp;
                        comArtDac.Insert(arti,actualizarPrecio);

                        //Crea Moviemento compra-Articulo
                        mov = new MovimientoEntity();
                        mov.ClaveIniMovi = compra.NumeComp;
                        mov.ClaveFinMovi = movID;
                        mov.TipoMovi = 19;
                        mov.ValorIniMovi = arti.IdArtiCoar.ToString();
                        mov.ValorFinMovi = string.Empty;
                        mov.RealIniMovi = arti.PrecCoar;
                        mov.RealFinMovi = arti.CantCoar;
                        mov.VendMovi = userID;
                        movDac.Insert(mov);
                    }

                }

                compraDac.CommitTrans();

            }
            catch (Exception ex)
            {
                compraDac.RollBackTrans();
                throw ex;
            }
        }

        public void EiminarCompra(int numeCompra)
        {
            new CompraDALC().Delete(numeCompra);
        }
    }
}
