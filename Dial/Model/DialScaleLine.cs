using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    /// <summary>
    /// 标度线
    /// </summary>
    public class DialScaleLine
    {
        public DialScaleLine()
        {
            this.CheckPoints = new List<DialCheckPoint>()
            {
                new DialCheckPoint(0),
                new DialCheckPoint(0.2),
                new DialCheckPoint(0.4),
                new DialCheckPoint(0.6),
                new DialCheckPoint(0.8),
                new DialCheckPoint(1)
            };
        }
        
        /// <summary>
        /// 表盘宽度
        /// </summary>
        public double DialWidth { get; set; }

        /// <summary>
        /// 表盘高度
        /// </summary>
        public double DialHeight { get; set; }
        
        /// <summary>
        /// 精度等级。例如 0.1, 0.16, 0.25, 0.4, 1.0, 1.6, 2.5, 4.0 等
        /// <para>默认1.0</para>
        /// </summary>
        public double Precision { get; set; } = 1.0;

        /// <summary>
        /// 标度线角度量程，即零压与满量程之间指针行走角度
        /// <para>默认：270度（°）</para>
        /// </summary>
        public double AngleRange { get; set; } = 270.0;

        /// <summary>
        /// 角度量程误差
        /// <para>默认：±5度（°）</para>
        /// </summary>
        public double AngleRangeError { get; set; } = 0;

        /// <summary>
        /// 总分格数
        /// <para>默认</para>
        /// </summary>
        public int GridCount { get; set; }

        /// <summary>
        /// 每分格压力值
        /// </summary>
        public double GridDegrees { get; set; }

        /// <summary>
        /// 标度线样式
        /// </summary>
        public DialScaleLineStyle ScaleLineStyle { get; set; } = new DialScaleLineStyle();

        /// <summary>
        /// 标度线半径类型
        /// </summary>
        public DialRadiusStyle RadiusStyle { get; set; } = new DialRadiusStyle(60);

        /// <summary>
        /// 0刻度偏移角，顺时针为正数
        /// <para>计算公式：角度范围*精度等级/100。举例：（270*1.6/100）</para>
        /// <para>单位：度（°）</para>
        /// </summary>
        public double ZeroDegreeOffset { get; set; } = 0;

        /// <summary>
        /// 测量值列表
        /// <para>默认值：0, 0.2, 0.4, 0.6, 0.8, 1全显示</para>
        /// </summary>
        public List<DialCheckPoint> CheckPoints { get; set; }

        /// <summary>
        /// 圆心点
        /// </summary>
        public System.Drawing.PointF CircleCenter { get; set; }

        /// <summary>
        /// 每MidLineStep条细线生成一条中短线
        /// </summary>
        public int MidLineStep { get; set; }

        public int LoneLineStep { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
