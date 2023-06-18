using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor.datamodel
{
    public class PointGraph
    {
        public List<GraphPoint> points;
        public bool IsActive { get; set; }
        public Color Color { get; set; }
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public double Scale { get; set; }
        public PointGraph(IEnumerable<GraphPoint> points)
        {
            this.points = new List<GraphPoint>(points);
        }
    }
}
