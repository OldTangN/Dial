using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Dial.Helper
{
    public static class ImageHelper
    {
        public static BitmapImage GetImageSource(string path)
        {
            BitmapImage bitmap = new BitmapImage();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(path);
            bitmap = GetImageSource(bmp);
            return bitmap;
        }

        public static BitmapImage GetImageSource(System.Drawing.Bitmap bmp)
        {
            BitmapImage bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, bmp.RawFormat);
            bmp.Dispose();
            bitmap = GetImageSource(ms);
            return bitmap;
        }

        public static BitmapImage GetImageSource(MemoryStream ms)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            bitmap.Freeze();
            ms.Close();
            ms.Dispose();
            return bitmap;
        }
    }
}
