using System;
using System.Collections.Generic;
using System.Text;
using EPSON_Impresora_Fiscal;

namespace Impresoras
{
    public class Fiscal
    {
        public PrinterFiscal epson;
        public EPSON_Impresora_Fiscal.PrinterFiscalClass ep;
        public bool EmitirTicketFiscal()
        {
            bool res=true;

            try
            {
                res = epson.OpenTicket("G");
                if (res) res = ep.SendTicketItem("Test TF", "1", "0.01", "21", "M", "0", "0");
                if (res) res = ep.CloseTicket();
            }
            catch (Exception ex)
            { 
                string msg = ex.Message;
            }

            return res;

        }

    }
}
