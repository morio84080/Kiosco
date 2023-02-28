using System;
using System.Collections.Generic;
using System.Text;

namespace CuentaCorriente.Entities
{
    public class SaldosEntity
    {
        private double _Compras;
        private double _Creditos;
        private double _Debitos;
        private double _Saldo;


        public SaldosEntity()
        {
            _Compras=0;
            _Creditos=0;
            _Debitos=0;
            _Saldo = 0;


        }

        public double Compras
        {
            get { return _Compras; }
            set { _Compras = value; }
        }


        public double Creditos
        {
            get { return _Creditos; }
            set { _Creditos = value; }
        }

        public double Debitos
        {
            get { return _Debitos; }
            set { _Debitos = value; }
        }
        public double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

    }
}
