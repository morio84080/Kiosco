using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movimiento.Entities;
using Movimiento.DataAccess;

namespace Movimiento.Business
{
    public class MovimientoBus
    {
        public MovimientoEntity getLastMovementUpdatedByProduct(int idArti)
        {
            return new MovimientoDALC().lastMovementUpdateByProduct(idArti);
        }
    }
}
