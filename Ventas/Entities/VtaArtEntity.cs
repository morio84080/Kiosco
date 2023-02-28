using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Entities
{
    public class VtaArtEntity
    {
        private decimal _NumeVear;
        private int _ArtiVear;
        private string _DescArti;
        private double _PrecVear;
        private int _CantVear;
        private double _SubTotalVear;
        private decimal _IvaVear;
        private decimal _PorcDtoVear;
        

        public VtaArtEntity()
        {
            _NumeVear = 0;
            _ArtiVear = 0;
            _DescArti = string.Empty;
            _PrecVear = 0;
            _CantVear = 0;
            _SubTotalVear = 0;
            _IvaVear =0;
            _PorcDtoVear = 0;
        }

        public decimal NumeVear
        {
            get { return _NumeVear; }
            set { _NumeVear = value; }
        }

        public int ArtiVear
        {
            get { return _ArtiVear; }
            set { _ArtiVear = value; }
        }


        public string DescArti
        {
            get { return _DescArti; }
            set { _DescArti = value; }
        }

        public double PrecVear
        {
            get { return _PrecVear; }
            set { _PrecVear = value; }
        }
        public int CantVear
        {
            get { return _CantVear; }
            set { _CantVear = value; }
        }

        public double SubtotalVear
        {
            get { return _SubTotalVear; }
            set { _SubTotalVear = value; }
        }

        public decimal IvaVear
        {
            get { return _IvaVear; }
            set { _IvaVear = value; }
        }

        public decimal PorcDtoVear
        {
            get { return _PorcDtoVear; }
            set { _PorcDtoVear = value; }
        }
    }
}
