using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{
    public class Log
    {
        public static void LogInFile(string cadena, string fileName)
        {
            string path = System.Configuration.ConfigurationSettings.AppSettings["pathLog"].ToString();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + fileName + "_" + DateTime.Today.ToString("yyyy-MM-dd");
            string extension = ".log";
            StreamWriter sw = null;

            int ifile = 0;
            while (true)
            {
                try
                {
                    sw = File.AppendText(path + "_" + ifile.ToString() + extension);
                    break;
                }
                catch (Exception e)
                {
                    ifile++;
                    if (ifile > 32) break;
                }
            }

            try
            {
                sw.WriteLine(DateTime.Now.ToString() + "|" + cadena);
                sw.Flush();
                //sw.Close();
                //sw.Dispose();
            }
            catch (Exception ex)
            {

                try
                {
                    string pathError = System.Configuration.ConfigurationSettings.AppSettings["pathLog"].ToString();
                    if (!Directory.Exists(pathError))
                    {
                        Directory.CreateDirectory(pathError);
                    }
                    pathError = pathError + "CaptureLogError_" + DateTime.Today.ToString("yyyy-MM-dd");
                    string extensionErr = ".log";
                    StreamWriter swErr = null;

                    int ifileErr = 0;
                    while (true)
                    {
                        try
                        {
                            swErr = File.AppendText(pathError + "_" + ifileErr.ToString() + extensionErr);
                            break;
                        }
                        catch (Exception e)
                        {
                            ifileErr++;
                            if (ifileErr > 32) break;
                        }
                    }

                    swErr.WriteLine(DateTime.Now.ToString() + "|" + cadena + "|" + ex.Message);
                    swErr.Flush();
                    swErr.Close();
                    swErr.Dispose();

                }
                catch { }
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
