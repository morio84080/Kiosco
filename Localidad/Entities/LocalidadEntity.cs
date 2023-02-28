using System;
using System.Collections.Generic;
using System.Text;

namespace Localidad.Entities
{
    public class LocalidadEntity
    {
        private int _CodiLoca;
        private string _NombLoca;
        private bool _ActivoLoca;

        public LocalidadEntity()
        {
            _CodiLoca=0;
            _NombLoca=string.Empty;
            _ActivoLoca=true;

        }

        public int CodiLoca
        {
            get { return _CodiLoca; }
            set { _CodiLoca = value; }
        }

        public string NombLoca
        {
            get { return _NombLoca; }
            set { _NombLoca = value; }
        }

        public Boolean ActivoLoca
        {
            get { return _ActivoLoca; }
            set { _ActivoLoca = value; }
        }
    }
}
