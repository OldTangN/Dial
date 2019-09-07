using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Helper
{
   public class MathHelper
    {
        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="milimeter"></param>
        /// <param name="dpi">分辨率默认72</param>
        /// <returns></returns>
        public static double Milimeter2Pixel(double milimeter,double dpi = 72)
        {
            //1 inch = 25.4 mm
            //dpi: dot per inch
            //1mm = dpi/25.4 pixel
            return milimeter * dpi / 25.4;
        }

        /// <summary>
        /// 像素转毫米
        /// </summary>
        /// <param name="pixel">像素值</param>
        /// <param name="dpi">分辨率默认72</param>
        /// <returns></returns>
        public static double Pixel2Milimeter(double pixel,double dpi = 72)
        {
            return pixel / dpi * 25.4;
        }
    }
}
