using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.Drawing.Imaging;

namespace Core.Business
{
    public class QRSystem
    {
        string pathFilesBarCode = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["pathFilesBarCode"]);
        public Image GenerarCodigoQR(string fileName, string txtJson)
        {
            try
            {
                byte[] myByte = System.Text.Encoding.UTF8.GetBytes(txtJson);
                string myBase64 = Convert.ToBase64String(myByte);

                string datos = "https://www.afip.gob.ar/fe/qr/?p=" + myBase64;
                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
                QrCode qrCode = new QrCode();
                qrEncoder.TryEncode(datos, out qrCode);
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(300, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                MemoryStream ms = new MemoryStream();
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                var imageTemporal = new Bitmap(ms);
                var imagen = new Bitmap(imageTemporal, new Size(new Point(150, 150)));

                imagen.Save(pathFilesBarCode + fileName + ".png", ImageFormat.Png);

                return imagen;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
