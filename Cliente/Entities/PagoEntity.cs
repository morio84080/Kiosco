using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Entities
{
    public class PagoEntity
    {
        private int numePACL;
        private DateTime fechPACL;
        private int cliePACL;
        private string detallePACL;
        private decimal impoPACL;
        private bool eliminadoPACL;
        public PagoEntity()
        {
            numePACL = 0;
            fechPACL = DateTime.Now;
            cliePACL = 0;
            detallePACL = string.Empty;
            impoPACL = 0;
            eliminadoPACL = false;
        }
        public int NumePACL
        {
            get { return numePACL; }
            set { numePACL = value; }
        }

        public DateTime FechPACL
        {
            get { return fechPACL; }
            set { fechPACL = value; }
        }

        public int CliePACL
        {
            get { return cliePACL; }
            set { cliePACL = value; }
        }

        public string DetaPACL
        {
            get { return detallePACL; }
            set { detallePACL = value; }
        }

        public decimal ImpoPACL
        {
            get { return impoPACL; }
            set { impoPACL = value; }
        }

        public bool EliminadoPACL
        {
            get { return eliminadoPACL; }
            set { eliminadoPACL = value; }
        }
    }
}
