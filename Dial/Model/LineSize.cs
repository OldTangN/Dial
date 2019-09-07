using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 标度线尺寸
    /// </summary>
    public class LineSize
    {
        public LineSize(double thickness, double length)
        {
            this.Thickness = thickness;
            this.Length = length;
        }
        /// <summary>
        /// 线宽
        /// </summary>
        public double Thickness { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public double Length { get; set; }
    }
}
