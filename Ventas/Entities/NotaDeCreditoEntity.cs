using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Entities
{
    public class NotaDeCreditoEntity
    {
        private decimal _NumeVtaNocr;
        private DateTime _FechaNocr;
        private decimal _TicketFiscalNocr;
        private string _CaeNocr;
        private DateTime _FechaVtoCaeNocr;


        public NotaDeCreditoEntity()
        {
            _NumeVtaNocr = 0;
            _TicketFiscalNocr = 0;
            _CaeNocr = string.Empty;
            _FechaNocr = DateTime.Now;
            _FechaVtoCaeNocr = DateTime.Now;

        }

        public decimal NumeVtaNocr
        {
            get { return _NumeVtaNocr; }
            set { _NumeVtaNocr = value; }
        }

        public DateTime FechaNocr
        {
            get { return _FechaNocr; }
            set { _FechaNocr = value; }
        }

        public decimal TicketFiscalNocr
        {
            get { return _TicketFiscalNocr; }
            set { _TicketFiscalNocr = value; }
        }

        public string CaeNocr
        {
            get { return _CaeNocr; }
            set { _CaeNocr = value; }
        }

        public DateTime FechaVtoCaeNocr
        {
            get { return _FechaVtoCaeNocr; }
            set { _FechaVtoCaeNocr = value; }
        }

    }
}
