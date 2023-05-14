using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using monitor.datamodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core.Parser;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitor3
{
    public partial class LoaderForm : Form
    {
        public PointGraph pg;

        public LoaderForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                textBox2.Enabled = true;
            else
                textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
                textBox1.Text = openFileDialog1.FileName;
                button2.Enabled = true;
            }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            pg = new PointGraph(new List<GraphPoint>());
            pg.Name = textBox1.Text;
            using (StreamReader sr = new StreamReader(textBox1.Text))
            {
                Func<string[], double> f = null;
                var options = ScriptOptions.Default
                .AddImports("System", "System.IO", "System.Collections.Generic",
                    "System.Console", "System.Diagnostics", "System.Dynamic",
                    "System.Linq", "System.Text",
                    "System.Threading.Tasks")
                .AddReferences("System", "System.Core", "Microsoft.CSharp");
                var discountFilter = checkBox1.Checked ? textBox2.Text : "(strs) => double.Parse(strs[2])";
                f = await CSharpScript.EvaluateAsync<Func<string[], double>>(discountFilter, options);
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    var strs = str.Split('\t');
                    if (strs.Length >= 3)
                    {
                        try
                        {
                            double y = f(strs);
                            string datefullstr = strs[1] + " " + strs[0];
                            DateTime x = DateTime.ParseExact(datefullstr, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            GraphPoint gp = new GraphPoint(x, y);
                            pg.points.Add(gp);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}
