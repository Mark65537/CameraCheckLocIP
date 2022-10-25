namespace CameraCheckLocIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.l_IPfrom = new System.Windows.Forms.Label();
            this.l_IPto = new System.Windows.Forms.Label();
            this.tB_IPFrom = new System.Windows.Forms.TextBox();
            this.tB_IPTo = new System.Windows.Forms.TextBox();
            this.l_port = new System.Windows.Forms.Label();
            this.lB_port = new System.Windows.Forms.ListBox();
            this.tB_output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_plus = new System.Windows.Forms.Button();
            this.b_minus = new System.Windows.Forms.Button();
            this.b_startScan = new System.Windows.Forms.Button();
            this.lV_output = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.l_timeout = new System.Windows.Forms.Label();
            this.nUD_timeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.l_totalTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // l_IPfrom
            // 
            this.l_IPfrom.AutoSize = true;
            this.l_IPfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_IPfrom.Location = new System.Drawing.Point(129, 33);
            this.l_IPfrom.Name = "l_IPfrom";
            this.l_IPfrom.Size = new System.Drawing.Size(49, 20);
            this.l_IPfrom.TabIndex = 0;
            this.l_IPfrom.Text = "IP От";
            // 
            // l_IPto
            // 
            this.l_IPto.AutoSize = true;
            this.l_IPto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_IPto.Location = new System.Drawing.Point(129, 91);
            this.l_IPto.Name = "l_IPto";
            this.l_IPto.Size = new System.Drawing.Size(49, 20);
            this.l_IPto.TabIndex = 0;
            this.l_IPto.Text = "IP До";
            // 
            // tB_IPFrom
            // 
            this.tB_IPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_IPFrom.Location = new System.Drawing.Point(180, 33);
            this.tB_IPFrom.Name = "tB_IPFrom";
            this.tB_IPFrom.Size = new System.Drawing.Size(130, 26);
            this.tB_IPFrom.TabIndex = 1;
            this.tB_IPFrom.Text = "1.0.0.1";
            this.tB_IPFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPFrom_KeyPress);
            // 
            // tB_IPTo
            // 
            this.tB_IPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_IPTo.Location = new System.Drawing.Point(180, 91);
            this.tB_IPTo.Name = "tB_IPTo";
            this.tB_IPTo.Size = new System.Drawing.Size(130, 26);
            this.tB_IPTo.TabIndex = 1;
            this.tB_IPTo.Text = "1.0.0.36";
            this.tB_IPTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPTo_KeyPress);
            // 
            // l_port
            // 
            this.l_port.AutoSize = true;
            this.l_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_port.Location = new System.Drawing.Point(355, 10);
            this.l_port.Name = "l_port";
            this.l_port.Size = new System.Drawing.Size(48, 20);
            this.l_port.TabIndex = 2;
            this.l_port.Text = "Порт";
            // 
            // lB_port
            // 
            this.lB_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lB_port.FormattingEnabled = true;
            this.lB_port.ItemHeight = 20;
            this.lB_port.Items.AddRange(new object[] {
            "80"});
            this.lB_port.Location = new System.Drawing.Point(359, 33);
            this.lB_port.Name = "lB_port";
            this.lB_port.Size = new System.Drawing.Size(120, 84);
            this.lB_port.TabIndex = 4;
            // 
            // tB_output
            // 
            this.tB_output.BackColor = System.Drawing.Color.White;
            this.tB_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_output.ForeColor = System.Drawing.Color.Red;
            this.tB_output.Location = new System.Drawing.Point(12, 503);
            this.tB_output.Multiline = true;
            this.tB_output.Name = "tB_output";
            this.tB_output.ReadOnly = true;
            this.tB_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_output.Size = new System.Drawing.Size(1008, 116);
            this.tB_output.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Вывод:";
            // 
            // b_plus
            // 
            this.b_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_plus.Location = new System.Drawing.Point(406, 6);
            this.b_plus.Name = "b_plus";
            this.b_plus.Size = new System.Drawing.Size(23, 27);
            this.b_plus.TabIndex = 7;
            this.b_plus.Text = "+";
            this.b_plus.UseVisualStyleBackColor = true;
            this.b_plus.Click += new System.EventHandler(this.b_plus_Click);
            // 
            // b_minus
            // 
            this.b_minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_minus.Location = new System.Drawing.Point(435, 6);
            this.b_minus.Name = "b_minus";
            this.b_minus.Size = new System.Drawing.Size(24, 27);
            this.b_minus.TabIndex = 8;
            this.b_minus.Text = "-";
            this.b_minus.UseVisualStyleBackColor = true;
            this.b_minus.Click += new System.EventHandler(this.b_minus_Click);
            // 
            // b_startScan
            // 
            this.b_startScan.Location = new System.Drawing.Point(16, 33);
            this.b_startScan.Name = "b_startScan";
            this.b_startScan.Size = new System.Drawing.Size(96, 87);
            this.b_startScan.TabIndex = 9;
            this.b_startScan.Text = "начать сканирование";
            this.b_startScan.UseVisualStyleBackColor = true;
            this.b_startScan.Click += new System.EventHandler(this.b_startScan_Click);
            // 
            // lV_output
            // 
            this.lV_output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lV_output.FullRowSelect = true;
            this.lV_output.GridLines = true;
            this.lV_output.HideSelection = false;
            this.lV_output.Location = new System.Drawing.Point(12, 144);
            this.lV_output.Name = "lV_output";
            this.lV_output.Size = new System.Drawing.Size(1008, 333);
            this.lV_output.TabIndex = 10;
            this.lV_output.UseCompatibleStateImageBehavior = false;
            this.lV_output.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Адрес";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Порт";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Статус";
            // 
            // l_timeout
            // 
            this.l_timeout.AutoSize = true;
            this.l_timeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_timeout.Location = new System.Drawing.Point(509, 8);
            this.l_timeout.Name = "l_timeout";
            this.l_timeout.Size = new System.Drawing.Size(105, 20);
            this.l_timeout.TabIndex = 11;
            this.l_timeout.Text = "Таймаут (мс)";
            // 
            // nUD_timeout
            // 
            this.nUD_timeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nUD_timeout.Location = new System.Drawing.Point(512, 31);
            this.nUD_timeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nUD_timeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUD_timeout.Name = "nUD_timeout";
            this.nUD_timeout.Size = new System.Drawing.Size(120, 26);
            this.nUD_timeout.TabIndex = 12;
            this.nUD_timeout.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(763, 677);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Общее время:";
            // 
            // l_totalTime
            // 
            this.l_totalTime.AutoSize = true;
            this.l_totalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_totalTime.Location = new System.Drawing.Point(876, 678);
            this.l_totalTime.Name = "l_totalTime";
            this.l_totalTime.Size = new System.Drawing.Size(84, 20);
            this.l_totalTime.TabIndex = 14;
            this.l_totalTime.Text = "0:00:00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 707);
            this.Controls.Add(this.l_totalTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nUD_timeout);
            this.Controls.Add(this.l_timeout);
            this.Controls.Add(this.lV_output);
            this.Controls.Add(this.b_startScan);
            this.Controls.Add(this.b_minus);
            this.Controls.Add(this.b_plus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_output);
            this.Controls.Add(this.lB_port);
            this.Controls.Add(this.l_port);
            this.Controls.Add(this.tB_IPTo);
            this.Controls.Add(this.tB_IPFrom);
            this.Controls.Add(this.l_IPto);
            this.Controls.Add(this.l_IPfrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CameraCheckLocIP ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_timeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_IPfrom;
        private System.Windows.Forms.Label l_IPto;
        private System.Windows.Forms.TextBox tB_IPFrom;
        private System.Windows.Forms.TextBox tB_IPTo;
        private System.Windows.Forms.Label l_port;
        private System.Windows.Forms.ListBox lB_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_plus;
        private System.Windows.Forms.Button b_minus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label l_timeout;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lV_output;
        public System.Windows.Forms.Button b_startScan;
        public System.Windows.Forms.Label l_totalTime;
        public System.Windows.Forms.TextBox tB_output;
        private System.Windows.Forms.NumericUpDown nUD_timeout;
    }
}

