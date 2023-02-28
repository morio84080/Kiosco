using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Users.Entities
{
    public class ProfileEntity
    {
        private int _CodiPerfi;
        private string _NombPerfi;
        private bool _EnabledPerfi;

        public ProfileEntity()
        {
            _CodiPerfi = 0;
            _NombPerfi = string.Empty;
            _EnabledPerfi = true;
        }

        public int CodiPerfi
        {
            get { return _CodiPerfi; }
            set { _CodiPerfi = value; }
        }

        public string NombPerfi
        {
            get { return _NombPerfi; }
            set { _NombPerfi = value; }
        }

        public bool EnabledPerfi
        {
            get { return _EnabledPerfi; }
            set { _EnabledPerfi = value; }
        }


    }
}
