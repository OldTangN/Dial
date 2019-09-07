using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 刻度线
    /// </summary>
    public class DialTickMark_bak
    {
        /// <summary>
        /// 指针角度,单位：度(°)
        /// <para>以垂直向下为0度，顺时针旋转</para>
        /// </summary>
        public double PointerAngle { get; set; }

        /// <summary>
        /// 刻度值
        /// </summary>
        public double Degrees { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }


        public double Length { get; set; }

        public double Thickness { get; set; }
    }
}
