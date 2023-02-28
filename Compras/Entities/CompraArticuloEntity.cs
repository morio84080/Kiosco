using System;
using System.Collections.Generic;
using System.Text;

namespace Compras.Entities
{
    public class CompraArticuloEntity
    {
        private string _DescArti;
        private int _NumeCoar;
        private int _IdArtiCoar;
        private int _CantCoar;
        private double _PrecCoar;
        private double _TotaCoar;
        private double _PorcIVA;
        private double _PorcGanancia;
        private double _PrecioVenta;
        //private int _RubrCoar;
        //private int _ArtiCoar;


        public CompraArticuloEntity()
        {
            _DescArti = string.Empty;
            _NumeCoar = 0;
            _IdArtiCoar = 0;
            _CantCoar = 0;
            _PrecCoar = 0;
            _TotaCoar = 0;
            _PorcGanancia = 0;
            _PorcIVA = 0;
            _PrecioVenta=0;
            //_RubrCoar = 0;
            //_ArtiCoar = 0;

        }

        public string DescArti
        {
            get { return _DescArti; }
            set { _DescArti = value; }
        }


        public int NumeCoar
        {
            get { return _NumeCoar; }
            set { _NumeCoar = value; }
        }

        public int IdArtiCoar
        {
            get { return _IdArtiCoar; }
            set { _IdArtiCoar = value; }
        }

        public int CantCoar
        {
            get { return _CantCoar; }
            set { _CantCoar = value; }
        }

        public double PrecCoar
        {
            get { return _PrecCoar; }
            set { _PrecCoar = value; }
        }

        public double TotaCoar
        {
            get { return _TotaCoar; }
            set { _TotaCoar = value; }
        }

        //public int RubrCoar
        //{
        //    get { return _RubrCoar; }
        //    set { _RubrCoar = value; }
        //}

        //public int ArtiCoar
        //{
        //    get { return _ArtiCoar; }
        //    set { _ArtiCoar = value; }
        //}

        public double PorcIVA
        {
            get { return _PorcIVA; }
            set { _PorcIVA = value; }
        }

        public double PorcGanancia
        {
            get { return _PorcGanancia; }
            set { _PorcGanancia = value; }
        }

        public double PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }
    }
}
