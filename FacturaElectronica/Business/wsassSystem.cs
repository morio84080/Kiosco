using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.DataAccess;
using FacturaElectronica.Entities;
using Ventas.Entities;
using ctc3DES;


namespace FacturaElectronica.Business
{
    public class wsassSystem
    {
        //TESTING
        ar.gov.afip.wswhomo.Service wsass;
        ar.gov.afip.wswhomo.FEAuthRequest Auth;        

        //PRODUCCION
        //WsaaProd.FEAuthRequest Auth;

        public ar.gov.afip.wswhomo.FECAEResponse FECAESolicitar(int CantReg, int CbteTipo, int Concepto, int DocTipo, long DocNro, double ImpTotal, double ImpNeto, double ImpIVA, List<AlicIvaEntity> Ivas, DateTime fechaFactura, string moneda, VentaEntity ventaOriginal, double impuestoInterno, double ivaExento)
        {
            try
            {
                //*********************************************************************************
                //OBTIENE EL ÚLTIMO NRO DE COMPROBANTE
                //*********************************************************************************
                int PtoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);
                string cuitEmisor = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["CUIT"]);
                int NroComprobante = FECompUltimoAutorizado(PtoVta,CbteTipo);
                NroComprobante++;

                //nuevaInstancia(); La instancia la obtengo al obtener el ultimo nro de comprobante
                ar.gov.afip.wswhomo.FECAERequest FeCAEReq = new ar.gov.afip.wswhomo.FECAERequest();
                ar.gov.afip.wswhomo.FECAEResponse FeCAERes = new ar.gov.afip.wswhomo.FECAEResponse();

                
                //******************************************************************************************
                //Cabecera
                //******************************************************************************************
                ar.gov.afip.wswhomo.FECAECabRequest feCabReq = new ar.gov.afip.wswhomo.FECAECabRequest();
                feCabReq.CantReg = CantReg; //1
                feCabReq.CbteTipo = CbteTipo; //1 --> Factura A. 20100917
                feCabReq.PtoVta = PtoVta; //1
                FeCAEReq.FeCabReq = feCabReq;                

                //******************************************************************************************
                //Detalle
                //******************************************************************************************
                //ar.gov.afip.wswhomo.FEDetRequest FeDetReq = new ar.gov.afip.wswhomo.FEDetRequest();            

                List<ar.gov.afip.wswhomo.FECAEDetRequest> listDetalle = new List<ar.gov.afip.wswhomo.FECAEDetRequest>();
                ar.gov.afip.wswhomo.FECAEDetRequest detalle = new ar.gov.afip.wswhomo.FECAEDetRequest();
                
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
                detalle.CbteFch =fechaFactura.ToString("yyyyMMdd");  //DateTime.Now.ToString("yyyyMMdd");//"20170115";

                if (CbteTipo == 3 || CbteTipo == 8)
                {


                    //List<ar.gov.afip.wswhomo.CbteAsoc> cbtAsocList = new List<ar.gov.afip.wswhomo.CbteAsoc>();
                    //ar.gov.afip.wswhomo.CbteAsoc cbteAsoc = new ar.gov.afip.wswhomo.CbteAsoc();
                    List<FacturaElectronica.ar.gov.afip.wswhomo.CbteAsoc> cbtAsocList = new List<ar.gov.afip.wswhomo.CbteAsoc>();
                    FacturaElectronica.ar.gov.afip.wswhomo.CbteAsoc cbteAsoc = new ar.gov.afip.wswhomo.CbteAsoc();
                    cbteAsoc.Tipo = (ventaOriginal.LetraVta=="A"?1:6);
                    cbteAsoc.PtoVta = PtoVta;
                    cbteAsoc.Nro = ventaOriginal.TicketFiscal; //Nro Factura Original
                    cbteAsoc.Cuit = cuitEmisor;// DocNro.ToString(); //CUIT EMISOR
                    cbteAsoc.CbteFch = ventaOriginal.FechVta.ToString("yyyyMMdd");  //"20191007"; // Fecha orginal de la factura
                    cbtAsocList.Add(cbteAsoc);
                    detalle.CbtesAsoc = cbtAsocList.ToArray();
                }


                detalle.ImpTotal = ImpTotal;//184.05;
                detalle.ImpTotConc = impuestoInterno; //impuesto interno
                detalle.ImpNeto = ImpNeto;
                detalle.ImpOpEx = ivaExento;
                detalle.ImpTrib = 0;
                detalle.ImpIVA = ImpIVA;
                detalle.MonId = moneda;//"PES";
                detalle.MonCotiz = 1;

                
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
                List<ar.gov.afip.wswhomo.AlicIva> listAlicIva = new List<ar.gov.afip.wswhomo.AlicIva>();
                foreach (var iva in Ivas)
                {
                    ar.gov.afip.wswhomo.AlicIva alicIva = new ar.gov.afip.wswhomo.AlicIva();

                    alicIva.Id = iva.id;
                    alicIva.BaseImp = iva.BaseImp;
                    alicIva.Importe = iva.Importe;                    
                    listAlicIva.Add(alicIva);
                }

                detalle.Iva = listAlicIva.ToArray();
                listDetalle.Add(detalle);

                FeCAEReq.FeDetReq = listDetalle.ToArray();

                FeCAERes = wsass.FECAESolicitar(Auth, FeCAEReq);
                
                return FeCAERes;
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
                ar.gov.afip.wswhomo.FERecuperaLastCbteResponse response = new ar.gov.afip.wswhomo.FERecuperaLastCbteResponse();
                response = wsass.FECompUltimoAutorizado(Auth, PtoVta, tipoCbte);
                if (response.Errors!= null)
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

        public void FEParamGetPtosVenta()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.FEPtoVentaResponse response = new ar.gov.afip.wswhomo.FEPtoVentaResponse();
                response= wsass.FEParamGetPtosVenta(Auth);
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

        public void FEParamGetTiposOpcionales()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.OpcionalTipoResponse response = new ar.gov.afip.wswhomo.OpcionalTipoResponse();
                response = wsass.FEParamGetTiposOpcional(Auth);

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

        public void FEParamGetTiposCbte()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.CbteTipoResponse response = new ar.gov.afip.wswhomo.CbteTipoResponse();
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

        public void FEParamGetTiposConcepto()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.ConceptoTipoResponse response = new ar.gov.afip.wswhomo.ConceptoTipoResponse();
                response = wsass.FEParamGetTiposConcepto(Auth);
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

        public void FEParamGetTiposDoc()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.DocTipoResponse response = new ar.gov.afip.wswhomo.DocTipoResponse();
                response = wsass.FEParamGetTiposDoc(Auth);
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

        public void FEParamGetTiposIva()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.IvaTipoResponse response = new ar.gov.afip.wswhomo.IvaTipoResponse();
                response = wsass.FEParamGetTiposIva(Auth);
                /*
                3 - 0
                4 - 10.5
                5 - 21
                6 - 27
                8 - 5
                9 - 2.5
                */
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

        public void FEParamGetTiposMonedas()
        {
            try
            {
                nuevaInstancia();
                ar.gov.afip.wswhomo.MonedaResponse response = new ar.gov.afip.wswhomo.MonedaResponse();
                response = wsass.FEParamGetTiposMonedas(Auth);
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
                else {
                    loginEty = login.Get();
                }

                //Testing
                wsass = new ar.gov.afip.wswhomo.Service();
                Auth = new ar.gov.afip.wswhomo.FEAuthRequest();

                //Produccion
                //Auth = new WsaaProd.FEAuthRequest();

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
