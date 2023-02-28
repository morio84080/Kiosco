using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articulo.Entities
{
    public class IdsArticuloEntity
    {
        private int _idArti;

        public IdsArticuloEntity()
        {
            _idArti = 0;
        }

        public int idArti
        {
            get { return _idArti; }
            set { _idArti = value; }
        }
    }
}
