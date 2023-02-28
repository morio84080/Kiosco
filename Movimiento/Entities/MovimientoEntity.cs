using System;
using System.Collections.Generic;
using System.Text;

namespace Movimiento.Entities
{
    public class MovimientoEntity
    {
        private int _IdMovi;
        private int _TipoMovi;
        private DateTime _FechaMovi;
        private int _VendMovi;
        private decimal _ClaveIniMovi;
        private decimal _ClaveFinMovi;
        private string _ValorIniMovi;
        private string _ValorFinMovi;
        private double _RealIniMovi;
        private double _RealFinMovi;        

        public MovimientoEntity()
        {
            _IdMovi=0;
            _TipoMovi = 0;
            _FechaMovi = DateTime.Now;
            _VendMovi = 0;
            _ClaveIniMovi = 0;
            _ClaveFinMovi = 0;
            _ValorIniMovi = string.Empty;
            _ValorFinMovi = string.Empty;
            _RealIniMovi = 0;
            _RealFinMovi = 0;

        }

        public int IdMovi
        {
            get { return _IdMovi; }
            set { _IdMovi= value; }
        }

        public int TipoMovi
        {
            get { return _TipoMovi; }
            set { _TipoMovi = value; }
        }

        public int VendMovi
        {
            get { return _VendMovi; }
            set { _VendMovi = value; }
        }

        public decimal ClaveIniMovi
        {
            get { return _ClaveIniMovi; }
            set { _ClaveIniMovi = value; }
        }
        public decimal ClaveFinMovi
        {
            get { return _ClaveFinMovi; }
            set { _ClaveFinMovi = value; }
        }
        public string ValorIniMovi
        {
            get { return _ValorIniMovi; }
            set { _ValorIniMovi = value; }
        }

        public string ValorFinMovi
        {
            get { return _ValorFinMovi; }
            set { _ValorFinMovi = value; }
        }

        public double RealIniMovi
        {
            get { return _RealIniMovi; }
            set { _RealIniMovi = value; }
        }
        
        public double RealFinMovi
        {
            get { return _RealFinMovi; }
            set { _RealFinMovi = value; }
        }

        public DateTime FechaMovi
        {
            get { return _FechaMovi; }
            set { _FechaMovi = value; }
        }

    }
}
