using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliente.Entities
{
    public class ClienteEntity
    {
        private int _LocaClie;
        private string _CuitClie;
        private string _DireClie;
        private string _TeleClie;
        private string _RasoClie;
        private string _MailClie;
        private bool _EstaClie;
        private int _IdClie;
        private string _NombLoca;
        private short _CondIvaClie;
        private string _NombCondicionIVA;

        public ClienteEntity()
        {
            _RasoClie=string.Empty;
            _EstaClie=false;
            _LocaClie = 0;
            _CuitClie = string.Empty;
            _DireClie = string.Empty;
            _TeleClie = string.Empty;
            _MailClie = string.Empty;
            _IdClie = 0;
            _NombLoca = string.Empty;
            _CondIvaClie = 0;
            _NombCondicionIVA = "CONSUMIDOR FINAL";
        }

        public int LocaClie
        {
            get { return _LocaClie; }
            set { _LocaClie = value; }
        }

        public string RasoClie
        {
            get { return _RasoClie; }
            set { _RasoClie = value; }
        }

        public string CuitClie
        {
            get { return _CuitClie; }
            set { _CuitClie = value; }
        }
        public string DireClie
        {
            get { return _DireClie; }
            set { _DireClie = value; }
        }

        public string NombLoca
        {
            get { return _NombLoca; }
            set { _NombLoca = value; }
        }
        public string TeleClie
        {
            get { return _TeleClie; }
            set { _TeleClie = value; }
        }

        public string MailClie
        {
            get { return _MailClie; }
            set { _MailClie = value; }
        }

        public Boolean EstaClie
        {
            get { return _EstaClie; }
            set { _EstaClie = value; }
        }

        public int IdClie
        {
            get { return _IdClie; }
            set { _IdClie = value; }
        }

        public short CondIvaClie
        {
            get { return _CondIvaClie; }
            set { _CondIvaClie = value; }
        }
        public string NombCondicionIVA
        {
            get { return _NombCondicionIVA; }
            set { _NombCondicionIVA = value; }
        }
    }
}
