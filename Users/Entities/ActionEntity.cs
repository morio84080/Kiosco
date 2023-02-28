using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Users.Entities
{
    public class ActionEntity
    {
        private int _CodAcc;
        private string _NombAcc;

        public ActionEntity()
        {
            _CodAcc = 0;
            _NombAcc = string.Empty;
        }

        public int CodAcc
        {
            get { return _CodAcc; }
            set { _CodAcc = value; }
        }

        public string NombAcc
        {
            get { return _NombAcc; }
            set { _NombAcc = value; }
        }

    }
}
