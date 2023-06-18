namespace monitor3
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnc = new System.Windows.Forms.Button();
            this.btnMMM = new System.Windows.Forms.Button();
            this.btnPPP = new System.Windows.Forms.Button();
            this.btnMM = new System.Windows.Forms.Button();
            this.btnPP = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnSetSettings = new System.Windows.Forms.Button();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.pColorSample = new System.Windows.Forms.Panel();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dateF = new System.Windows.Forms.DateTimePicker();
            this.dateT = new System.Windows.Forms.DateTimePicker();
            this.yF = new System.Windows.Forms.TextBox();
            this.yT = new System.Windows.Forms.TextBox();
            this.timeF = new System.Windows.Forms.DateTimePicker();
            this.timeT = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 27);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(840, 308);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьИзФайлаToolStripMenuItem,
            this.обновитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьИзФайлаToolStripMenuItem
            // 
            this.добавитьИзФайлаToolStripMenuItem.Name = "добавитьИзФайлаToolStripMenuItem";
            this.добавитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.добавитьИзФайлаToolStripMenuItem.Text = "Добавить из файла";
            this.добавитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.добавитьИзФайлаToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.timeT);
            this.panel1.Controls.Add(this.timeF);
            this.panel1.Controls.Add(this.yT);
            this.panel1.Controls.Add(this.yF);
            this.panel1.Controls.Add(this.dateT);
            this.panel1.Controls.Add(this.dateF);
            this.panel1.Controls.Add(this.btnc);
            this.panel1.Controls.Add(this.btnMMM);
            this.panel1.Controls.Add(this.btnPPP);
            this.panel1.Controls.Add(this.btnMM);
            this.panel1.Controls.Add(this.btnPP);
            this.panel1.Controls.Add(this.btnMinus);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Controls.Add(this.btnSetSettings);
            this.panel1.Controls.Add(this.nudScale);
            this.panel1.Controls.Add(this.pColorSample);
            this.panel1.Controls.Add(this.btnChangeColor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(251, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 136);
            this.panel1.TabIndex = 2;
            // 
            // btnc
            // 
            this.btnc.Location = new System.Drawing.Point(518, 3);
            this.btnc.Name = "btnc";
            this.btnc.Size = new System.Drawing.Size(34, 41);
            this.btnc.TabIndex = 12;
            this.btnc.Text = "c";
            this.btnc.UseVisualStyleBackColor = true;
            this.btnc.Click += new System.EventHandler(this.btnc_Click);
            // 
            // btnMMM
            // 
            this.btnMMM.Location = new System.Drawing.Point(458, 3);
            this.btnMMM.Name = "btnMMM";
            this.btnMMM.Size = new System.Drawing.Size(57, 41);
            this.btnMMM.TabIndex = 11;
            this.btnMMM.Text = "---";
            this.btnMMM.UseVisualStyleBackColor = true;
            this.btnMMM.Click += new System.EventHandler(this.btnMMM_Click);
            // 
            // btnPPP
            // 
            this.btnPPP.Location = new System.Drawing.Point(223, 3);
            this.btnPPP.Name = "btnPPP";
            this.btnPPP.Size = new System.Drawing.Size(51, 41);
            this.btnPPP.TabIndex = 10;
            this.btnPPP.Text = "+++";
            this.btnPPP.UseVisualStyleBackColor = true;
            this.btnPPP.Click += new System.EventHandler(this.btnPPP_Click);
            // 
            // btnMM
            // 
            this.btnMM.Location = new System.Drawing.Point(408, 3);
            this.btnMM.Name = "btnMM";
            this.btnMM.Size = new System.Drawing.Size(44, 41);
            this.btnMM.TabIndex = 9;
            this.btnMM.Text = "--";
            this.btnMM.UseVisualStyleBackColor = true;
            this.btnMM.Click += new System.EventHandler(this.btnMM_Click);
            // 
            // btnPP
            // 
            this.btnPP.Location = new System.Drawing.Point(280, 3);
            this.btnPP.Name = "btnPP";
            this.btnPP.Size = new System.Drawing.Size(42, 41);
            this.btnPP.TabIndex = 8;
            this.btnPP.Text = "++";
            this.btnPP.UseVisualStyleBackColor = true;
            this.btnPP.Click += new System.EventHandler(this.btnPP_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(368, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(34, 41);
            this.btnMinus.TabIndex = 7;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(328, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(34, 41);
            this.btnPlus.TabIndex = 6;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnSetSettings
            // 
            this.btnSetSettings.Location = new System.Drawing.Point(6, 107);
            this.btnSetSettings.Name = "btnSetSettings";
            this.btnSetSettings.Size = new System.Drawing.Size(129, 23);
            this.btnSetSettings.TabIndex = 5;
            this.btnSetSettings.Text = "Применить";
            this.btnSetSettings.UseVisualStyleBackColor = true;
            this.btnSetSettings.Click += new System.EventHandler(this.btnSetSettings_Click);
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 6;
            this.nudScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScale.Location = new System.Drawing.Point(6, 79);
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(120, 22);
            this.nudScale.TabIndex = 4;
            this.nudScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pColorSample
            // 
            this.pColorSample.BackColor = System.Drawing.Color.Navy;
            this.pColorSample.Location = new System.Drawing.Point(51, 5);
            this.pColorSample.Name = "pColorSample";
            this.pColorSample.Size = new System.Drawing.Size(81, 23);
            this.pColorSample.TabIndex = 3;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(6, 34);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(137, 23);
            this.btnChangeColor.TabIndex = 2;
            this.btnChangeColor.Text = "Выбрать цвет";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Масштаб:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(0, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 136);
            this.panel2.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 116);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dateF
            // 
            this.dateF.Location = new System.Drawing.Point(218, 50);
            this.dateF.Name = "dateF";
            this.dateF.Size = new System.Drawing.Size(144, 22);
            this.dateF.TabIndex = 13;
            // 
            // dateT
            // 
            this.dateT.Location = new System.Drawing.Point(412, 50);
            this.dateT.Name = "dateT";
            this.dateT.Size = new System.Drawing.Size(144, 22);
            this.dateT.TabIndex = 14;
            // 
            // yF
            // 
            this.yF.Location = new System.Drawing.Point(218, 105);
            this.yF.Name = "yF";
            this.yF.Size = new System.Drawing.Size(144, 22);
            this.yF.TabIndex = 15;
            // 
            // yT
            // 
            this.yT.Location = new System.Drawing.Point(412, 106);
            this.yT.Name = "yT";
            this.yT.Size = new System.Drawing.Size(144, 22);
            this.yT.TabIndex = 16;
            // 
            // timeF
            // 
            this.timeF.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeF.Location = new System.Drawing.Point(218, 78);
            this.timeF.Name = "timeF";
            this.timeF.Size = new System.Drawing.Size(144, 22);
            this.timeF.TabIndex = 17;
            // 
            // timeT
            // 
            this.timeT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeT.Location = new System.Drawing.Point(412, 76);
            this.timeT.Name = "timeT";
            this.timeT.Size = new System.Drawing.Size(144, 22);
            this.timeT.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "X с:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "X по:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Y с:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Y по:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Просмотр графиков";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Panel pColorSample;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem добавитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSetSettings;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMMM;
        private System.Windows.Forms.Button btnPPP;
        private System.Windows.Forms.Button btnMM;
        private System.Windows.Forms.Button btnPP;
        private System.Windows.Forms.Button btnc;
        private System.Windows.Forms.TextBox yT;
        private System.Windows.Forms.TextBox yF;
        private System.Windows.Forms.DateTimePicker dateT;
        private System.Windows.Forms.DateTimePicker dateF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timeT;
        private System.Windows.Forms.DateTimePicker timeF;
    }
}

