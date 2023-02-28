using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CuentaCorriente.DataAccess;
using CuentaCorriente.Entities;


namespace CuentaCorriente.Business
{
   public  class CtaCteBUS
    {
       public DataTable getAllCtaCtePorClie_DT(int CodiClie, DateTime FechaIni, DateTime FechaFin)
       {
           return new CtaCteDALC().DS_GetCtaCteByClie(CodiClie,FechaIni,FechaFin).Tables[0];
       }

       public SaldosEntity getSaldosBase(int CodiClie, DateTime Fecha)
       {
           return new CtaCteDALC().SaldoBase(CodiClie, Fecha);
       }

       public SaldosEntity getSaldosClie(int CodiLoca, int CodiClie, DateTime Fecha)
       {
           return new CtaCteDALC().SaldoClie(CodiLoca, CodiClie, Fecha);
       }

       public decimal getSaldoActualClie(int CodiClie)
       {
           return new CtaCteDALC().SaldoActual(CodiClie);
       }
    }
}
