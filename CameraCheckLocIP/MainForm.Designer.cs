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
            this.l_IPfrom = new System.Windows.Forms.Label();
            this.l_IPto = new System.Windows.Forms.Label();
            this.tB_IPFrom = new System.Windows.Forms.TextBox();
            this.tB_IPTo = new System.Windows.Forms.TextBox();
            this.l_port = new System.Windows.Forms.Label();
            this.lB_port = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_plus = new System.Windows.Forms.Button();
            this.b_minus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // l_IPfrom
            // 
            this.l_IPfrom.AutoSize = true;
            this.l_IPfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_IPfrom.Location = new System.Drawing.Point(21, 32);
            this.l_IPfrom.Name = "l_IPfrom";
            this.l_IPfrom.Size = new System.Drawing.Size(49, 20);
            this.l_IPfrom.TabIndex = 0;
            this.l_IPfrom.Text = "IP От";
            // 
            // l_IPto
            // 
            this.l_IPto.AutoSize = true;
            this.l_IPto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_IPto.Location = new System.Drawing.Point(21, 90);
            this.l_IPto.Name = "l_IPto";
            this.l_IPto.Size = new System.Drawing.Size(49, 20);
            this.l_IPto.TabIndex = 0;
            this.l_IPto.Text = "IP До";
            // 
            // tB_IPFrom
            // 
            this.tB_IPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_IPFrom.Location = new System.Drawing.Point(72, 32);
            this.tB_IPFrom.Name = "tB_IPFrom";
            this.tB_IPFrom.Size = new System.Drawing.Size(130, 26);
            this.tB_IPFrom.TabIndex = 1;
            this.tB_IPFrom.Text = "192.168.0.0";
            this.tB_IPFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPFrom_KeyPress);
            // 
            // tB_IPTo
            // 
            this.tB_IPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_IPTo.Location = new System.Drawing.Point(72, 90);
            this.tB_IPTo.Name = "tB_IPTo";
            this.tB_IPTo.Size = new System.Drawing.Size(130, 26);
            this.tB_IPTo.TabIndex = 1;
            this.tB_IPTo.Text = "192.168.255.255";
            this.tB_IPTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPTo_KeyPress);
            // 
            // l_port
            // 
            this.l_port.AutoSize = true;
            this.l_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_port.Location = new System.Drawing.Point(247, 9);
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
            "8080"});
            this.lB_port.Location = new System.Drawing.Point(251, 32);
            this.lB_port.Name = "lB_port";
            this.lB_port.Size = new System.Drawing.Size(120, 84);
            this.lB_port.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(12, 503);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1008, 116);
            this.textBox3.TabIndex = 5;
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
            this.b_plus.Location = new System.Drawing.Point(298, 5);
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
            this.b_minus.Location = new System.Drawing.Point(327, 5);
            this.b_minus.Name = "b_minus";
            this.b_minus.Size = new System.Drawing.Size(24, 27);
            this.b_minus.TabIndex = 8;
            this.b_minus.Text = "-";
            this.b_minus.UseVisualStyleBackColor = true;
            this.b_minus.Click += new System.EventHandler(this.b_minus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 87);
            this.button1.TabIndex = 9;
            this.button1.Text = "начать сканирование";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 144);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1008, 333);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 631);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_minus);
            this.Controls.Add(this.b_plus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lB_port);
            this.Controls.Add(this.l_port);
            this.Controls.Add(this.tB_IPTo);
            this.Controls.Add(this.tB_IPFrom);
            this.Controls.Add(this.l_IPto);
            this.Controls.Add(this.l_IPfrom);
            this.Name = "MainForm";
            this.Text = "CameraCheckLocIP ";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_plus;
        private System.Windows.Forms.Button b_minus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

