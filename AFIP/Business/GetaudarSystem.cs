using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using Core.Business;
using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;

namespace AFIP.Business
{
    public class GetaudarSystem
    {
        string pathPrograma = System.Configuration.ConfigurationManager.AppSettings["getaudarPath"];
        string port = System.Configuration.ConfigurationManager.AppSettings["port"];
        string serviceName = System.Configuration.ConfigurationManager.AppSettings["serviceName"];
        public string GenerateFiles()
        {
            try
            {
                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>INICIA PROCESO GENERAR ARCHIVOS AFIP<<<<<<<<<<<<<<<<<<<<<<<<<", "log");

                string fileName = string.Empty;
                string param1 = string.Empty;
                string param2 = string.Empty;
                bool nuevo = false;
                DateTime now = DateTime.Now;

                //Asi obtenemos el primer dia del mes actual
                DateTime oPrimerDiaDelMes = new DateTime(now.AddMonths(-1).Year,now.AddMonths(-1).Month, 1);

                //Y de la siguiente forma obtenemos el ultimo dia del mes
                //agregamos 1 mes al objeto anterior y restamos 1 día.
                DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

                if (now.Day>=1 && now.Day <8)
                {
                        
                    param1 = oPrimerDiaDelMes.Year.ToString().Substring(2, 2) + oPrimerDiaDelMes.Month.ToString().PadLeft(2, '0') + "22";
                    param2 = oPrimerDiaDelMes.Year.ToString().Substring(2, 2) + oPrimerDiaDelMes.Month.ToString().PadLeft(2, '0') + oUltimoDiaDelMes.Day.ToString().PadLeft(2, '0');
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip") )
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 8 && now.Day < 15)
                {
                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "01";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "07";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 15 && now.Day < 22)
                {

                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "08";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "14";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 22 )
                {
                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "15";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "21";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;
                    }
                }

                if (nuevo)
                {
                    //DETIENE EL SERVICIO DE HASAR
                    Logger.Log.LogInFile("DETIENE PROCESO HASAR", "log");
                    ServiceController service = new ServiceController(serviceName);
                    if ((!service.Status.Equals(ServiceControllerStatus.Stopped)) && (!service.Status.Equals(ServiceControllerStatus.StopPending)))
                        service.Stop();
                    Delay(5);
                    Logger.Log.LogInFile(pathPrograma + "getaudar.exe", "log");
                    Logger.Log.LogInFile("-p " + port + "  -i serial -a " + param1 + " " + param2, "log");

                    Logger.Log.LogInFile("********** COMIENZA A GENERAR ARCHIVOS AFIP ***********", "log");
                    System.Diagnostics.Process appy = new System.Diagnostics.Process();
                    appy.StartInfo.FileName = pathPrograma + "getaudar.exe";
                    appy.StartInfo.Arguments = "-p " + port + "  -i serial -a "+param1+" " + param2;
                    appy.Start();
                    appy.WaitForExit();
                    Delay(5);
                    Logger.Log.LogInFile("********** FIN GENERAR ARCHIVOS AFIP ***********", "log");
                    //CREA DIRECTORIO
                    try
                    {
                        Directory.CreateDirectory(pathPrograma + param1 + "_al_" + param2);
                    }
                    catch (Exception exCD)
                    {
                        throw new Exception("Error creando directorio: " + pathPrograma + param1 + "_al_" + param2 + " -->" + exCD.Message);
                    }

                    //MUEVE ARCHIVOS AL DIRECTORIO
                    try
                    {
                        System.IO.File.Move(pathPrograma.Replace(@"\GETxxxAR","") +"afip.85", pathPrograma + param1 + "_al_" + param2 + @"\afip.85");
                    }
                    catch (Exception exFC1)
                    {
                        throw new Exception("Error Moviendo archivo: " + pathPrograma.Replace(@"\GETxxxAR", "") + "afip.85" + " -->" + exFC1.Message);
                    }

                    try
                    {
                        System.IO.File.Move(pathPrograma.Replace(@"\GETxxxAR", "") + "afip.zip", pathPrograma + param1 + "_al_" + param2 + @"\afip.zip");
                    }
                    catch (Exception exFC2)
                    {
                        throw new Exception("Error Moviendo archivo: " + pathPrograma.Replace(@"\GETxxxAR", "") + "afip.zip" + " -->" + exFC2.Message);
                    }

                    //COMPRIME DIRECTORIO
                    try
                    {
                        ZipSystem.CompressDirectory(pathPrograma + param1 + "_al_" + param2 +@"\", param1 + "_al_" + param2);
                    }
                    catch (Exception exZ)
                    {
                        throw new Exception("Error Zipiando Backup --> " + exZ.Message);
                    }

                    //ELIMINA DIRECTORIO
                    try
                    {
                        //System.IO.File.Delete(PathBackup);
                        Directory.Delete(pathPrograma + param1 + "_al_" + param2);
                    }
                    catch (Exception exDir)
                    {
                        throw new Exception("Error Eliminando Directorio: " + pathPrograma + param1 + "_al_" + param2 + " --> " + exDir.Message);
                    }


                    //System.Diagnostics.Process.Start("C:/Archivos de programa/XXI/DAT/VUTIL.EXE", "/c -unload CEI31.DAT xxx.txt");

                    //INICIA EL SERVICIO DE HASAR
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||  (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        Logger.Log.LogInFile("INICIA PROCESO HASAR", "log");
                        service.Start();
                    }

                }
                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>FIN PROCESO GENERAR ARCHIVOS AFIP<<<<<<<<<<<<<<<<<<<<<<<<<", "log");

                return "OK";
            }
            catch(Exception ex)
            {
                Logger.Log.LogInFile("++++++++++++++++++ ERROR: " + ex.Message, "log");
                return ex.Message;
            }
        }
        private void Delay(double second)
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(second).TotalMilliseconds);
            Application.DoEvents();

        }

        public string ProcessFiles()
        {
            string res = "0|No genera";
            try
            {
                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>INICIA ProcessFiles<<<<<<<<<<<<<<<<<<<<<<<<<", "log");



                string fileName = string.Empty;
                string param1 = string.Empty;
                string param2 = string.Empty;
                bool nuevo = false;
                DateTime now = DateTime.Now;

                //Asi obtenemos el primer dia del mes actual
                DateTime oPrimerDiaDelMes = new DateTime(now.AddMonths(-1).Year, now.AddMonths(-1).Month, 1);

                //Y de la siguiente forma obtenemos el ultimo dia del mes
                //agregamos 1 mes al objeto anterior y restamos 1 día.
                DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

                if (now.Day >= 1 && now.Day < 8)
                {

                    param1 = oPrimerDiaDelMes.Year.ToString().Substring(2, 2) + oPrimerDiaDelMes.Month.ToString().PadLeft(2, '0') + "22";
                    param2 = oPrimerDiaDelMes.Year.ToString().Substring(2, 2) + oPrimerDiaDelMes.Month.ToString().PadLeft(2, '0') + oUltimoDiaDelMes.Day.ToString().PadLeft(2, '0');
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 8 && now.Day < 15)
                {
                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "01";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "07";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 15 && now.Day < 22)
                {

                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "08";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "14";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;

                    }
                }
                else if (now.Day >= 22)
                {
                    param1 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "15";
                    param2 = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') + "21";
                    fileName = param1 + "_al_" + param2;
                    if (!File.Exists(pathPrograma + fileName + ".zip"))
                    {
                        nuevo = true;
                    }
                }

                if (nuevo)
                {
                    res = "1|" + param1 + "|" + param2;
                }

                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>FIN ProcessFiles<<<<<<<<<<<<<<<<<<<<<<<<<", "log");

            }
            catch (Exception ex)
            {
                Logger.Log.LogInFile("++++++++++++++++++ ERROR: " + ex.Message, "log");
                res= "-1|"+ ex.Message;
            }
            return res;
        }

        public void CreateFiles(string param1, string param2)
        {
            try
            {
                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>INICIA Create Files<<<<<<<<<<<<<<<<<<<<<<<<<", "log");


                //DETIENE EL SERVICIO DE HASAR
                Logger.Log.LogInFile("DETIENE PROCESO HASAR", "log");
                ServiceController service = new ServiceController(serviceName);
                if ((!service.Status.Equals(ServiceControllerStatus.Stopped)) && (!service.Status.Equals(ServiceControllerStatus.StopPending)))
                    service.Stop();
                Delay(5);
                Logger.Log.LogInFile(pathPrograma + "getaudar.exe", "log");
                Logger.Log.LogInFile("-p " + port + "  -i serial -a " + param1 + " " + param2, "log");

                Logger.Log.LogInFile("********** COMIENZA A GENERAR ARCHIVOS AFIP ***********", "log");
                System.Diagnostics.Process appy = new System.Diagnostics.Process();
                appy.StartInfo.FileName = pathPrograma + "getaudar.exe";
                appy.StartInfo.Arguments = "-p " + port + "  -i serial -a " + param1 + " " + param2;
                appy.Start();
                appy.WaitForExit();
                Delay(5);
                if (appy.HasExited)
                {
                    Logger.Log.LogInFile("********** FIN GENERAR ARCHIVOS AFIP ***********", "log");
                    //CREA DIRECTORIO
                    try
                    {
                        Directory.CreateDirectory(pathPrograma + param1 + "_al_" + param2);
                    }
                    catch (Exception exCD)
                    {
                        throw new Exception("Error creando directorio: " + pathPrograma + param1 + "_al_" + param2 + " -->" + exCD.Message);
                    }

                    //MUEVE ARCHIVOS AL DIRECTORIO
                    try
                    {
                        System.IO.File.Move(pathPrograma.Replace(@"\GETxxxAR", "") + "afip.85", pathPrograma + param1 + "_al_" + param2 + @"\afip.85");
                    }
                    catch (Exception exFC1)
                    {
                        throw new Exception("Error Moviendo archivo: " + pathPrograma.Replace(@"\GETxxxAR", "") + "afip.85" + " -->" + exFC1.Message);
                    }

                    try
                    {
                        System.IO.File.Move(pathPrograma.Replace(@"\GETxxxAR", "") + "afip.zip", pathPrograma + param1 + "_al_" + param2 + @"\afip.zip");
                    }
                    catch (Exception exFC2)
                    {
                        throw new Exception("Error Moviendo archivo: " + pathPrograma.Replace(@"\GETxxxAR", "") + "afip.zip" + " -->" + exFC2.Message);
                    }

                    //COMPRIME DIRECTORIO
                    try
                    {
                        ZipSystem.CompressDirectory(pathPrograma + param1 + "_al_" + param2 + @"\", param1 + "_al_" + param2);
                    }
                    catch (Exception exZ)
                    {
                        throw new Exception("Error Zipiando Backup --> " + exZ.Message);
                    }

                    //ELIMINA DIRECTORIO
                    try
                    {
                        //System.IO.File.Delete(PathBackup);
                        Directory.Delete(pathPrograma + param1 + "_al_" + param2, true);
                    }
                    catch (Exception exDir)
                    {
                        throw new Exception("Error Eliminando Directorio: " + pathPrograma + param1 + "_al_" + param2 + " --> " + exDir.Message);
                    }


                    //System.Diagnostics.Process.Start("C:/Archivos de programa/XXI/DAT/VUTIL.EXE", "/c -unload CEI31.DAT xxx.txt");

                    //INICIA EL SERVICIO DE HASAR
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        Delay(5);
                        Logger.Log.LogInFile("INICIA PROCESO HASAR", "log");
                        service.Start();
                        Delay(5);
                    }

                    try
                    {
                        EnviarMail(param1, param2);
                    }
                    catch (Exception exMail)
                    {
                        throw new Exception("Error Generando email --> " + exMail);
                    }
                }                

                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>FIN PROCESO Create Files<<<<<<<<<<<<<<<<<<<<<<<<<", "log");

            }
            catch (Exception ex)
            {
                Logger.Log.LogInFile("++++++++++++++++++ ERROR: " + ex.Message, "log");
                throw ex;
            }
        }

        public void EnviarMail(string param1, string param2)
        {
            string from = System.Configuration.ConfigurationManager.AppSettings["from"].ToString();
            string to = System.Configuration.ConfigurationManager.AppSettings["to"].ToString();
            string asunto = System.Configuration.ConfigurationManager.AppSettings["asunto"].ToString();
            try
            {
                Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>INICIO PROCESO EnviarEmail<<<<<<<<<<<<<<<<<<<<<<<<<", "log");

                StreamReader streamReader = new StreamReader(System.Configuration.ConfigurationSettings.AppSettings["EmailTemplatePath"]);

                string filePath = pathPrograma + param1 + "_al_" + param2 + ".ZIP";

                Logger.Log.LogInFile("pathPrograma: " + pathPrograma, "log");

                //string cuerpo = streamReader.ReadToEnd().Replace("{nombreLex}", lexName).Replace("{totalLex}", lexLenght).Replace("{nombreSQL}", sqlName).Replace("{totalSQL}", sqlLenght).Replace("{nombreArchivo}", archivoName).Replace("{totalArchivo}", archivoLenght);
                string cuerpo = streamReader.ReadToEnd();

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential("management.system.info@gmail.com", "neaniylgyjebyqux");
                smtp.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(from);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.Bcc.Add(new MailAddress("martin_orio@yahoo.com.ar"));

                Attachment adjunto = new Attachment(filePath, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = adjunto.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
                // Add the file attachment to this email message.
                mail.Attachments.Add(adjunto);

                //foreach (string s in attachs)
                //{
                //    mail.Attachments.Add(new Attachment(s));
                //}
                //foreach (string s in imagenesInlines.Keys)
                //{
                //    // generate the contentID string using the datetime
                //    string attachmentPath = Path.Combine(Environment.CurrentDirectory, imagenesInlines[s]);
                //    string contentID = Path.GetFileName(imagenesInlines[s]).Replace(".", "") + "@zofm";

                //    Attachment inline = new Attachment(imagenesInlines[s]);
                //    inline.ContentDisposition.Inline = true;
                //    inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                //    inline.ContentId = contentID;
                //    inline.ContentType.MediaType = "image/jpg";
                //    inline.ContentType.Name = Path.GetFileName(imagenesInlines[s]);
                //    mail.Attachments.Add(inline);

                //    // replace the tag with the correct content ID
                //    mail.Body = mail.Body.Replace(s, "cid:" + contentID);

                //}

                //***************************************************************************
                //Se agrega de forma providoria las credenciales de un servidor alternativo
                //***************************************************************************
                //pro.turbo-smtp.com
                //smtp.Credentials = new System.Net.NetworkCredential("info@clubdeofertas.com.ar", "zSfeJBL0");
                //smtp.Port = 587;

                //smtp.sendgrid.net
                //smtp.Credentials = new System.Net.NetworkCredential("info@clubdeofertas.com.ar", "percobarocho2016");
                //***************************************************************************
                try
                {
                    smtp.Send(mail);
                    mail.Dispose();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error enviando email -->" + ex.Message);
                }


                //MailMessage msg = new MailMessage();
                //msg.To.Add(new MailAddress(to));
                //msg.From = new MailAddress(from);
                //msg.Subject = "Bienvenido a e-shop";
                //msg.Body = "Prueba ";
                //SmtpClient clienteSmtp = new SmtpClient();
                //clienteSmtp.Host = "smtp.gmail.com";
                //clienteSmtp.Port = 587;
                //clienteSmtp.UseDefaultCredentials = false;
                //clienteSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //clienteSmtp.Credentials = new System.Net.NetworkCredential("martinorio@gmail.com", "ormasoft28171607");
                //clienteSmtp.EnableSsl = true;
                //clienteSmtp.Send(msg);

            }
            catch (Exception e)
            {
                Logger.Log.LogInFile("++++++++++++++++++ ERROR: " + e.Message, "log");
            }
            Logger.Log.LogInFile(">>>>>>>>>>>>>>>>>>>>>FIN PROCESO EnviarEmail<<<<<<<<<<<<<<<<<<<<<<<<<", "log");
        }
    }
}
