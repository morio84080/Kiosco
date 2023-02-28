using System;
using System.Collections.Generic;
using System.Text;

namespace Rubros.Entities
{
    public class RubroEntity
    {
        private int _CodiRubr;
        private string _DescRubr;
        private decimal _PorcGanancia;
        private bool _ActivoRubr;
        private decimal _PorcDtoRubr;

        public RubroEntity()
        {
            _CodiRubr=0;
            _DescRubr=string.Empty;
            _PorcGanancia = 0;
            _ActivoRubr=true;
            _PorcDtoRubr = 0;

        }

        public int CodiRub
        {
            get { return _CodiRubr; }
            set { _CodiRubr = value; }
        }

        public string DescRubr
        {
            get { return _DescRubr; }
            set { _DescRubr = value; }
        }

        public decimal PorcGananciaRubr
        {
            get { return _PorcGanancia; }
            set { _PorcGanancia = value; }
        }

        public Boolean ActivoRubr
        {
            get { return _ActivoRubr; }
            set { _ActivoRubr = value; }
        }

        public decimal PorcDtoRubr
        {
            get { return _PorcDtoRubr; }
            set { _PorcDtoRubr = value; }
        }

    }
}
