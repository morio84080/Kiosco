using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventas.Entities
{
    public class ImpuestoInternoEntity
    {
        private decimal _ImpuestoInterno;
        private decimal _Neto;
        private decimal _Iva;

        public ImpuestoInternoEntity()
        {
            _ImpuestoInterno = 0;
            _Neto = 0;
            _Iva = 0;
        }

        public decimal ImpuestoInterno
        {
            get { return _ImpuestoInterno; }
            set { _ImpuestoInterno = value; }
        }

        public decimal Neto
        {
            get { return _Neto; }
            set { _Neto = value; }
        }

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }
    }
}
