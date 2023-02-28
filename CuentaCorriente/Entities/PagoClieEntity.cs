using System;
using System.Collections.Generic;
using System.Text;

namespace CuentaCorriente.Entities
{
    public class PagoClieEntity
    {
        private int _NumePACL;
        private DateTime _FechaPACL;
        private int _CliePACL;
        private string _DetaPACL;
        private double _ImpoPACL;
        private string _NombLoca;
        private string _RasoClie;
        private bool _EliminadoPACL;
        private short _TipoPACL;
        private string _NombTipoPago;

        public PagoClieEntity()
        {

            _NumePACL=0;
            _FechaPACL=DateTime.Now;
            _CliePACL=0;
            _DetaPACL=string.Empty;
            _ImpoPACL=0;
            _RasoClie = string.Empty;
            _NombLoca = string.Empty;
            _EliminadoPACL = false;
            _TipoPACL = 1;
            _NombTipoPago = string.Empty;

        }

        public int NumePACL
        {
            get { return _NumePACL; }
            set { _NumePACL = value; }
        }

        public DateTime FechaPACL
        {
            get { return _FechaPACL; }
            set { _FechaPACL = value; }
        }
        public int CliePACL
        {
            get { return _CliePACL; }
            set { _CliePACL = value; }
        }

        public string DetaPACL
        {
            get { return _DetaPACL; }
            set { _DetaPACL = value; }
        }

        public double ImpoPACL
        {
            get { return _ImpoPACL; }
            set { _ImpoPACL = value; }
        }

        public string RasoClie
        {
            get { return _RasoClie; }
            set { _RasoClie = value; }
        }

        public string NombLoca
        {
            get { return _NombLoca; }
            set { _NombLoca = value; }
        }

        public bool EliminadoPACL
        {
            get { return _EliminadoPACL; }
            set { _EliminadoPACL = value; }
        }

        public short TipoPACL
        {
            get { return _TipoPACL; }
            set { _TipoPACL = value; }
        }

        public string NombTipoPago
        {
            get { return _NombTipoPago; }
            set { _NombTipoPago = value; }
        }
    }
}
