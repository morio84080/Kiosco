using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.InteropServices;

namespace FacturaElectronica.Business
{
    /// <summary>
    /// Clase para crear objetos Login Tickets
    /// </summary>
    /// <remarks>
    /// Ver documentacion: 
    ///    Especificacion Tecnica del Webservice de Autenticacion y Autorizacion
    ///    Version 1.0
    ///    Departamento de Seguridad Informatica - AFIP
    /// </remarks>
    class LoginTicket
    {
        public UInt32 UniqueId; // Entero de 32 bits sin signo que identifica el requerimiento
        public DateTime GenerationTime; // Momento en que fue generado el requerimiento
        public DateTime ExpirationTime; // Momento en el que expira la solicitud
        public string Service; // Identificacion del WSN para el cual se solicita el TA
        public string Sign; // Firma de seguridad recibida en la respuesta
        public string Token; // Token de seguridad recibido en la respuesta
        public XmlDocument XmlLoginTicketRequest = null;
        public XmlDocument XmlLoginTicketResponse = null;
        public string RutaDelCertificadoFirmante;
        public string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";
        private bool _verboseMode = true;
        private static UInt32 _globalUniqueID = 0; // OJO! NO ES THREAD-SAFE

        /// <summary>
        /// Construye un Login Ticket obtenido del WSAA
        /// </summary>
        /// <param name="argServicio">Servicio al que se desea acceder</param>
        /// <param name="argUrlWsaa">URL del WSAA</param>
        /// <param name="argRutaCertX509Firmante">Ruta del certificado X509 (con clave privada) usado para firmar</param>
        /// <param name="argPassword">Password del certificado X509 (con clave privada) usado para firmar</param>
        /// <param name="argProxy">IP:port del proxy</param>
        /// <param name="argProxyUser">Usuario del proxy</param>''' 
        /// <param name="argProxyPassword">Password del proxy</param>
        /// <param name="argVerbose">Nivel detallado de descripcion? true/false</param>
        /// <remarks></remarks>
        public string ObtenerLoginTicketResponse(string argServicio, string argUrlWsaa, string argRutaCertX509Firmante, SecureString argPassword, string argProxy, string argProxyUser, string argProxyPassword, bool argVerbose)
        {
            const string ID_FNC = "[ObtenerLoginTicketResponse]";
            this.RutaDelCertificadoFirmante = argRutaCertX509Firmante;
            this._verboseMode = argVerbose;
            CertificadosX509Lib.VerboseMode = argVerbose;
            string cmsFirmadoBase64 = null;
            string loginTicketResponse = null;
            XmlNode xmlNodoUniqueId = default(XmlNode);
            XmlNode xmlNodoGenerationTime = default(XmlNode);
            XmlNode xmlNodoExpirationTime = default(XmlNode);
            XmlNode xmlNodoService = default(XmlNode);

            // PASO 1: Genero el Login Ticket Request
            try
            {
                _globalUniqueID += 1;

                XmlLoginTicketRequest = new XmlDocument();
                XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

                xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");
                xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
                xmlNodoService.InnerText = argServicio;
                this.Service = argServicio;

                if (this._verboseMode) Console.WriteLine(XmlLoginTicketRequest.OuterXml);
            }
            catch (Exception excepcionAlGenerarLoginTicketRequest)
            {
                throw new Exception(ID_FNC + "***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace);
            }

            Logger.Log.LogInFile(XmlLoginTicketRequest.OuterXml, "RequestLoginTicket");


            string step = "1";
            // PASO 2: Firmo el Login Ticket Request
            try
            {
                if (this._verboseMode) Console.WriteLine(ID_FNC + "***Leyendo certificado: {0}", RutaDelCertificadoFirmante);

                Logger.Log.LogInFile(RutaDelCertificadoFirmante, "RequestLoginTicket");

                X509Certificate2 certFirmante = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, argPassword);

                if (this._verboseMode)
                {
                    //Console.WriteLine(ID_FNC + "***Firmando: ");
                    //Console.WriteLine(XmlLoginTicketRequest.OuterXml);
                }
                step = "2";
                // Convierto el Login Ticket Request a bytes, firmo el msg y lo convierto a Base64
                Encoding EncodedMsg = Encoding.UTF8;
                byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);
                step = "3";
                byte[] encodedSignedCms = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
                step = "4";
                cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);
                step = "5";
            }
            catch (Exception excepcionAlFirmar)
            {
                throw new Exception(ID_FNC + "***Error FIRMANDO el LoginTicketRequest ("+step+") : " + excepcionAlFirmar.Message);
            }

