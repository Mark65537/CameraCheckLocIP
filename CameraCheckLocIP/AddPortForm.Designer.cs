namespace CameraCheckLocIP
{
    partial class AddPortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.l_fromTo = new System.Windows.Forms.Label();
            this.tB_port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_ok.Location = new System.Drawing.Point(63, 96);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(73, 28);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_cancel.Location = new System.Drawing.Point(155, 96);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(78, 28);
            this.b_cancel.TabIndex = 1;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // l_fromTo
            // 
            this.l_fromTo.AutoSize = true;
            this.l_fromTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_fromTo.Location = new System.Drawing.Point(13, 13);
            this.l_fromTo.Name = "l_fromTo";
            this.l_fromTo.Size = new System.Drawing.Size(123, 20);
            this.l_fromTo.TabIndex = 2;
            this.l_fromTo.Text = "(от 0 до 65535)";
            // 
            // tB_port
            // 
            this.tB_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_port.Location = new System.Drawing.Point(13, 40);
            this.tB_port.Name = "tB_port";
            this.tB_port.Size = new System.Drawing.Size(278, 26);
            this.tB_port.TabIndex = 3;
            // 
            // AddPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 133);
            this.Controls.Add(this.tB_port);
            this.Controls.Add(this.l_fromTo);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPortForm";
            this.ShowIcon = false;
            this.Text = "Введите номер порта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label l_fromTo;
        private System.Windows.Forms.TextBox tB_port;
    }
}