using Microsoft.Extensions.Caching.Memory;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Common.Helper
{

    public class CaptchaHelper : ICaptchaHelper
    {

        public  string GenerateRandomCode(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] stringChars = new char[length];


            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];

            }
            return new string(stringChars);
        }

        public  byte[] GenerateCaptchaImage(string captchaCode)
        {
            using (Bitmap bitmap = new Bitmap(120, 40))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Random random = new Random();
                graphics.Clear(Color.LightGray);

                // Captcha metnini çiz
                using (Font font = new Font("Arial", 20, FontStyle.Regular))
                {
                    graphics.DrawString(captchaCode, font, Brushes.Black, new PointF(10, 5));
                }

                // Bazı karışıklık çizgileri ekleyelim
                for (int i = 0; i < 20; i++)
                {
                    graphics.DrawLine(Pens.Black, random.Next(0, 120), random.Next(0, 40), random.Next(0, 120), random.Next(0, 40));
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
    }

    public interface ICaptchaHelper
    {
         string GenerateRandomCode(int length = 5);
         byte[] GenerateCaptchaImage(string captchaCode);
    }
}