            // PASO 3: Invoco al WSAA para obtener el Login Ticket Response
            try
            {
                if (this._verboseMode)
                {
                    //Console.WriteLine(ID_FNC + "***Llamando al WSAA en URL: {0}", argUrlWsaa);
                    //Console.WriteLine(ID_FNC + "***Argumento en el request:");
                    //Console.WriteLine(cmsFirmadoBase64);
                }

                FacturaElectronica.Wsaa.LoginCMSService servicioWsaa = new FacturaElectronica.Wsaa.LoginCMSService(); //Testing
                //ar.gov.afip.wsaa.LoginCMSService servicioWsaa = new ar.gov.afip.wsaa.LoginCMSService(); // Produccion
                servicioWsaa.Url = argUrlWsaa;

                // Veo si hay que salir a traves de un proxy
                if (argProxy != null)
                {
                    servicioWsaa.Proxy = new WebProxy(argProxy, true);
                    if (argProxyUser != null)
                    {
                        NetworkCredential Credentials = new NetworkCredential(argProxyUser, argProxyPassword);
                        servicioWsaa.Proxy.Credentials = Credentials;
                    }
                }

                loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);

                if (this._verboseMode)
                {
                    //Console.WriteLine(ID_FNC + "***LoguinTicketResponse: ");
                    //Console.WriteLine(loginTicketResponse);
                }

            }
            catch (Exception excepcionAlInvocarWsaa)
            {
                throw new Exception(ID_FNC + "***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message);
            }

            // PASO 4: Analizo el Login Ticket Response recibido del WSAA
            try
            {
                XmlLoginTicketResponse = new XmlDocument();
                XmlLoginTicketResponse.LoadXml(loginTicketResponse);

                this.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
                this.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
                this.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
                this.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
                this.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
            }
            catch (Exception excepcionAlAnalizarLoginTicketResponse)
            {
                throw new Exception(ID_FNC + "***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message);
            }
            return loginTicketResponse;
        }
    }

    /// <summary>
    /// Libreria de utilidades para manejo de certificados
    /// </summary>
    /// <remarks></remarks>
    class CertificadosX509Lib
    {
        public static bool VerboseMode = false;

        /// <summary>
        /// Firma mensaje
        /// </summary>
        /// <param name="argBytesMsg">Bytes del mensaje</param>
        /// <param name="argCertFirmante">Certificado usado para firmar</param>
        /// <returns>Bytes del mensaje firmado</returns>
        /// <remarks></remarks>
        public static byte[] FirmaBytesMensaje(byte[] argBytesMsg, X509Certificate2 argCertFirmante)
        {
            const string ID_FNC = "[FirmaBytesMensaje]";
            try
            {
                // Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
                ContentInfo infoContenido = new ContentInfo(argBytesMsg);
                SignedCms cmsFirmado = new SignedCms(infoContenido);

                // Creo objeto CmsSigner que tiene las caracteristicas del firmante
                CmsSigner cmsFirmante = new CmsSigner(argCertFirmante);
                cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

                if (VerboseMode) Console.WriteLine(ID_FNC + "***Firmando bytes del mensaje...");

                // Firmo el mensaje PKCS #7
                cmsFirmado.ComputeSignature(cmsFirmante);

                if (VerboseMode) Console.WriteLine(ID_FNC + "***OK mensaje firmado");

                // Encodeo el mensaje PKCS #7.
                return cmsFirmado.Encode();
            }
            catch (Exception excepcionAlFirmar)
            {
                throw new Exception(ID_FNC + "***Error al firmar: " + excepcionAlFirmar.Message);
            }
        }

        /// <summary>
        /// Lee certificado de disco
        /// </summary>
        /// <param name="argArchivo">Ruta del certificado a leer.</param>
        /// <returns>Un objeto certificado X509</returns>
        /// <remarks></remarks>
        public static X509Certificate2 ObtieneCertificadoDesdeArchivo(string argArchivo, SecureString argPassword)
        {
            const string ID_FNC = "[ObtieneCertificadoDesdeArchivo]";
            X509Certificate2 objCert = new X509Certificate2();
            try
            {
                if (argPassword.IsReadOnly())
                {
                    objCert.Import(File.ReadAllBytes(argArchivo), argPassword, X509KeyStorageFlags.PersistKeySet);
                }
                else
                {
                    objCert.Import(File.ReadAllBytes(argArchivo));
                }
                return objCert;
            }
            catch (Exception excepcionAlImportarCertificado)
            {
                throw new Exception(ID_FNC + "***Error al leer certificado: " + excepcionAlImportarCertificado.Message);
            }
        }
    }

    /// <summary>
    /// Clase principal
    /// </summary>
    /// <remarks></remarks>
    public class LoginCMS
    {
        // Valores por defecto, globales en esta clase
        //const string DEFAULT_URLWSAAWSDL = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL"; //TESTING
        //const string DEFAULT_URLWSAAWSDL = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl?WSDL"; //PRODUCCION
        static string DEFAULT_URLWSAAWSDL = System.Configuration.ConfigurationManager.AppSettings["URLWSAAWSDL"].ToString();        
        const string DEFAULT_SERVICIO = "wsfe";
        static string DEFAULT_CERTSIGNER = System.Configuration.ConfigurationManager.AppSettings["pfx"].ToString();        
        //const string DEFAULT_CERTSIGNER = "C:\\MyWaySoft\\Claudio Spurkel\\Facturacion Electronica\\GenerarCertificados_Prod\\morio.pfx"; //PRODUCCION
        const string DEFAULT_PROXY = null;
        const string DEFAULT_PROXY_USER = null;
        const string DEFAULT_PROXY_PASSWORD = null;
        const bool DEFAULT_VERBOSE = true;

        /// <summary>
        /// Funcion Main (consola)
        /// </summary>
        /// <param name="args">Argumentos de linea de comandos</param>
        /// <returns>0 si terminó bien, valores negativos si hubieron errores</returns>
        /// <remarks></remarks>
        public static string Process()
        {
            const string ID_FNC = "[Process]";

            string strUrlWsaaWsdl = DEFAULT_URLWSAAWSDL;
            string strIdServicioNegocio = DEFAULT_SERVICIO;
            string strRutaCertSigner = DEFAULT_CERTSIGNER;
            SecureString strPasswordSecureString = new SecureString();
            string strProxy = DEFAULT_PROXY;
            string strProxyUser = DEFAULT_PROXY_USER;
            string strProxyPassword = DEFAULT_PROXY_PASSWORD;
            bool blnVerboseMode = DEFAULT_VERBOSE;

            MostrarVersion();

            // Argumentos OK, entonces procesar normalmente...

            LoginTicket objTicketRespuesta = null;
            string strTicketRespuesta = null;

            try
            {
                if (blnVerboseMode)
                {
                    //Console.WriteLine(ID_FNC + "***Servicio a acceder: {0}", strIdServicioNegocio);
                    //Console.WriteLine(ID_FNC + "***URL del WSAA: {0}", strUrlWsaaWsdl);
                    //Console.WriteLine(ID_FNC + "***Ruta del certificado: {0}", strRutaCertSigner);
                    //Console.WriteLine(ID_FNC + "***Modo verbose: {0}", blnVerboseMode);
                    //Console.ReadKey();
                }

                if (System.Configuration.ConfigurationManager.AppSettings["produccion"].ToString() == "1")
                {
                    string pass = "hugo";
                    //string pass = "20324492055";
                    foreach (char c in pass) strPasswordSecureString.AppendChar(c);
                    strPasswordSecureString.MakeReadOnly();
                }

                
                objTicketRespuesta = new LoginTicket();
                if (blnVerboseMode) Console.WriteLine(ID_FNC + "***Accediendo a {0}", strUrlWsaaWsdl);
                strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(strIdServicioNegocio, strUrlWsaaWsdl, strRutaCertSigner, strPasswordSecureString, strProxy, strProxyUser, strProxyPassword, blnVerboseMode);                
            }
            catch (Exception excepcionAlObtenerTicket)
            {
                //Console.WriteLine(ID_FNC + "***EXCEPCION AL OBTENER TICKET: " + excepcionAlObtenerTicket.Message);
                return "ERR|" + ID_FNC + "***EXCEPCION AL OBTENER TICKET: " + excepcionAlObtenerTicket.Message;
            }
            //Console.WriteLine("Fin");
            return "OK|" + objTicketRespuesta.GenerationTime + "|" + objTicketRespuesta.ExpirationTime + "|" + objTicketRespuesta.Token + "|" + objTicketRespuesta.Sign;
        }

        /// <summary>
        /// Explica el uso del comando
        /// </summary>
        /// <remarks></remarks>
        public static void ExplicarUso()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            Console.WriteLine("");
            Console.WriteLine("Uso: {0} [opciones]...", fvi.ProductName);
            Console.WriteLine("");
            Console.WriteLine("opciones:");
            Console.WriteLine("");
            Console.WriteLine("  -s servicio      ID del servicio de negocio");
            Console.WriteLine("                   Valor por defecto: " + DEFAULT_SERVICIO);
            Console.WriteLine("");
            Console.WriteLine("  -c certif        Ruta del certificado (con clave privada)");
            Console.WriteLine("                   Valor por defecto: " + DEFAULT_CERTSIGNER);
            Console.WriteLine("");
            Console.WriteLine("  -p certifpwd     Password del certificado (con clave privada)");
            Console.WriteLine("                   Valor por defecto: sin password");
            Console.WriteLine("");
            Console.WriteLine("  -x IP:port       IP:port del proxy");
            Console.WriteLine("                   Valor por defecto: sin proxy");
            Console.WriteLine("");
            Console.WriteLine("  -y proxyusr      Usuario del proxy");
            Console.WriteLine("                   Valor por defecto: sin usuario proxy");
            Console.WriteLine("");
            Console.WriteLine("  -z proxypwd      Password del proxy");
            Console.WriteLine("                   Valor por defecto: sin password proxy");
            Console.WriteLine("");
            Console.WriteLine("  -w url           URL del WSDL del WSAA");
            Console.WriteLine("                   Valor por defecto: " + DEFAULT_URLWSAAWSDL);
            Console.WriteLine("");
            Console.WriteLine("  -v on|off        Reportes detallados de la ejecución");
            Console.WriteLine("");
            Console.WriteLine("  -?               Esta ayuda");
        }

        public static void MostrarVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            //Console.WriteLine("Aplicacion: {0}", fvi.ProductName);
            //Console.WriteLine("Version   : {0}", fvi.FileVersion);
        }
    }
}
