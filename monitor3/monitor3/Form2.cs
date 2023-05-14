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
    public partial class Form2 : Form
    {
        VerticalLineAnnotation VL = null;
        PointGraphList gList = null;
        public Form2()
        {
            InitializeComponent();

            gList = new PointGraphList() { Name = "Группа графиков 1" };
            VL = new VerticalLineAnnotation();  // the annotation

            chart1.Series.Clear();
            //VL = new VerticalLineAnnotation();  // the annotation
            //VL.AllowMoving = true;              // make it interactive

            ////VL.AnchorDataPoint = chart1.Series[0].Points[0];  // start at the 1st point
            //VL.LineColor = Color.Red;
            //VL.IsInfinitive = true;             // let it go all over the chart

            //chart1.Annotations.Add(VL);

            setupbutton_Click();
        }

        private void setupbutton_Click()
        {
        }

        public void updateChecklist()
        {
            checkedListBox1.Items.Clear();
            foreach (var g in gList.graphes)
            {
                checkedListBox1.Items.Add(g.Name, g.IsSelected);
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

        public void updateGraph()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
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
                VL.AnchorDataPoint = chart1.Series[0].Points[0];  // start at the 1st point
                VL.LineColor = Color.Red;
                VL.LineWidth = 2;
                VL.IsInfinitive = true;             // let it go all over the chart
                chart1.Annotations.Add(VL);
            }

            //chart1.ChartAreas[0].AxisY.Maximum = chart1.Series.Max(s => s.Points.Max(p => p.YValues.Max()));
            //chart1.ChartAreas[0].AxisY.Minimum = chart1.Series.Min(s => s.Points.Min(p => p.YValues.Min()));
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            foreach (var a in chart1.Annotations)
            {
                a.X = chart1.ChartAreas[0].AxisX.PixelPositionToValue((e as MouseEventArgs).X);
            }
        }
    }
}
