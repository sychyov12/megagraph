using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace monitor.datamodel
{
    public class GraphPoint
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
        public GraphPoint() { }
        public GraphPoint(DateTime X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
