using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    public enum ElementType
    {
        Line = 0,
        Text = 1,
        Path = 2
    }

    /// <summary>
    /// 半径方式
    /// </summary>
    public enum RadiusType
    {
        /// <summary>
        /// 内半径
        /// </summary>
        Inner = 0,

        /// <summary>
        /// 外半径
        /// </summary>
        Outer = 1
    }

    public enum LineType
    {
        /// <summary>
        /// 细线
        /// </summary>
        Thin = 0,

        /// <summary>
        /// 粗线
        /// </summary>
        Thick = 1,

        /// <summary>
        /// 半粗线
        /// </summary>
        HalfThick = 3,
    }
}
