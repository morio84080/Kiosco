using System;
using System.Collections.Generic;
using System.Text;
using Localidad.Entities;
using Cliente.Entities;
using Rubros.Entities;
using Articulo.Entities;
using Proveedor.Entities;
using Marcas.Entities;

namespace Minimercado
{
    static class GlobalClass
    {
        private static string m_globalVar = string.Empty;
        private static int _IntPrimaryKey = 0;
        private static int _IntPrimaryKey2 = 0;
        private static int _IntPrimaryKey3 = 0;
        private static long _LongPrimaryKey = 0;
        private static int _ActionType = 0;
        private static int _LastActionType = 0;
        private static int _userID = 0;
        private static int _codiRubro = 0;
        private static int _codiLoca = 0;
        private static Boolean _sAdvanced = false;
        private static string _SQLstring = string.Empty;
        private static string _Text = string.Empty;
        private static ArticuloEntity _artiGlobal;
        private static LocalidadEntity _locaGlobal;
        private static ClienteEntity _clieGlobal;
        private static RubroEntity _rubroGlobal;
        private static ProveedorEntity _provGlobal;
        private static MarcaEntity _marcaGlobal;
        private static string _UserRS;
        private static string _PasswordRS;
        private static string _RS_url;
        private static bool _tipoCaja;
        private static decimal _DecimalNumber = 0;

        public static string GlobalVar
        {
            get { return m_globalVar; }
            set { m_globalVar = value; }
        }

        public static string SQLstring
        {
            get { return _SQLstring; }
            set { _SQLstring = value; }
        }

        public static int IntPrimaryKey
        {
            get { return _IntPrimaryKey; }
            set { _IntPrimaryKey = value; }
        }

        public static int CodiRubro
        {
            get { return _codiRubro; }
            set { _codiRubro = value; }
        }

        public static int CodiLoca
        {
            get { return _codiLoca; }
            set { _codiLoca = value; }
        }

        public static int IntPrimaryKey2
        {
            get { return _IntPrimaryKey2; }
            set { _IntPrimaryKey2 = value; }
        }

        public static int IntPrimaryKey3
        {
            get { return _IntPrimaryKey3; }
            set { _IntPrimaryKey3 = value; }
        }

        public static long LongPrimaryKey
        {
            get { return _LongPrimaryKey; }
            set { _LongPrimaryKey = value; }
        }

        public static int ActionType
        {
            get { return _ActionType; }
            set { _ActionType = value; }
        }
        public static int LastActionType
        {
            get { return _LastActionType; }
            set { _LastActionType = value; }
        }

        public static int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public static Boolean sAdvanced
        {
            get { return _sAdvanced; }
            set { _sAdvanced = value; }
        }

        public static string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        public static ArticuloEntity artiGlobal
        {
            get { return _artiGlobal; }
            set { _artiGlobal = value; }
        }

        public static LocalidadEntity locaGlobal
        {
            get { return _locaGlobal; }
            set { _locaGlobal = value; }
        }

        public static ClienteEntity clieGlobal
        {
            get { return _clieGlobal; }
            set { _clieGlobal = value; }
        }

        public static RubroEntity rubroGlobal
        {
            get { return _rubroGlobal; }
            set { _rubroGlobal = value; }
        }

        public static ProveedorEntity provGlobal
        {
            get { return _provGlobal; }
            set { _provGlobal = value; }
        }

        public static MarcaEntity marcaGlobal
        {
            get { return _marcaGlobal; }
            set { _marcaGlobal = value; }
        }
        public static string UserRS
        {
            get { return _UserRS; }
            set { _UserRS = value; }
        }

        public static string PasswordRS
        {
            get { return _PasswordRS; }
            set { _PasswordRS = value; }
        }

        public static string RS_url
        {
            get { return _RS_url; }
            set { _RS_url = value; }
        }

        public static bool tipoCaja
        {
            get { return _tipoCaja; }
            set { _tipoCaja = value; }
        }

        public static decimal DecimalNumber
        {
            get { return _DecimalNumber; }
            set { _DecimalNumber = value; }
        }
    }
}
