using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caja.Entities
{
    public class CierreCajaEntity
    {
        private int _IdCica;
        private DateTime _FechaCica;
        private decimal _EfectivoCica;
        private decimal _TarjCreditoCica;
        private decimal _TarjDebitoCica;
        private decimal _MercadoPagoCica;
        private decimal _CtaCteCica;
        private decimal _SaldoCica;
        private decimal _TotalVtaCica;
        private decimal _TotalNotaCreditoCica;
        private decimal _IngresoCajaCica;
        private decimal _EgresoCajaCica;


        public CierreCajaEntity()
        {
            _IdCica = 0;
            _FechaCica = DateTime.Now;
            _EfectivoCica = 0;
            _TarjCreditoCica = 0;
            _TarjDebitoCica = 0;
            _MercadoPagoCica = 0;
            _CtaCteCica = 0;
            _SaldoCica = 0;
            _TotalVtaCica = 0;
            _TotalNotaCreditoCica = 0;
            _IngresoCajaCica = 0;
            _EgresoCajaCica = 0;
        }

        public int IdCica
        {
            get { return _IdCica; }
            set { _IdCica = value; }
        }

        public DateTime FechaCica
        {
            get { return _FechaCica; }
            set { _FechaCica = value; }
        }

        public decimal EfectivoCica
        {
            get { return _EfectivoCica; }
            set { _EfectivoCica = value; }
        }

        public decimal TarjCreditoCica
        {
            get { return _TarjCreditoCica; }
            set { _TarjCreditoCica = value; }
        }

        public decimal TarjDebitoCica
        {
            get { return _TarjDebitoCica; }
            set { _TarjDebitoCica = value; }
        }

        public decimal MercadoPagoCica
        {
            get { return _MercadoPagoCica; }
            set { _MercadoPagoCica = value; }
        }

        public decimal CtaCteCica
        {
            get { return _CtaCteCica; }
            set { _CtaCteCica = value; }
        }

        public decimal SaldoCica
        {
            get { return _SaldoCica; }
            set { _SaldoCica = value; }
        }

        public decimal TotalVtaCica
        {
            get { return _TotalVtaCica; }
            set { _TotalVtaCica = value; }
        }

        public decimal TotalNotaCreditoCica
        {
            get { return _TotalNotaCreditoCica; }
            set { _TotalNotaCreditoCica = value; }
        }

        public decimal IngresoCajaCica
        {
            get { return _IngresoCajaCica; }
            set { _IngresoCajaCica = value; }
        }

        public decimal EgresoCajaCica
        {
            get { return _EgresoCajaCica; }
            set { _EgresoCajaCica = value; }
        }
    }
}
