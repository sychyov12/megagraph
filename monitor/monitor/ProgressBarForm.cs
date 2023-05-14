using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitor
{
    public partial class ProgressBarForm : Form
    {
        Action action;
        public ProgressBarForm(Action action)
        {
            InitializeComponent();
            this.action = action;
        }

        public void MakeAction()
        {
            action.Invoke();
        }

        public void SendProgress(double progress)
        {
            this.progressBar1.Value = (int)progress;
        }

        private void ProgressBarForm_Shown(object sender, EventArgs e)
        {
            MakeAction();
            this.Close();
        }
    }
}
