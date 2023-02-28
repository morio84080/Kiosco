using System;
using System.Collections.Generic;
using System.Text;

namespace Lista.Entities
{
    public class ListaEntity
    {
        private int _CodiList;
        private string _NombList;
        private double _PorcList;
        private double _PosuList;
        private bool _ActivoList;

        public ListaEntity()
        {
            _CodiList=0;
            _NombList=string.Empty;
            _ActivoList=true;
            _PorcList = 0;
            _PosuList = 0;

        }

        public int CodiList
        {
            get { return _CodiList; }
            set { _CodiList= value; }
        }

        public string NombList
        {
            get { return _NombList; }
            set { _NombList = value; }
        }

        public Boolean ActivoList
        {
            get { return _ActivoList; }
            set { _ActivoList = value; }
        }

        public double PorcList
        {
            get { return _PorcList; }
            set { _PorcList = value; }
        }

        public double PosuList
        {
            get { return _PosuList; }
            set { _PosuList = value; }
        }
    }
}
