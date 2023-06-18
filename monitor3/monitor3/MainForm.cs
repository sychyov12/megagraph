using monitor.datamodel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace monitor3
{
    public partial class MainForm : Form
    {
        VerticalLineAnnotation VL = null;
        PointGraphList gList = null;
        public MainForm()
        {
            InitializeComponent();

            gList = new PointGraphList() { Name = "Группа графиков 1" };
            VL = new VerticalLineAnnotation();  // the annotation

            chart1.Series.Clear();
            hideSettings();
        }

        public void updateChecklist()
        {
            listBox1.Items.Clear();
            foreach (var g in gList.graphes)
            {
                listBox1.Items.Add(g.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pColorSample.BackColor = colorDialog1.Color;
            }
        }

        private void добавитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaderForm lf = new LoaderForm();

            if (lf.ShowDialog() == DialogResult.OK && lf.pg != null)
            {
                PointGraph pg = lf.pg;
                pg.Scale = 1;
                pg.IsSelected = true;
                gList.graphes.Add(pg);
                updateChecklist();
                updateGraph();
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateGraph();
        }

        // уменьшим количество точек 1 графика в пределах видимости     
        public List<GraphPoint> ReducePoints(PointGraph g)
        {
            var ans = new List<GraphPoint>();

            return ans;
        }

        public void updateGraph()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            double annX = double.NaN;   
            if(chart1.Annotations.Count > 0)
                annX = chart1.Annotations[0].X;
            chart1.Annotations.Clear();
            //печать графиков
            foreach (var g in gList.graphes)
            {
                var s = new Series();
                s.ChartType = SeriesChartType.Line;
                while (chart1.Series.Any(sr => sr.Name == g.Name))
                    g.Name += "1";
                s.Name = g.Name;
                s.XValueType = ChartValueType.DateTime;
                g.points.Sort((p1, p2) => p1.X.CompareTo(p2.X));
                foreach (var p in g.points)
                {
                    s.Points.AddXY(p.X, p.Y);
                }
                if(!g.Color.IsEmpty)
                    s.Color = g.Color;
                chart1.Series.Add(s);
                
            }

            if (chart1.Series.Count > 0 && chart1.Series[0].Points.Count > 0)
            {
                chart1.ChartAreas.Add(new ChartArea());
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd hh:mm:ss";
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

                VL.AllowMoving = true;              // make it interactive
                //VL.AnchorDataPoint = chart1.Series[0].Points[0];  // start at the 1st point
                annX = annX != double.NaN ? annX : chart1.Series.Min(s => s.Points.Min(p => p.XValue));
                var bp = chart1.Series[0].Points[0];
                foreach (var s in chart1.Series)
                    foreach (var p in s.Points)
                        if (Math.Abs(p.XValue - annX) < Math.Abs(bp.XValue - annX))
                            bp = p;
                VL.AnchorDataPoint = bp;
                VL.LineColor = Color.Red;
                VL.LineWidth = 2;
                VL.IsInfinitive = true;             // let it go all over the chart
                chart1.Annotations.Add(VL);
            }
            // нстройка масштаба (увеличение графика)

            chart1.ChartAreas[0].AxisX.Maximum = gList.XMax != DateTime.MaxValue ? gList.XMax.ToOADate() : chart1.Series.Max(s => s.Points.Max(p => p.XValue));
            chart1.ChartAreas[0].AxisX.Minimum = gList.XMin != DateTime.MinValue ? gList.XMin.ToOADate() : chart1.Series.Min(s => s.Points.Min(p => p.XValue));
        }

        private void hideSettings()
        {
            this.pColorSample.BackColor = Color.White;
            this.btnChangeColor.Enabled = false;
            this.nudScale.Enabled = false;
        }

        private void loadSettings(int index)
        {
            var selectedGraph = gList.graphes[index];
            this.pColorSample.BackColor = chart1.Series[index].Color;
            this.btnChangeColor.Enabled = true;
            this.nudScale.Enabled = true;
            this.nudScale.Value = (decimal)gList.graphes[index].Scale;
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            foreach (var a in chart1.Annotations)
            {
                a.X = chart1.ChartAreas[0].AxisX.PixelPositionToValue((e as MouseEventArgs).X);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndices.Count > 0)
                loadSettings(lb.SelectedIndex);
            else
                hideSettings();
        }

        private void btnSetSettings_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            gList.graphes[index].Scale = (double) nudScale.Value;
            gList.graphes[index].Color = pColorSample.BackColor;
            updateGraph();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Zoom(true, 1);
        }

        public void Zoom(bool direction, int mode)
        {
            if (gList.graphes.Count == 0)
                return;
            var graphMin = (gList.XMin != DateTime.MinValue ? gList.XMin : gList.graphes.Min(g => g.points.Min(p => p.X))).ToOADate();
            var graphMax = (gList.XMax != DateTime.MaxValue ? gList.XMax : gList.graphes.Max(g => g.points.Max(p => p.X))).ToOADate();
            var pointX = chart1.Annotations[0].X;
            pointX = Math.Min(Math.Max(pointX, graphMin), graphMax);// убедимся, что ось находится на экране

            var diff = (graphMax - graphMin);
            var oneStepDiff = mode == 1 ? 0.1 : mode == 2 ? 0.3 : 0.9;
            var dr = direction ? 1 : -1;
            var newMin = graphMin + dr * (pointX - graphMin) * oneStepDiff;
            var newMax = graphMax - dr * (graphMax - pointX) * oneStepDiff;
            gList.XMin = DateTime.FromOADate(newMin);
            gList.XMax = DateTime.FromOADate(newMax);
            updateGraph();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Zoom(false, 1);
        }

        private void btnPPP_Click(object sender, EventArgs e)
        {
            Zoom(true, 3);
        }

        private void btnPP_Click(object sender, EventArgs e)
        {
            Zoom(true, 2);
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            Zoom(false, 2);
        }

        private void btnMMM_Click(object sender, EventArgs e)
        {
            Zoom(false, 2);
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            if (gList.graphes.Count == 0)
                return;
            gList.XMin = DateTime.MinValue;
            gList.XMax = DateTime.MaxValue;
            updateGraph();
        }
    }
}
