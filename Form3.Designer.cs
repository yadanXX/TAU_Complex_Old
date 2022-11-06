namespace TAU_Complex
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxNu = new System.Windows.Forms.ComboBox();
            this.textBoxK2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.textBoxtk = new System.Windows.Forms.TextBox();
            this.textBoxT1 = new System.Windows.Forms.TextBox();
            this.textBoxK1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.textBoxT2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 97);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.textBoxT2);
            this.panel2.Controls.Add(this.comboBoxNu);
            this.panel2.Controls.Add(this.textBoxK2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBoxW);
            this.panel2.Controls.Add(this.textBoxtk);
            this.panel2.Controls.Add(this.textBoxT1);
            this.panel2.Controls.Add(this.textBoxK1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 529);
            this.panel2.TabIndex = 1;
            // 
            // comboBoxNu
            // 
            this.comboBoxNu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNu.FormattingEnabled = true;
            this.comboBoxNu.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBoxNu.Location = new System.Drawing.Point(50, 193);
            this.comboBoxNu.MaxDropDownItems = 2;
            this.comboBoxNu.Name = "comboBoxNu";
            this.comboBoxNu.Size = new System.Drawing.Size(100, 21);
            this.comboBoxNu.TabIndex = 14;
            // 
            // textBoxK2
            // 
            this.textBoxK2.Location = new System.Drawing.Point(104, 24);
            this.textBoxK2.Name = "textBoxK2";
            this.textBoxK2.Size = new System.Drawing.Size(46, 20);
            this.textBoxK2.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxW
            // 
            this.textBoxW.Location = new System.Drawing.Point(50, 144);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(100, 20);
            this.textBoxW.TabIndex = 11;
            // 
            // textBoxtk
            // 
            this.textBoxtk.Location = new System.Drawing.Point(50, 102);
            this.textBoxtk.Name = "textBoxtk";
            this.textBoxtk.Size = new System.Drawing.Size(100, 20);
            this.textBoxtk.TabIndex = 10;
            // 
            // textBoxT1
            // 
            this.textBoxT1.Location = new System.Drawing.Point(50, 63);
            this.textBoxT1.Name = "textBoxT1";
            this.textBoxT1.Size = new System.Drawing.Size(46, 20);
            this.textBoxT1.TabIndex = 9;
            // 
            // textBoxK1
            // 
            this.textBoxK1.Location = new System.Drawing.Point(50, 24);
            this.textBoxK1.Name = "textBoxK1";
            this.textBoxK1.Size = new System.Drawing.Size(46, 20);
            this.textBoxK1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TAU_Complex.Properties.Resources.ScreenShot_20221010144753;
            this.pictureBox2.Location = new System.Drawing.Point(6, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 140);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.zedGraphControl2);
            this.panel3.Controls.Add(this.zedGraphControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(166, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(834, 529);
            this.panel3.TabIndex = 2;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 265);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(834, 265);
            this.zedGraphControl2.TabIndex = 7;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(834, 265);
            this.zedGraphControl1.TabIndex = 6;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // textBoxT2
            // 
            this.textBoxT2.Location = new System.Drawing.Point(104, 63);
            this.textBoxT2.Name = "textBoxT2";
            this.textBoxT2.Size = new System.Drawing.Size(46, 20);
            this.textBoxT2.TabIndex = 15;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Resize += new System.EventHandler(this.Form3_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.TextBox textBoxtk;
        private System.Windows.Forms.TextBox textBoxT1;
        private System.Windows.Forms.TextBox textBoxK1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TextBox textBoxK2;
        private System.Windows.Forms.ComboBox comboBoxNu;
        private System.Windows.Forms.TextBox textBoxT2;
    }
}