using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Users.Entities
{
    public class UserEntity
    {
        private int _CodigoVend;
        private int _PerfilVend;
        private string _ApelVend;
        private string _NombVend;
        private string _DireVend;
        private string _TeleVend;
        private string _UserVend;
        private string _PassVend;
        private string _NombPerfil;
        private Boolean _EstaVend;

        public UserEntity()
        {
            _CodigoVend=0;
            _PerfilVend=0;
            _ApelVend=string.Empty;
            _NombVend=string.Empty;
            _DireVend=string.Empty;
            _TeleVend=string.Empty;
            _EstaVend=true;
            _UserVend = string.Empty;
            _PassVend = string.Empty;
            _NombPerfil = string.Empty;

        }

        public int CodigoVend
        {
            get { return _CodigoVend; }
            set { _CodigoVend = value; }
        }

        public int PerfilVend
        {
            get { return _PerfilVend; }
            set { _PerfilVend = value; }
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

        public Boolean EstaVend
        {
            get { return _EstaVend; }
            set { _EstaVend = value; }
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

        public string NombPerfil
        {
            get { return _NombPerfil; }
            set { _NombPerfil = value; }
        }

    }
}
