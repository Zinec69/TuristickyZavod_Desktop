using turisticky_zavod.Data;
using QRCoder;
using System.Drawing;
using System.Text;

namespace turisticky_zavod.Logic
{
    public class QRHelper
    {
        public static List<Bitmap> GetQRImages(List<Runner> runners)
        {
            var images = new List<Bitmap>();

            var runnersStr = "";
            var bytesList = new List<byte[]>();

            for (int i = 0; i < runners.Count; i++)
            {
                var tmp = $"{runners[i].StartNumber};{runners[i].Name};{runners[i].Team}";
                if (i < runners.Count - 1) tmp += "\n";

                if ((runnersStr.Length + tmp.Length) < 2000)
                {
                    runnersStr += tmp;
                }
                else
                {
                    bytesList.Add(Encoding.GetEncoding("ISO-8859-2").GetBytes(runnersStr));
                    runnersStr = tmp;
                }
            }
            bytesList.Add(Encoding.GetEncoding("ISO-8859-2").GetBytes(runnersStr));

            var qrGenerator = new QRCodeGenerator();
            foreach (var bytes in bytesList)
            {
                var qrCodeData = qrGenerator.CreateQrCode(bytes, QRCodeGenerator.ECCLevel.L);
                var qrCode = new QRCode(qrCodeData);
                images.Add(qrCode.GetGraphic(15));
            }
            
            return images;
        }
    }
}
