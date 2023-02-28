using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Entities
{
    public class LoginEntity
    {
        private short _id;
        private DateTime _generationTime;
        private DateTime _expirationTime;
        private string _token;
        private string _sign;

        public LoginEntity()
        {
            _id=0;
            _token=string.Empty;
            _sign = string.Empty;
            _generationTime = DateTime.Now;
            _expirationTime = DateTime.Now;

        }

        public short id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        public DateTime generationTime
        {
            get { return _generationTime; }
            set { _generationTime = value; }
        }

        public DateTime expirationTime
        {
            get { return _expirationTime; }
            set { _expirationTime = value; }
        }
    }
}
