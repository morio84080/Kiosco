using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Entities
{
    public class VentaEntity
    {
        private long _NumeVta;
        private DateTime _FechVta;
        private string _LetraVta;
        public double _TotaVta;
        public bool _TipoVta;
        public bool _EliminadoVta;
        private long _ticketFiscal;
        private int _idClie;
        private short _TipoPagoVta;
        private string _NombreTipoPago;
        private string _CAEVta;
        private DateTime _FechVtoCAEVta;

        public VentaEntity()
        {
            _NumeVta = 0;
            _FechVta = DateTime.Now;
            _LetraVta="X";
            _TotaVta = 0;
            _EliminadoVta = false;
            _TipoVta = false; //False --> Impresora Fiscal, True --> Impresora comun
            _ticketFiscal = -1;
            _idClie = -1;
            _TipoPagoVta = 1;
            _NombreTipoPago = string.Empty;
            _CAEVta = string.Empty;
            _FechVtoCAEVta = DateTime.Now;
        }

        public long NumeVta
        {
            get { return _NumeVta; }
            set { _NumeVta = value; }
        }

        public DateTime FechVta
        {
            get { return _FechVta; }
            set { _FechVta = value; }
        }

        public string LetraVta
        {
            get { return _LetraVta; }
            set { _LetraVta = value; }
        }

        public double TotaVta
        {
            get { return _TotaVta; }
            set { _TotaVta = value; }
        }

        public bool EliminadoVta
        {
            get { return _EliminadoVta; }
            set { _EliminadoVta = value; }
        }

        public bool TipoVta
        {
            get { return _TipoVta; }
            set { _TipoVta = value; }
        }

        public long TicketFiscal
        {
            get { return _ticketFiscal; }
            set { _ticketFiscal = value; }
        }

        public int IdClie
        {
            get { return _idClie; }
            set { _idClie = value; }
        }

        public short TipoPagoVta
        {
            get { return _TipoPagoVta; }
            set { _TipoPagoVta = value; }
        }

        public string NombreTipoPago
        {
            get { return _NombreTipoPago; }
            set { _NombreTipoPago = value; }
        }
        public string CAEVta
        {
            get { return _CAEVta; }
            set { _CAEVta = value; }
        }
        public DateTime FechVtoCAEVta
        {
            get { return _FechVtoCAEVta; }
            set { _FechVtoCAEVta = value; }
        }
    }
}
