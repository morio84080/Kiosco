using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Entities
{
    public class AlicIvaEntity
    {
        private int _id;
        private double _Importe;
        private double _BaseImp;

        public AlicIvaEntity()
        {
            _id=0;
            _Importe = 0;
            _BaseImp = 0;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        public double BaseImp
        {
            get { return _BaseImp; }
            set { _BaseImp = value; }
        }
    }
}
