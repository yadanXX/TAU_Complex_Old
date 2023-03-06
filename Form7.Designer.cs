namespace TAU_Complex
{
    partial class Form7
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxtk = new System.Windows.Forms.TextBox();
            this.textBoxT1 = new System.Windows.Forms.TextBox();
            this.textBoxk2 = new System.Windows.Forms.TextBox();
            this.textBoxk1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonISOL = new System.Windows.Forms.RadioButton();
            this.radioButtonNSFB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIFB = new System.Windows.Forms.RadioButton();
            this.radioButtonHFB = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTB = new System.Windows.Forms.Panel();
            this.textBoxT2 = new System.Windows.Forms.TextBox();
            this.textBoxTnu = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTB);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 480);
            this.panel1.TabIndex = 0;
            // 
            // textBoxtk
            // 
            this.textBoxtk.Location = new System.Drawing.Point(15, 77);
            this.textBoxtk.Name = "textBoxtk";
            this.textBoxtk.Size = new System.Drawing.Size(72, 26);
            this.textBoxtk.TabIndex = 10;
            // 
            // textBoxT1
            // 
            this.textBoxT1.Location = new System.Drawing.Point(121, 13);
            this.textBoxT1.Name = "textBoxT1";
            this.textBoxT1.Size = new System.Drawing.Size(72, 26);
            this.textBoxT1.TabIndex = 9;
            // 
            // textBoxk2
            // 
            this.textBoxk2.Location = new System.Drawing.Point(15, 45);
            this.textBoxk2.Name = "textBoxk2";
            this.textBoxk2.Size = new System.Drawing.Size(72, 26);
            this.textBoxk2.TabIndex = 8;
            // 
            // textBoxk1
            // 
            this.textBoxk1.Location = new System.Drawing.Point(15, 13);
            this.textBoxk1.Name = "textBoxk1";
            this.textBoxk1.Size = new System.Drawing.Size(72, 26);
            this.textBoxk1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonISOL);
            this.groupBox3.Controls.Add(this.radioButtonNSFB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 118);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Способ регулирования";
            // 
            // radioButtonISOL
            // 
            this.radioButtonISOL.AutoSize = true;
            this.radioButtonISOL.Location = new System.Drawing.Point(25, 66);
            this.radioButtonISOL.Name = "radioButtonISOL";
            this.radioButtonISOL.Size = new System.Drawing.Size(236, 23);
            this.radioButtonISOL.TabIndex = 2;
            this.radioButtonISOL.TabStop = true;
            this.radioButtonISOL.Text = "Введение изодромных звеньев";
            this.radioButtonISOL.UseVisualStyleBackColor = true;
            this.radioButtonISOL.CheckedChanged += new System.EventHandler(this.radioButtonNSFB_CheckedChanged);
            // 
            // radioButtonNSFB
            // 
            this.radioButtonNSFB.AutoSize = true;
            this.radioButtonNSFB.Checked = true;
            this.radioButtonNSFB.Location = new System.Drawing.Point(25, 37);
            this.radioButtonNSFB.Name = "radioButtonNSFB";
            this.radioButtonNSFB.Size = new System.Drawing.Size(222, 23);
            this.radioButtonNSFB.TabIndex = 1;
            this.radioButtonNSFB.TabStop = true;
            this.radioButtonNSFB.Text = "Неединичная обратная связь";
            this.radioButtonNSFB.UseVisualStyleBackColor = true;
            this.radioButtonNSFB.CheckedChanged += new System.EventHandler(this.radioButtonNSFB_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обьект регулирования";
            this.groupBox2.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(249, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(106, 23);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(137, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 23);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 23);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonIFB);
            this.groupBox1.Controls.Add(this.radioButtonHFB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид Обратной связи";
            // 
            // radioButtonIFB
            // 
            this.radioButtonIFB.AutoSize = true;
            this.radioButtonIFB.Location = new System.Drawing.Point(12, 54);
            this.radioButtonIFB.Name = "radioButtonIFB";
            this.radioButtonIFB.Size = new System.Drawing.Size(324, 23);
            this.radioButtonIFB.TabIndex = 1;
            this.radioButtonIFB.TabStop = true;
            this.radioButtonIFB.Text = "Инерционнаяя неединичная обратная связь";
            this.radioButtonIFB.UseVisualStyleBackColor = true;
            this.radioButtonIFB.CheckedChanged += new System.EventHandler(this.radioButtonHFB_CheckedChanged);
            // 
            // radioButtonHFB
            // 
            this.radioButtonHFB.AutoSize = true;
            this.radioButtonHFB.Checked = true;
            this.radioButtonHFB.Location = new System.Drawing.Point(12, 25);
            this.radioButtonHFB.Name = "radioButtonHFB";
            this.radioButtonHFB.Size = new System.Drawing.Size(277, 23);
            this.radioButtonHFB.TabIndex = 0;
            this.radioButtonHFB.TabStop = true;
            this.radioButtonHFB.Text = "Жесткая неединичкая обратная связь";
            this.radioButtonHFB.UseVisualStyleBackColor = true;
            this.radioButtonHFB.CheckedChanged += new System.EventHandler(this.radioButtonHFB_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 436);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(434, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(434, 170);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(599, 480);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1033, 170);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panelTB
            // 
            this.panelTB.Controls.Add(this.textBoxTnu);
            this.panelTB.Controls.Add(this.textBoxtk);
            this.panelTB.Controls.Add(this.textBoxT2);
            this.panelTB.Controls.Add(this.textBoxk1);
            this.panelTB.Controls.Add(this.textBoxk2);
            this.panelTB.Controls.Add(this.textBoxT1);
            this.panelTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTB.Location = new System.Drawing.Point(0, 318);
            this.panelTB.Name = "panelTB";
            this.panelTB.Size = new System.Drawing.Size(434, 118);
            this.panelTB.TabIndex = 11;
            // 
            // textBoxT2
            // 
            this.textBoxT2.Location = new System.Drawing.Point(121, 45);
            this.textBoxT2.Name = "textBoxT2";
            this.textBoxT2.Size = new System.Drawing.Size(72, 26);
            this.textBoxT2.TabIndex = 10;
            this.textBoxT2.Visible = false;
            // 
            // textBoxTnu
            // 
            this.textBoxTnu.Location = new System.Drawing.Point(217, 13);
            this.textBoxTnu.Name = "textBoxTnu";
            this.textBoxTnu.Size = new System.Drawing.Size(72, 26);
            this.textBoxTnu.TabIndex = 11;
            this.textBoxTnu.Visible = false;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1033, 650);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form7";
            this.Text = "Form7";
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTB.ResumeLayout(false);
            this.panelTB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxk1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxtk;
        private System.Windows.Forms.TextBox textBoxT1;
        private System.Windows.Forms.TextBox textBoxk2;
        private System.Windows.Forms.RadioButton radioButtonISOL;
        private System.Windows.Forms.RadioButton radioButtonNSFB;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonIFB;
        private System.Windows.Forms.RadioButton radioButtonHFB;
        private System.Windows.Forms.Panel panelTB;
        private System.Windows.Forms.TextBox textBoxTnu;
        private System.Windows.Forms.TextBox textBoxT2;
    }
}