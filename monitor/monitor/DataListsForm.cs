using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monitor.datamodel;

namespace monitor
{
    public partial class DataListsForm : Form
    {
        MonitoringContext db;
        public DataListsForm()
        {
            InitializeComponent();
            db = new MonitoringContext();
            db.GraphList.Load();
            ReloadList();
        }

        private void ReloadList()
        {
            dataGridView1.DataSource = db.GraphList.Local.Select(x => new { Номер = x.Id, Название = x.Name }).ToList();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 230;
        }

        private void saveListbtn_Click(object sender, EventArgs e)
        {
            AddGraphList ad = new AddGraphList();
            var r = ad.ShowDialog();
            if (r == DialogResult.OK)
            {
                db.GraphList.Add(new GraphList() { Name = ad.textBox1.Text });
                db.SaveChanges();
                ReloadList();
            }
        }

        public long GetSelectedId()
        {
            long uns = 0;
            if (dataGridView1.SelectedCells.Count > 0)
                uns = (long)dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value;
            return uns;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long id = GetSelectedId();
            if (id > 0)
            {
                db.GraphList.Remove(db.GraphList.Where(x => x.Id == id).FirstOrDefault());
                db.SaveChanges();
                ReloadList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long id = GetSelectedId();
            if (id > 0)
            {
                Form1 form = new Form1();
                form.ShowDialog();
            }
        }
    }
}
