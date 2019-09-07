using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dial.Model
{
    public class DialPathElement : DialElement
    {
        public double X { get; set; }
        public double Y { get; set; }

        public string Document { get; set; }
    }
}
