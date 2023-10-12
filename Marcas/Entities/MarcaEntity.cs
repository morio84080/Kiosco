using System;
using System.Collections.Generic;
using System.Text;

namespace Marcas.Entities
{
    public class MarcaEntity
    {
        private int _CodiMarc;
        private string _DescMarc;
        private bool _ActivoMarc;

        public MarcaEntity()
        {
            _CodiMarc=0;
            _DescMarc=string.Empty;
            _ActivoMarc=true;

        }

        public int CodiMarc
        {
            get { return _CodiMarc; }
            set { _CodiMarc = value; }
        }

        public string DescMarc
        {
            get { return _DescMarc; }
            set { _DescMarc = value; }
        }

        public Boolean ActivoMarc
        {
            get { return _ActivoMarc; }
            set { _ActivoMarc = value; }
        }

    }
}
