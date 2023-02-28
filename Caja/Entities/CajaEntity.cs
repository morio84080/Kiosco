using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caja.Entities
{
    public class CajaEntity
    {
        private decimal _IdCaja;
        private DateTime _FechaCaja;
        private bool _TipoCaja; //FALSE --> INGRESO, TRUE --> EGRESO
        private int _OriDesCaja;
        private decimal _TotalCaja;
        private bool _EliminadoCaja;
        private decimal _SubtotalCaja;
        private decimal _IvaCaja;
        private decimal _PorcIvaCaja;
        private string _NroFactCaja;
        private string _DetalleCaja;
        private bool _TipoCtaCaja;

        public CajaEntity()
        {
            _IdCaja = 0;
            _SubtotalCaja = 0;
            _OriDesCaja = 0;
            _TipoCaja = false;
            _FechaCaja = DateTime.Now;
            _TotalCaja = 0;
            _EliminadoCaja = false;
            _IvaCaja = 0;
            _NroFactCaja = string.Empty;
            _DetalleCaja = string.Empty;
            _PorcIvaCaja = 0;
            _TipoCtaCaja = false;
        }

        public decimal IdCaja
        {
            get { return _IdCaja; }
            set { _IdCaja = value; }
        }

        public DateTime FechaCaja
        {
            get { return _FechaCaja; }
            set { _FechaCaja = value; }
        }
        public decimal SubtotalCaja
        {
            get { return _SubtotalCaja; }
            set { _SubtotalCaja = value; }
        }

        public bool TipoCaja
        {
            get { return _TipoCaja; }
            set { _TipoCaja = value; }
        }

        public int OriDesCaja
        {
            get { return _OriDesCaja; }
            set { _OriDesCaja = value; }
        }

        public decimal PorcIvaCaja
        {
            get { return _PorcIvaCaja; }
            set { _PorcIvaCaja = value; }
        }
        public decimal IvaCaja
        {
            get { return _IvaCaja; }
            set { _IvaCaja = value; }
        }

        public decimal TotalCaja
        {
            get { return _TotalCaja; }
            set { _TotalCaja = value; }
        }

        public bool EliminadoCaja
        {
            get { return _EliminadoCaja; }
            set { _EliminadoCaja = value; }
        }
        public string DetalleCaja
        {
            get { return _DetalleCaja; }
            set { _DetalleCaja = value; }
        }

        public string NroFactCaja
        {
            get { return _NroFactCaja; }
            set { _NroFactCaja = value; }
        }

        public bool TipoCtaCaja
        {
            get { return _TipoCtaCaja; }
            set { _TipoCtaCaja = value; }
        }
    }
}
