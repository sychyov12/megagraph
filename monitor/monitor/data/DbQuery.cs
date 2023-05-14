using monitor.datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace monitor.data
{
    public delegate void ProgressSendigDelegate(double x);
    public class DbQuery
    {
        MonitoringContext ctx;
        public DbQuery()
        {
            ctx = new MonitoringContext();
        }
        public event ProgressSendigDelegate SendProgress;

        public void PushPoints(long graphListId, List<GraphPoint> points)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < points.Count; i++)
            {
                var point = points[i];
                point.GraphListId = graphListId;

                sb.AppendFormat("insert into GraphPoints(X,Y,GraphListId) values('{0}',{1},{2});", point.X.ToString("yyyy/MM/dd hh:mm:ss"), point.Y, graphListId);
                if (i % 1000 == 0)
                {
                    ctx.Database.ExecuteSqlCommand(sb.ToString());
                    sb.Clear();
                    SendProgress(100.0 * i / points.Count);
                }
            }
        }

        public void ClearGraphList(long graphListId)
        {
            ctx.Database.ExecuteSqlCommand("delete from GraphPoints where GraphListId = {0};", graphListId);
        }

        public PointGraph GetPointGraph(long graphListId)
        {
            return new PointGraph(ctx.GraphPoint.Where(x => x.GraphListId == graphListId).ToList());
        }
    }
}
