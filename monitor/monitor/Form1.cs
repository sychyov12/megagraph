﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using monitor.datamodel;
using System.IO;
using System.Globalization;
using System.Windows.Documents;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Transactions;
using monitor.data;

namespace monitor
{
    public partial class Form1 : Form
    {
        public PointGraphList gList;
        public long graphListId;

        DbQuery db;

        private Color b1 = Color.Coral;
        private Color b0 = Color.FromArgb(255, 240, 240, 240);

        public void FillData()
        {
            gList = new PointGraphList() { Name = "Группа графиков" };

            //var list = db.GraphList.Where(g => g.Id == graphListId).First();

            PointGraph pg = db.GetPointGraph(graphListId);

            pg.IsSelected = true;
            pg.Name = "Max";
            gList.graphes.Add(pg);
            //var pg1 = new PointGraph(pg.points) { Name = "Min", IsSelected = true };
            //gList.graphes.Add(pg1);
            //var pg2 = new PointGraph(pg.points) { Name = "Avg", IsSelected = true };
            //gList.graphes.Add(pg2);
            FillDefInterval();
            UpdateGraphList();
            PrintGraph();
        }

        public void SaveData()
        {
            if (gList.graphes.Count == 0 || gList.graphes[0].points.Count == 0)
                return;

            var points = gList.graphes[0].points;
            db.ClearGraphList(graphListId);
            ProgressBarForm pb = new ProgressBarForm(new Action(() => db.PushPoints(graphListId, points)));
            db.SendProgress += pb.SendProgress;
            pb.ShowDialog();
        }

        public Form1( long graphListId = 0)
        {
            this.graphListId = graphListId;

            InitializeComponent();
            db = new DbQuery();
            FillData();
            PrintGraph();
            UpdateGraphList();
        }

        private void FillDefInterval()
        {
            if (gList.graphes.Count == 0 || gList.graphes[0].points.Count == 0)
                return;
            dateStart = gList.graphes.Select(x => x.points.First().X).Min();
            dateEnd = gList.graphes.Select(x => x.points.Select(p => p.X).Max()).Max();
            intervalType = 3;
        }

        private DateTime IncreaseInterval(DateTime interval, int intervalType, int delta = 1)
        {
            switch (intervalType)
            {
                case 0: return interval.AddSeconds(delta);
                case 1: return interval.AddMinutes(delta);
                case 2: return interval.AddHours(delta);
                default: return interval.AddDays(delta);
            }
        }

