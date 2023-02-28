using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess;
using System.IO;
using Logger;
using System.Configuration;
using ctc3DES;
using FTP;

namespace Core.Business
{
    public class DataBaseBusiness
    {
        DataBaseDALC dBaseDac = new DataBaseDALC();
        public void ProcessBackup() {

            try
            {
                string pathBkp = System.Configuration.ConfigurationManager.AppSettings["pathBkp"].ToString();
                DateTime now = new DateTime();
                now = DateTime.Now;

                pathBkp += now.ToString("dd-MM-yyyy") + ".bak";
                if (!File.Exists(pathBkp))
                {
                    try
                    {


                        try { Logger.Log.LogInFile("COMIENZA GENERACION BKP --> " + pathBkp, "Bkp.log"); }
                        catch { }
                        dBaseDac.BackupDiario(pathBkp);
                    }
                    catch (Exception exBkp)
                    {
                        try { Logger.Log.LogInFile("ERROR GENERANDO BKP --> " + exBkp.Message, "Bkp.log"); }
                        catch { }
                    }

                    try { Logger.Log.LogInFile("<<<<<<<<COMPRIME FILES BD>>>>>>> ", "Bkp.log"); }
                    catch { }
                    ZipSystem.CompressFile(pathBkp, pathBkp.Replace(".bak", ".zip"));

                    try
                    {

                        try { Logger.Log.LogInFile("<<<<<<<<DELETE FILES BD>>>>>>> ", "Bkp.log"); }
                        catch { }

                        System.IO.File.Delete(pathBkp);
                    }
                    catch (Exception exDir)
                    {
                        try { Logger.Log.LogInFile("<<<<<<<<ERROR ELIMINANDO ARCHIVOS DE BD>>>>>>> " + pathBkp + " - ERROR --> " + exDir.Message, "backupAutomatic.log"); }
                        catch { }
                    }

                    //SUBE LOS ARCHIVOS AL FTP
                    try
                    {
                        ctc3DES.TripleDESUtil ctc = new TripleDESUtil();
                        string DatabaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"].ToString();
                        string strUser = System.Configuration.ConfigurationManager.AppSettings["userFTP"].ToString();
                        string strPassword = System.Configuration.ConfigurationManager.AppSettings["passFTP"].ToString();
                        string strPathFTP = System.Configuration.ConfigurationManager.AppSettings["pathFTP"].ToString();
                        string fileName = DatabaseName + DateTime.Now.ToString("dd-MM-yyyy") + ".zip";

                        try { strUser = ctc.DesEncriptar(strUser); }
                        catch { strUser = System.Configuration.ConfigurationManager.AppSettings["userFTP"].ToString(); }
                        try { strPassword = ctc.DesEncriptar(strPassword); }
                        catch { strPassword = System.Configuration.ConfigurationManager.AppSettings["passFTP"].ToString(); }
                        try { strPathFTP = ctc.DesEncriptar(strPathFTP); }
                        catch { strPathFTP = System.Configuration.ConfigurationManager.AppSettings["pathFTP"].ToString(); }

                        FTP.SystemFTP ftp = new SystemFTP();
                        ftp.Upload(strUser, strPassword, pathBkp.Replace(".bak", ".zip"), strPathFTP + "/" + fileName);
                    }
                    catch (Exception exFTP)
                    {
                        try { Logger.Log.LogInFile("<<<<<<<<ERROR SUBIENDO ARCHIVOS AL FTP>>>>>>> " + pathBkp + " - ERROR --> " + exFTP.Message, "backupAutomatic.log"); }
                        catch { }
                    }
                }

            }
            catch(Exception exGral) {
                try { Logger.Log.LogInFile("ERROR EXCEPCION GRAL --> " + exGral.Message, "Bkp.log"); }
                catch { }

            }
        }
    }
}
