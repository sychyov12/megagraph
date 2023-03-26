using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor.datamodel
{
    public class PointGraphList
    {
        public List<PointGraph> graphes;
        public double YScale { get; set; } = 1;
        public double XScale { get; set; } = 1;
        public GraphPoint zeroScr { get; set; }
        public string Name { get; set; }
        public PointGraphList()
        {
            graphes = new List<PointGraph>();
        }
        public PointGraphList(List<PointGraph> graphes)
        {
            this.graphes = graphes;
        }
    }
}
