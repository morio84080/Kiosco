using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ventas.DataAccess;
using Ventas.Entities;
using Movimiento.DataAccess;
using Movimiento.Entities;


namespace Ventas.Business
{
    public class VtaArtBUS
    {


        public VtaArtEntity[] getVtaArtByID(decimal ID)
        {
            return new VtaArtDALC().GetByID(ID);
        }

    }
}
