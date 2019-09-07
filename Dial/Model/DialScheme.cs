using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 表盘模板方案
    /// </summary>
    public class DialScheme
    {
        public double IsDoubleScale { get; set; }

        public DialScaleLine Scale { get; set; }

        /// <summary>
        /// 额外的svg元素列表
        /// </summary>
        public List<DialElement> Elements { get; set; }

        /// <summary>
        /// 图像宽度
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 图像高度
        /// </summary>
        public double Height { get; set; }
    }
}
