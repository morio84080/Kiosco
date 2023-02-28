using System;
using System.Collections.Generic;
using System.Text;

namespace CuentaCorriente.Entities
{
    public class CtcCteEntity
    {
        private DateTime _Fecha;
        private string _Detalle;
        private double _Importe;
        private string _Estado;
        private int _Localidad;
        private int _Cliente;
        private int _Codigo;

        public CtcCteEntity()
        {
            _Localidad=0;
            _Codigo = 0;
            _Cliente = 0;
            _Detalle=string.Empty;
            _Estado = string.Empty;
            _Importe = 0;
            _Fecha = DateTime.MinValue;
            

        }

        public int Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }

        public int Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }


        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

    }
}