        private DateTime RoundInterval(DateTime dateStart, int intervalType)
        {
            switch (intervalType)
            {
                case 0: return new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, dateStart.Hour, dateStart.Minute, dateStart.Second);
                case 1: return new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, dateStart.Hour, dateStart.Minute, 0);
                case 2: return new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, dateStart.Hour, 0, 0);
                default: return new DateTime(dateStart.Year, dateStart.Month, dateStart.Day,0, 0, 0);
            }
        }

        DateTime dateStart; //левый край графика
        DateTime dateEnd; //правый край графика
        int intervalType; // тип интервала 0 секунда 1 минута 2 час 3 день
        private List<List<GraphPoint>> SelectPrintedDataForGraph(PointGraphList grList)
        {
            // 1 number of days
            // 2 number of hour in day
            // 3 number of minetes in hour
            // 4 number of seconds in selected minute
            var unswer = new List<List<GraphPoint>>();
            if (grList.graphes.Count == 0)
                return unswer;

            new List<int>(new int[] { 1, 2, 3}).ForEach(gr => unswer.Add(new List<GraphPoint>()));
            //avg
            var interval = RoundInterval(this.dateStart, this.intervalType);
            var maxInterval = RoundInterval(this.dateEnd, this.intervalType);
            var nextInterval = IncreaseInterval(interval, intervalType);
            //calc hour result
            for (; interval <= maxInterval; interval = nextInterval, nextInterval = IncreaseInterval(nextInterval, intervalType))
            {
                for (int i = 0; i < grList.graphes.Count; i++)
                {
                    int aggType = i;
                    double intervalPointValue = 0;
                    try
                    {
                        intervalPointValue = grList.graphes[i].points.Where(p => p.X >= interval && p.X < nextInterval).Select(p => p.Y).Max();
                        unswer[0].Add(new GraphPoint(interval, intervalPointValue));
                        intervalPointValue = grList.graphes[i].points.Where(p => p.X >= interval && p.X < nextInterval).Select(p => p.Y).Min();
                        unswer[1].Add(new GraphPoint(interval, intervalPointValue));
                        intervalPointValue = grList.graphes[i].points.Where(p => p.X >= interval && p.X < nextInterval).Select(p => p.Y).Average();
                        unswer[2].Add(new GraphPoint(interval, intervalPointValue));
                    }
                    catch { break; }
                }
            }
            return unswer;
        }

        public void PrintGraph()
        {
            int maxPointsOnScreen = 100;
            SeriesCollection ser1 = new SeriesCollection();
            var data = SelectPrintedDataForGraph(gList);
            
            foreach (var g in gList.graphes)
            {
                int i = 0;
                foreach (var points in data)
                {
                    int partCount = Math.Max(g.points.Count / maxPointsOnScreen, 0);
                    //var pointsToShow = new List<GraphPoint>();
                    //for (int i = 0; i < g.points.Count; i += partCount)
                    //    pointsToShow.Add(g.points[i]);
                    ChartValues<double> cv = new ChartValues<double>();
                    List<string> cx = new List<string>();
                    cv.AddRange(points.Select(p => p.Y));
                    cx.AddRange(points.Select(p => p.X.ToString()));

                    cartesianChart1.AxisX.Clear();
                    cartesianChart1.AxisX.Add(new Axis()
                    {
                        Title = gList.Name,
                        Labels = cx,
                    });
                    LineSeries ls;

                    ls = new LineSeries()
                    {
                        Title = i == 1 ? "Min" : (i == 0 ? "Max" : "Avg"),
                        Values = new ChartValues<double>(cv.Select(x => x)),
                    };
                    if (g.IsSelected)
                        ser1.Add(ls);
                    i++;
                }
            }
            cartesianChart1.Series = ser1;
        }

        private void panel_graph_MouseClick(object sender, MouseEventArgs e)
        {
            //var panel = sender as Panel;
            //panel.BackColor = panel.BackColor == b1 ? b0 : b1;
        }

        public void UpdateGraphList()
        {
            return;
            this.panel_listgraph.Controls.Clear();
            int top = 0;
            int i = 1;
            foreach (var g in gList.graphes)
            {
                Panel panel_graph_1 = new Panel();
                Label label_name_1 = new Label();
                Button button_delete_1 = new Button();
                CheckBox checkBox_show_1 = new CheckBox();
                // 
                // panel_graph_1
                // 
                panel_graph_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                panel_graph_1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                panel_graph_1.Controls.Add(label_name_1);
                panel_graph_1.Controls.Add(button_delete_1);
                panel_graph_1.Controls.Add(checkBox_show_1);
                panel_graph_1.Location = new System.Drawing.Point(3, 3 + top);
                panel_graph_1.Name = "panel_graph_" + i.ToString();
                panel_graph_1.Size = new System.Drawing.Size(508, 48);
                panel_graph_1.TabIndex = 3;
                panel_graph_1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_graph_MouseClick);
                // 
                // label_name_1
                // 
                label_name_1.AutoSize = true;
                label_name_1.Location = new System.Drawing.Point(9, 12);
                label_name_1.Name = "label_name_" + i.ToString();
                label_name_1.Size = new System.Drawing.Size(106, 17);
                label_name_1.TabIndex = 0;
                label_name_1.Text = g.Name;
                // 
                // button_delete_1
                // 
                button_delete_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                button_delete_1.Location = new System.Drawing.Point(426, 12);
                button_delete_1.Name = "button_delete_" + i.ToString();
                button_delete_1.Size = new System.Drawing.Size(75, 26);
                button_delete_1.TabIndex = 2;
                button_delete_1.Text = "Удалить";
                button_delete_1.UseVisualStyleBackColor = true;
                button_delete_1.Click += buttonDelete_Click;
                //
                // checkBox_show_1
                // 
                checkBox_show_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                checkBox_show_1.AutoSize = true;
                checkBox_show_1.Location = new System.Drawing.Point(328, 14);
                checkBox_show_1.Name = "checkBox_show_" + i.ToString();
                checkBox_show_1.Size = new System.Drawing.Size(92, 21);
                checkBox_show_1.TabIndex = 1;
                checkBox_show_1.Text = "Показать";
                checkBox_show_1.UseVisualStyleBackColor = true;
                checkBox_show_1.Checked = g.IsSelected;
                checkBox_show_1.Click += checkBoxIsSelected_Click;

                this.panel_listgraph.Controls.Add(panel_graph_1);

                i++;
                top += 50;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = GetIndex(btn.Name);
            gList.graphes.RemoveAt(index);
            UpdateGraphList();
        }

        private void checkBoxIsSelected_Click(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int index = GetIndex(cb.Name);
            gList.graphes[index].IsSelected = cb.Checked;
        }

        private int GetIndex(string name)
        {
            return int.Parse(name.Substring(name.LastIndexOf("_") + 1)) - 1;
        }

        private void добавитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PointGraph pg = new PointGraph(new List<GraphPoint>());
                pg.Name = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        var strs = str.Split('\t');
                        if (strs.Length >= 3)
                        {
                            try
                            {
                                double y = double.Parse(strs[2]);
                                string datefullstr = strs[1] + " " + strs[0];
                                DateTime x = DateTime.ParseExact(datefullstr, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                GraphPoint gp = new GraphPoint(x, y);
                                pg.points.Add(gp);
                            }
                            catch (Exception e1)
                            {
                                e1 = e1;
                            }
                        }
                    }
                }
                if (gList == null || gList.graphes.Count == 0)
                {
                    gList = new PointGraphList() { Name = "Группа графиков 1" };
                    pg.IsSelected = true;
                    pg.Name = "Max";
                    gList.graphes.Add(pg);
                }
                else
                {
                    var gr = gList.graphes[0].points;
                    //gr.AddRange(pg.points.Distinct(gr.Where())
                }
                //var pg1 = new PointGraph(pg.points) { Name = "Min", IsSelected = true };
                //gList.graphes.Add(pg1);
                //var pg2 = new PointGraph(pg.points) { Name = "Avg", IsSelected = true };
                //gList.graphes.Add(pg2);
                FillDefInterval();
                UpdateGraphList();
                PrintGraph();
            }
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            if (intervalType == 3)
            {
                var legend = chartPoint.ChartView.Model.AxisX[0].Labels[(int)chartPoint.X];
                var dateValue = DateTime.Parse(legend);
                this.intervalType = 2;
                this.dateStart = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 0, 0, 0);
                this.dateEnd = this.dateStart.AddDays(1);
                PrintGraph();
            }
            else if (intervalType == 2)
            {
                var legend = chartPoint.ChartView.Model.AxisX[0].Labels[(int)chartPoint.X];
                var dateValue = DateTime.Parse(legend);
                this.intervalType = 1;
                this.dateStart = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, dateValue.Hour, 0, 0);
                this.dateEnd = this.dateStart.AddHours(1);
                PrintGraph();
            }
            else if (intervalType == 1)
            {
                var legend = chartPoint.ChartView.Model.AxisX[0].Labels[(int)chartPoint.X];
                var dateValue = DateTime.Parse(legend);
                this.intervalType = 0;
                this.dateStart = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, dateValue.Hour, dateValue.Minute, 0);
                this.dateEnd = this.dateStart.AddMinutes(1);
                PrintGraph();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (intervalType == 2)
            {
                FillDefInterval();
                PrintGraph();
            }
            else if (intervalType == 1)
            {
                this.dateStart = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, 0, 0, 0);
                this.dateEnd = this.dateStart.AddDays(1);
                this.intervalType = 2;
                PrintGraph();
            }
            else if (intervalType == 0)
            {
                this.dateStart = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, dateStart.Hour, 0, 0);
                this.dateEnd = this.dateStart.AddHours(1);
                this.intervalType = 1;
                PrintGraph();
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.dateStart = IncreaseInterval(this.dateStart, this.intervalType, -10);
            this.dateEnd = IncreaseInterval(this.dateEnd, this.intervalType, -10);
            PrintGraph();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            this.dateStart = IncreaseInterval(this.dateStart, this.intervalType, 10);
            this.dateEnd = IncreaseInterval(this.dateEnd, this.intervalType, 10);
            PrintGraph();
        }

        private void сохранитьВБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void Clear()
        {
            if (gList.graphes.Count == 0 || gList.graphes[0].points.Count == 0)
                return;
            db.ClearGraphList(graphListId);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
