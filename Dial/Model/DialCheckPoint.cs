using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    public class DialCheckPoint
    {
        public DialCheckPoint()
        {

        }

        public DialCheckPoint(double chkValue, bool isShowInDial = true)
        {
            this.CheckValue = chkValue;
            this.IsShowInDial = isShowInDial;
        }

        /// <summary>
        /// 测量值
        /// </summary>
        public double CheckValue { get; set; }

        /// <summary>
        /// 是否在表盘中显示该测量值
        /// </summary>
        public bool IsShowInDial { get; set; } = true;
    }
}
