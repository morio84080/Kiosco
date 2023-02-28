using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Entities
{
    public class SaldosEntity
    {
        private double _Ventas;
        private double _SaldoIniClie;
        private double _CreditosClie;
        private double _DebitosClie;
        private double _Saldo;


        public SaldosEntity()
        {
            _Ventas=0;
            _SaldoIniClie=0;
            _CreditosClie=0;
            _DebitosClie=0;
            _Saldo = 0;


        }

        public double Ventas
        {
            get { return _Ventas; }
            set { _Ventas = value; }
        }

        public double SaldoIniClie
        {
            get { return _SaldoIniClie; }
            set { _SaldoIniClie = value; }
        }


        public double CreditosClie
        {
            get { return _CreditosClie; }
            set { _CreditosClie = value; }
        }


        public double DebitosClie
        {
            get { return _DebitosClie; }
            set { _DebitosClie = value; }
        }
        public double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

    }
}
