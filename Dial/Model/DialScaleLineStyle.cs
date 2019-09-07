using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 标度线样式
    /// </summary>
    public class DialScaleLineStyle
    {
        /// <summary>
        /// 长、中、短标度线默认HalfThick、Thin、Thin
        /// </summary>
        public DialScaleLineStyle()
        {

        }

        /// <summary>
        /// 长标度线线型,默认HalfThick
        /// </summary>
        public LineType LongScaleLineType { get; set; } = LineType.HalfThick;

        /// <summary>
        /// 中标度线线型,默认Thin
        /// </summary>
        public LineType MidScaleLineType { get; set; } = LineType.Thin;

        /// <summary>
        /// 端标度线线型,默认Thin
        /// </summary>
        public LineType ShortScaleLineType { get; set; } = LineType.Thin;
    }
}
