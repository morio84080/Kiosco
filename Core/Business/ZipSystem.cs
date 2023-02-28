using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace Core.Business
{
    public class ZipSystem
    {
        public static void CompressDirectory(string directoryPath)//(string inputFilePath, string outputFilePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(directoryPath);
                zip.Save(directoryPath.Replace(@"\ARCHIVO\", @"\ARCHIVO.ZIP"));
                //zip.AddFile(inputFilePath, "");

                //zip.Save(outputFilePath);
            }
        }

        public static void CompressFile(string inputFilePath, string outputFilePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(inputFilePath, "");

                zip.Save(outputFilePath);
            }
        }

        public static void CompressDirectory(string directoryPath, string nameDirectory)//(string inputFilePath, string outputFilePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(directoryPath);
                zip.Save(directoryPath.Replace(@"\"+nameDirectory+@"\", @"\"+nameDirectory+".ZIP"));
                //zip.AddFile(inputFilePath, "");

                //zip.Save(outputFilePath);
            }
        }
    }
}
