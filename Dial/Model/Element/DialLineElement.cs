using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
   public class DialLineElement : DialElement
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double Thickness { get; set; }

        public System.Drawing.Color Fill { get; set; }
    }
}
