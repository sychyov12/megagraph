using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor.datamodel
{
    public class GraphPoint
    {
        public long Id { get; set; }
        public DateTime X { get; set; }
        public double Y { get; set; }
        public GraphPoint(DateTime X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
