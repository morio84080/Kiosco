using System;
using System.Collections.Generic;
using System.Text;

namespace Compras.Entities
{
    public class CompraEntity
    {
        private int _NumeComp;
        private DateTime _FechComp;
        private int _ProveComp;
        private double _TotalComp;
        private bool _EliminadoComp;
        private double _SubtotalComp;
        private double _IvaComp;
        private double _RetComp;
        private string _ObsComp;

        public CompraEntity()
        {
            _NumeComp = 0;
            _SubtotalComp = 0;
            _ProveComp = 0;
            _FechComp = DateTime.Now;
            _TotalComp = 0;
            _EliminadoComp = false;
            _IvaComp = 0;
            _RetComp = 0;
            _ObsComp = string.Empty;

        }

        public int NumeComp
        {
            get { return _NumeComp; }
            set { _NumeComp = value; }
        }

        public DateTime FechComp
        {
            get { return _FechComp; }
            set { _FechComp = value; }
        }
        public double SubtotalComp
        {
            get { return _SubtotalComp; }
            set { _SubtotalComp = value; }
        }

        public int ProveComp
        {
            get { return _ProveComp; }
            set { _ProveComp = value; }
        }
        public double IvaComp
        {
            get { return _IvaComp; }
            set { _IvaComp = value; }
        }

        public double RetComp
        {
            get { return _RetComp; }
            set { _RetComp = value; }
        }
        public double TotalComp
        {
            get { return _TotalComp; }
            set { _TotalComp = value; }
        }

        public bool EliminadoComp
        {
            get { return _EliminadoComp; }
            set { _EliminadoComp = value; }
        }
        public string ObsComp
        {
            get { return _ObsComp; }
            set { _ObsComp = value; }
        }
    }
}
