using System;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;
using System.Net;

namespace Kino_3._0
{
    class ImageResize
    {
        static Image ScaleImage(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(System.Drawing.Brushes.White, 0, 0, width, height); // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                //float srcwidth = source.Width;
                //float srcheight = source.Height;
                //float dstwidth = width;
                //float dstheight = height;

                //if (srcwidth <= dstwidth && srcheight <= dstheight) // Исходное изображение меньше целевого
                //{
                //    int left = (width - source.Width) / 2;
                //    int top = (height - source.Height) / 2;
                //    gr.DrawImage(source, left, top, source.Width, source.Height);
                //}
                //else if (srcwidth / srcheight > dstwidth / dstheight) // Пропорции исходного изображения более широкие
                //{
                //    float cy = srcheight / srcwidth * dstwidth;
                //    float top = ((float) dstheight - cy) / 2.0f;
                //    if (top < 1.0f) top = 0;
                //    gr.DrawImage(source, -5, top - 20, dstwidth +10, cy + 20);
                //}
                //else // Пропорции исходного изображения более узкие
                //{
                //    float cx = srcwidth / srcheight * dstheight;
                //    float left = ((float) dstwidth - cx) / 2.0f;
                //    if (left < 1.0f) left = 0;
                //    gr.DrawImage(source, left, 0, cx, dstheight);
                //}
                
                gr.DrawImage(source, 0, 0, width, height);
                gr.Dispose();

                return dest;
            }
        }

        //static Image ScaleImageMain(Image img)
        //{
        //    int x1 = 200;
        //    int y1 = 200;
        //    int x2 = 3;
        //    int y2 = 3;
        //    if (img.Width > img.Height)
        //    {
        //        x1 = 200;
        //        y1 = (int) Math.Round((double) img.Height / (img.Width / 200));
        //        y2 = (int) Math.Round((double) ((200 - y1) / 2));
        //    }
        //    else
        //    {
        //        if (img.Width < img.Height)
        //        {
        //            y1 = 200;
        //            x1 = (int) Math.Round((double) img.Width / (img.Height / 200));
        //            x2 = (int) Math.Round((double) ((200 - x1) / 2));
        //        }
        //    }

        //    img = ScaleImage(img, x1, y1);
        //    Image dest = new Bitmap(208, 208);
        //    Graphics gr = Graphics.FromImage(dest);

        //    return dest;
        //}

        public static string image2;

        public static void GetImage()
        {
            //выдираем картинку и сохраняем в загрузки в папку редактор
            WebClient webClient = new WebClient();
            if (KinoFrukt.url.Contains("kinofrukt"))
            {
                KinoFrukt.image = KinoFrukt.image.Replace("<img src=\"", "http://kinofrukt.me");
                int indexImage = KinoFrukt.image.IndexOf("\" ", StringComparison.Ordinal);
                image2 = string.Format(KinoFrukt.image.Substring(0, indexImage));
            }
            else if (KinoFrukt.url.Contains("kinopoisk"))
            {
                image2 = KinoFrukt.image;
            }

            Uri uri = new Uri(image2);
            byte[] bytes = webClient.DownloadData(uri);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            try
            {
                img = ScaleImage(img, 200, 300);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MemoryStream mass = new MemoryStream();

            string imagePath = KinoFrukt.nazv1;
            if (KinoFrukt.seasonNumber > 1)
            {
                imagePath = KinoFrukt.nazv1 + " " + KinoFrukt.seasonNumber + " сезон";
            }
            else
            {
                imagePath = KinoFrukt.nazv1;
            }

            if (imagePath.Contains(":"))
                imagePath = imagePath.Replace(":", "");
            if (imagePath.Contains("?"))
                imagePath = imagePath.Replace("?", "");

            FileStream fs = new FileStream(
                $"C:\\Users\\!!!!ТЕКУЩИЙ ЮЗЕР!!!!\\Downloads\\redactor\\!kinofrukt\\{imagePath}.jpg",
                System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            img.Tag = $"{imagePath} ({KinoFrukt.year})";
            img.Save(mass, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] matric = mass.ToArray();
            fs.Write(matric, 0, matric.Length);
            mass.Close();
            fs.Close();
        }
    }
}
