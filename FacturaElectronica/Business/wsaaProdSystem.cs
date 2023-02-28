using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.DataAccess;
using FacturaElectronica.Entities;
using FacturaElectronica.ar.gov.afip.servicios1;
using System.Xml.Serialization;
using System.IO;
using Ventas.Entities;
using Logger;

namespace FacturaElectronica.Business
{
    public class wsaaProdSystem
    {
        //TESTING
        //ar.gov.afip.wswhomo.Service wsass;
        //ar.gov.afip.wswhomo.FEAuthRequest Auth;

        //PRODUCCION        
        FEAuthRequest Auth;
        ar.gov.afip.servicios1.Service wsass = new Service();


        public void FEParamGetPtosVenta()
        {
            try
            {
                nuevaInstancia();
                FEPtoVentaResponse response = new FEPtoVentaResponse();
                response = wsass.FEParamGetPtosVenta(Auth);
                if (response.Errors != null)
                {
                    throw new Exception("Code: " + response.Errors[0].Code.ToString() + " --> " + response.Errors[0].Msg);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string FECompConsultar(long nroComprobante, int tipoComprobante, int ptoVta)
        {
            try
            {
                string res = string.Empty;
                nuevaInstancia();
                FECompConsultaResponse response = new FECompConsultaResponse();
                FECompConsultaReq request = new FECompConsultaReq();
                request.CbteNro = nroComprobante;
                request.CbteTipo = tipoComprobante;
                request.PtoVta = ptoVta;
                response = wsass.FECompConsultar(Auth, request);
                if (response.Errors != null)
                {
                    throw new Exception("Code: " + response.Errors[0].Code.ToString() + " --> " + response.Errors[0].Msg);
                }
                else
                {
                    res += "Fecha: " + response.ResultGet.CbteFch;
                    res += "|Cod. Autorizacion: " + response.ResultGet.CodAutorizacion;
                    res += "|Tipo Doc: " + response.ResultGet.DocTipo;
                    res += "|Nro Doc: " + response.ResultGet.DocNro;
                    res += "|Fecha Vto: " + response.ResultGet.FchVto;
                    res += "|ImpIVA: " + response.ResultGet.ImpIVA;
                    res += "|ImpNeto: " + response.ResultGet.ImpNeto;
                    res += "|ImpOpEx: " + response.ResultGet.ImpOpEx;
                    res += "|ImpTotal: " + response.ResultGet.ImpTotal;
                    res += "|ImpTotConc: " + response.ResultGet.ImpTotConc;
                    res += "|ImpTrib: " + response.ResultGet.ImpTrib;
                    res += "|Iva: " + response.ResultGet.Iva;

                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FEParamGetTiposCbte()
        {
            try
            {
                nuevaInstancia();
                CbteTipoResponse response = new CbteTipoResponse();
                response = wsass.FEParamGetTiposCbte(Auth);
                if (response.Errors != null)
                {
                    throw new Exception("Code: " + response.Errors[0].Code.ToString() + " --> " + response.Errors[0].Msg);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int FECompUltimoAutorizado(int PtoVta, int tipoCbte)
        {
            try
            {
                nuevaInstancia();
                FERecuperaLastCbteResponse response = new FERecuperaLastCbteResponse();
                response = wsass.FECompUltimoAutorizado(Auth, PtoVta, tipoCbte);
                if (response.Errors != null)
                {
                    throw new Exception("Code: " + response.Errors[0].Code.ToString() + " --> " + response.Errors[0].Msg);
                }

                return response.CbteNro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FECAEResponse FECAESolicitar(int CantReg, int CbteTipo, int Concepto, int DocTipo, long DocNro, double ImpTotal, double ImpNeto, double ImpIVA, List<AlicIvaEntity> Ivas, DateTime fechaFactura, string moneda, VentaEntity ventaOriginal, double impuestoInterno, double ivaExento)
        {
            try
            {
                //*********************************************************************************
                //OBTIENE EL ÚLTIMO NRO DE COMPROBANTE
                //*********************************************************************************
                int PtoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);
                string cuitEmisor = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["CUIT"]);

                try { Logger.Log.LogInFile("Request FECompUltimoAutorizado", "IF.log"); }
                catch { }

                int NroComprobante = FECompUltimoAutorizado(PtoVta, CbteTipo);
                NroComprobante++;

                try { Logger.Log.LogInFile("Response FECompUltimoAutorizado: " + NroComprobante.ToString(), "IF.log"); }
                catch { }
                //nuevaInstancia(); La instancia la obtengo al obtener el ultimo nro de comprobante
                FECAERequest FeCAEReq = new FECAERequest();
                FECAEResponse FeCAERes = new FECAEResponse();

                //******************************************************************************************
                //Cabecera
                //******************************************************************************************
                FECAECabRequest feCabReq = new FECAECabRequest();
                feCabReq.CantReg = CantReg; //1
                feCabReq.CbteTipo = CbteTipo; //1 --> Factura A. 20100917
                feCabReq.PtoVta = PtoVta; //1
                FeCAEReq.FeCabReq = feCabReq;


                //******************************************************************************************
                //Detalle
                //******************************************************************************************
                //ar.gov.afip.wswhomo.FEDetRequest FeDetReq = new ar.gov.afip.wswhomo.FEDetRequest();            

                List<FECAEDetRequest> listDetalle = new List<FECAEDetRequest>();
                FECAEDetRequest detalle = new FECAEDetRequest();
                detalle.Concepto = Concepto; //1 Productos 2 Servicios 3 Productos y Servicios
                detalle.DocTipo = DocTipo; //80 -> CUIT 86 -> CUIL 96 -> DNI
                detalle.DocNro = DocNro;
                detalle.CbteDesde = NroComprobante;
                detalle.CbteHasta = NroComprobante;
                //detalle.CbteFch = "20170115";
                //detalle.ImpTotal = 184.05;
                //detalle.ImpTotConc = 0;
                //detalle.ImpNeto = 150;
                //detalle.ImpOpEx = 0;
                //detalle.ImpTrib = 7.8;
                //detalle.ImpIVA = 26.25;
                detalle.CbteFch = fechaFactura.ToString("yyyyMMdd"); //DateTime.Now.ToString("yyyyMMdd");//"20170115";

                if (CbteTipo == 3 || CbteTipo == 8 || CbteTipo == 13)
                {

                    //List<ar.gov.afip.wswhomo.CbteAsoc> cbtAsocList = new List<ar.gov.afip.wswhomo.CbteAsoc>();
                    //ar.gov.afip.wswhomo.CbteAsoc cbteAsoc = new ar.gov.afip.wswhomo.CbteAsoc();
                    List<CbteAsoc> cbtAsocList = new List<CbteAsoc>();
                    CbteAsoc cbteAsoc = new CbteAsoc();
                    cbteAsoc.Tipo = (CbteTipo == 13 ? 11 : (CbteTipo == 3 ? 1 : 6)); //(ventaOriginal.LetraVta == "A" ? 1 : 6);
                    cbteAsoc.PtoVta = PtoVta;
                    cbteAsoc.Nro = ventaOriginal.TicketFiscal; //Nro Factura Original
                    cbteAsoc.Cuit = cuitEmisor;// DocNro.ToString(); //CUIT EMISOR
                    cbteAsoc.CbteFch = ventaOriginal.FechVta.ToString("yyyyMMdd");  //"20191007"; // Fecha orginal de la factura
                    cbtAsocList.Add(cbteAsoc);
                    detalle.CbtesAsoc = cbtAsocList.ToArray();
                }

                detalle.ImpTotal = ImpTotal;//184.05;
                detalle.ImpTotConc = impuestoInterno;
                detalle.ImpNeto = ImpNeto;
                detalle.ImpOpEx = ivaExento;
                detalle.ImpTrib = 0;
                detalle.ImpIVA = (CbteTipo==11 || CbteTipo==13? 0 : ImpIVA);
                detalle.MonId = moneda;//"PES";
                detalle.MonCotiz = 1;//Cotizacion Dolar si es en USD

                //List<ar.gov.afip.wswhomo.Tributo> listTributo = new List<ar.gov.afip.wswhomo.Tributo>();
                //ar.gov.afip.wswhomo.Tributo tributo = new ar.gov.afip.wswhomo.Tributo();
                //tributo.Id = 99;
                //tributo.Desc = "Impuesto Municipal Matanza";
                //tributo.BaseImp = 150;
                //tributo.Alic = 5.2;
                //tributo.Importe = 7.8;
                //listTributo.Add(tributo);
                //detalle.Tributos = listTributo.ToArray();


                //List<ar.gov.afip.wswhomo.AlicIva> listAlicIva = new List<ar.gov.afip.wswhomo.AlicIva>();
                //ar.gov.afip.wswhomo.AlicIva alicIva = new ar.gov.afip.wswhomo.AlicIva();
                //alicIva.Id = 5;
                //alicIva.BaseImp = 100;
                //alicIva.Importe = 21;
                //listAlicIva.Add(alicIva);
                //alicIva = new ar.gov.afip.wswhomo.AlicIva();
                //alicIva.Id = 4;
                //alicIva.BaseImp = 50;
                //alicIva.Importe = 5.25;
                //listAlicIva.Add(alicIva);
                List<AlicIva> listAlicIva = new List<AlicIva>();
                foreach (var iva in Ivas)
                {
                    AlicIva alicIva = new AlicIva();

                    alicIva.Id = iva.id;
                    alicIva.BaseImp = iva.BaseImp;
                    alicIva.Importe = iva.Importe;
                    listAlicIva.Add(alicIva);
                }

                if (CbteTipo != 11 && CbteTipo != 13 && listAlicIva.Count>0)
                    detalle.Iva = listAlicIva.ToArray();

                listDetalle.Add(detalle);

                FeCAEReq.FeDetReq = listDetalle.ToArray();

                FeCAERes = wsass.FECAESolicitar(Auth, FeCAEReq);

                try
                {
                    XmlSerializer xmlAuth = new XmlSerializer(typeof(FEAuthRequest));

                    using (StringWriter textWriter = new StringWriter())
                    {
                        xmlAuth.Serialize(textWriter, Auth);
                        //Console.WriteLine(textWriter.ToString());
                        Logger.Log.LogInFile(textWriter.ToString(), "Request");

                    }

                    XmlSerializer xmlCab = new XmlSerializer(typeof(FECAERequest));

                    using (StringWriter textWriter = new StringWriter())
                    {
                        xmlCab.Serialize(textWriter, FeCAEReq);
                        //Console.WriteLine(textWriter.ToString());
                        Logger.Log.LogInFile(textWriter.ToString(), "Request");

                    }

                }
                catch(Exception exXML) { Logger.Log.LogInFile("Error XML --> " + exXML.Message, "Request"); }

                return FeCAERes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void nuevaInstancia()
        {
            try
            {
                LoginDALC login = new LoginDALC();
                LoginEntity loginEty = new LoginEntity();
                if (login.checkLogin() == 1)
                {
                    string[] res = FacturaElectronica.Business.LoginCMS.Process().Split('|');
                    if (res[0] != "OK") throw new Exception(res[1]);
                    else
                    {
                        loginEty.expirationTime = Convert.ToDateTime(res[2]);
                        loginEty.generationTime = Convert.ToDateTime(res[1]);
                        loginEty.sign = res[4].ToString();
                        loginEty.token = res[3].ToString();
                        login.Update(loginEty);
                    }
                }
                else
                {
                    loginEty = login.Get();
                }

                //Testing
                //wsass = new ar.gov.afip.wswhomo.Service();
                //Auth = new ar.gov.afip.wswhomo.FEAuthRequest();

                //Produccion
                Auth = new FEAuthRequest();
                wsass = new Service();

                Auth.Cuit = long.Parse(System.Configuration.ConfigurationManager.AppSettings["CUIT"]);
                Auth.Sign = loginEty.sign;
                Auth.Token = loginEty.token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
