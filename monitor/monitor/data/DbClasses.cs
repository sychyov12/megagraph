using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace monitor.datamodel
{
    public class GraphList
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class GraphPoint
    {
        public long Id { get; set; }
        [Index]
        public long GraphListId { get; set; }
        public GraphList GraphList { get; set; }
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
