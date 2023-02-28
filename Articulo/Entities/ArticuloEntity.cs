using System;
using System.Collections.Generic;
using System.Text;

namespace Articulo.Entities
{
    public class ArticuloEntity
    {
        private int _RubrArti;
        private int _MarcaArti;
        private string _CoBaArti;
        private string _DescArti;
        private double _BaseArti;
        private double _SugeArti;
        private double _PorcGananciaArti;
        private decimal _PorcIVAArti;
        private bool _EstaArti;
        private int _IDArti;
        private int _StockArti;
        private string _DescRubro;
        private string _NombreMarca;
        private bool _PrintArti;
        private DateTime _FechaUpdArti;
        private int _StockMinArti;

        public ArticuloEntity()
        {
            _RubrArti = 0;
            _CoBaArti=string.Empty;
            _DescArti = string.Empty;
            _EstaArti=false;
            _BaseArti = 0;
            _SugeArti = 0;
            _IDArti = 0;
            _StockArti = 0;
            _DescRubro = string.Empty;
            _PrintArti = false;
            _PorcGananciaArti = 0;
            _PorcIVAArti = 0;
            _FechaUpdArti = System.DateTime.Now;
            _MarcaArti = 0;
            _NombreMarca = string.Empty;
            _StockMinArti = 0;
        }

        public int RubrArti
        {
            get { return _RubrArti; }
            set { _RubrArti = value; }
        }

        public int MarcaArti
        {
            get { return _MarcaArti; }
            set { _MarcaArti = value; }
        }

        public string CoBaArti
        {
            get { return _CoBaArti; }
            set { _CoBaArti = value; }
        }

        public string DescArti
        {
            get { return _DescArti; }
            set { _DescArti = value; }
        }

        public Boolean EstaArti
        {
            get { return _EstaArti; }
            set { _EstaArti = value; }
        }

        public double BaseArti
        {
            get { return _BaseArti; }
            set { _BaseArti = value; }
        }

        public double SugeArti
        {
            get { return _SugeArti; }
            set { _SugeArti = value; }
        }

        public int StockArti
        {
            get { return _StockArti; }
            set { _StockArti = value; }
        }

        public int IDArti
        {
            get { return _IDArti; }
            set { _IDArti = value; }
        }

        public string DescRubro
        {
            get { return _DescRubro; }
            set { _DescRubro= value; }
        }

        public string NombreMarca
        {
            get { return _NombreMarca; }
            set { _NombreMarca = value; }
        }

        public bool PrintArti
        {
            get { return _PrintArti; }
            set { _PrintArti = value; }
        }

        public double PorcGananciaArti
        {
            get { return _PorcGananciaArti; }
            set { _PorcGananciaArti = value; }
        }

        public decimal porcIVAArti
        {
            get { return _PorcIVAArti; }
            set { _PorcIVAArti = value; }
        }

        public DateTime FechaUpdArti
        {
            get { return _FechaUpdArti; }
            set { _FechaUpdArti = value; }
        }

        public int StockMinArti
        {
            get { return _StockMinArti; }
            set { _StockMinArti = value; }
        }
    }
}
