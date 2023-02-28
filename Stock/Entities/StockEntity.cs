using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Entities
{
    public class StockEntity
    {
        private int _IdSTK;
        private bool _TipoIngresoSTK;
        private int _TipoMovSTK;
        private int _ArticuloSTK;
        private int _CantidadSTK;
        private DateTime _FechaSTK;
        private string _DetalleSTK;
        private bool _EliminadoSTK;
        

        public StockEntity()
        {
            _IdSTK = 0;
            _TipoIngresoSTK = true;
            _TipoMovSTK = 0;
            _ArticuloSTK = 0;
            _CantidadSTK = 0;
            _FechaSTK = DateTime.Now;
            _DetalleSTK = string.Empty;
            _EliminadoSTK = false;

        }

        public int IdSTK
        {
            get { return _IdSTK; }
            set { _IdSTK = value; }
        }

        public bool TipoIngresoSTK
        {
            get { return _TipoIngresoSTK; }
            set { _TipoIngresoSTK = value; }
        }

        public int TipoMovSTK
        {
            get { return _TipoMovSTK; }
            set { _TipoMovSTK = value; }
        }

        public int ArticuloSTK
        {
            get { return _ArticuloSTK; }
            set { _ArticuloSTK = value; }
        }

        public int CantidadSTK
        {
            get { return _CantidadSTK; }
            set { _CantidadSTK = value; }
        }
        public DateTime FechaSTK
        {
            get { return _FechaSTK; }
            set { _FechaSTK = value; }
        }

        public string DetalleSTK
        {
            get { return _DetalleSTK; }
            set { _DetalleSTK = value; }
        }

        public bool EliminadoSTK
        {
            get { return _EliminadoSTK; }
            set { _EliminadoSTK = value; }
        }

    }
}
