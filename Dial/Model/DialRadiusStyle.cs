using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 标度线半径样式
    /// </summary>
    public class DialRadiusStyle
    {
        public DialRadiusStyle(double r, RadiusType style = RadiusType.Inner)
        {
            this.R = r;
            this.Style = style;
        }

        /// <summary>
        /// 标度线半径长度
        /// <para>单位：毫米(mm)</para>
        /// </summary>
        public double R { get; set; }

        /// <summary>
        /// 标度线半径类型
        /// </summary>
        public RadiusType Style { get; set; }
    }
}
