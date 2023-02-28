using System;
using System.Collections.Generic;
using System.Text;

namespace Vendedor.Entities
{
    public class VendedorEntity
    {
        private int _CodiVend;
        private string _ApelVend;
        private string _NombVend;
        private string _DireVend;
        private string _TeleVend;
        private string _MailVend;
        private string _UserVend;
        private string _PassVend;
        private int _PerfilVend;
        private bool _EstaVend;
        private string _NombPerf;

        public VendedorEntity()
        {
            _CodiVend=0;
            _NombVend=string.Empty;
            _DireVend = string.Empty;
            _ApelVend = string.Empty;
            _TeleVend = string.Empty;
            _MailVend = string.Empty;
            _UserVend = string.Empty;
            _PassVend = string.Empty;
            _PerfilVend = -1;
            _EstaVend = true;
            _NombPerf = string.Empty;

        }

        public int CodiVend
        {
            get { return _CodiVend; }
            set { _CodiVend = value; }
        }

        public string ApelVend
        {
            get { return _ApelVend; }
            set { _ApelVend = value; }
        }

        public string NombVend
        {
            get { return _NombVend; }
            set { _NombVend = value; }
        }

        public string DireVend
        {
            get { return _DireVend; }
            set { _DireVend = value; }
        }
        public string TeleVend
        {
            get { return _TeleVend; }
            set { _TeleVend = value; }
        }

        public string MailVend
        {
            get { return _MailVend; }
            set { _MailVend = value; }
        }

        public string UserVend
        {
            get { return _UserVend; }
            set { _UserVend = value; }
        }

        public string PassVend
        {
            get { return _PassVend; }
            set { _PassVend = value; }
        }
        public string NombPerf
        {
            get { return _NombPerf; }
            set { _NombPerf = value; }
        }

        public int PerfilVend
        {
            get { return _PerfilVend; }
            set { _PerfilVend = value; }
        }

        public Boolean EstaVend
        {
            get { return _EstaVend; }
            set { _EstaVend = value; }
        }
    }
}
