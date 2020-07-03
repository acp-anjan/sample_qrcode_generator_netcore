using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;



namespace NQRcodeN.Controllers
{
    public class QRController : Controller
    {
        public ActionResult Index()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //JsonOptions a = new {productId:1}
            //string json = new JavaScriptSerializer().Serialize(new
            //{
            //    message = new { text = "test sms" },
            //    endpoints = new[] { "dsdsd", "abc", "123" }
            //});
            
            var qrObject = new { ProductId = 1, CategoryId = 2, BrandId = 3, ProductName = "Hello" };
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrObject.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var bitmapBytes = BitmapToBytes(qrCodeImage); //Convert bitmap into a byte array
            /*return File(bitmapBytes, "image/jpeg");*/ //Return as file result
            var a =  File(bitmapBytes, "image/png");
            return a;
        }
        // This method is for converting bitmap into a byte array
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }

            
        }
    }
}