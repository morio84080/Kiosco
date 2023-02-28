using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proveedor.Entities
{
    public class ProveedorEntity
    {
        private int _LocaProv;
        private string _CuitProv;
        private string _DireProv;
        private string _TeleProv;
        private string _RasoProv;
        private string _MailProv;
        private bool _EstaProv;
        private int _IdProv;
        private string _NombLoca;

        public ProveedorEntity()
        {
            _RasoProv=string.Empty;
            _EstaProv=false;
            _LocaProv = 0;
            _CuitProv = string.Empty;
            _DireProv = string.Empty;
            _TeleProv = string.Empty;
            _MailProv = string.Empty;
            _IdProv = 0;
            _NombLoca = string.Empty;

        }

        public int LocaProv
        {
            get { return _LocaProv; }
            set { _LocaProv = value; }
        }

        public string RasoProv
        {
            get { return _RasoProv; }
            set { _RasoProv = value; }
        }

        public string CuitProv
        {
            get { return _CuitProv; }
            set { _CuitProv = value; }
        }
        public string DireProv
        {
            get { return _DireProv; }
            set { _DireProv = value; }
        }

        public string NombLoca
        {
            get { return _NombLoca; }
            set { _NombLoca = value; }
        }
        public string TeleProv
        {
            get { return _TeleProv; }
            set { _TeleProv = value; }
        }

        public string MailProv
        {
            get { return _MailProv; }
            set { _MailProv = value; }
        }

        public Boolean EstaProv
        {
            get { return _EstaProv; }
            set { _EstaProv = value; }
        }

        public int IdProv
        {
            get { return _IdProv; }
            set { _IdProv = value; }
        }

    }
}
