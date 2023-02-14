namespace TAU_Complex
{
    partial class Form5
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonStep = new System.Windows.Forms.RadioButton();
            this.radioButtonRamp = new System.Windows.Forms.RadioButton();
            this.radioButtonAmp = new System.Windows.Forms.RadioButton();
            this.radioButtonDif = new System.Windows.Forms.RadioButton();
            this.radioButtonExo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.textBoxtk = new System.Windows.Forms.TextBox();
            this.textBoxTky = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxRamp = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelKramp = new System.Windows.Forms.Label();
            this.pictureBoxTky = new System.Windows.Forms.PictureBox();
            this.pictureBoxtk = new System.Windows.Forms.PictureBox();
            this.pictureBoxT = new System.Windows.Forms.PictureBox();
            this.pictureBoxK = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(427, 381);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 271);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(427, 386);
            this.zedGraphControl2.TabIndex = 1;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraphControl1);
            this.panel1.Controls.Add(this.zedGraphControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(402, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 657);
            this.panel1.TabIndex = 2;
            // 
            // radioButtonStep
            // 
            this.radioButtonStep.AutoSize = true;
            this.radioButtonStep.Location = new System.Drawing.Point(15, 25);
            this.radioButtonStep.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonStep.Name = "radioButtonStep";
            this.radioButtonStep.Size = new System.Drawing.Size(146, 26);
            this.radioButtonStep.TabIndex = 3;
            this.radioButtonStep.TabStop = true;
            this.radioButtonStep.Text = "Ступеньчатое";
            this.radioButtonStep.UseVisualStyleBackColor = true;
            // 
            // radioButtonRamp
            // 
            this.radioButtonRamp.AutoSize = true;
            this.radioButtonRamp.Location = new System.Drawing.Point(15, 55);
            this.radioButtonRamp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonRamp.Name = "radioButtonRamp";
            this.radioButtonRamp.Size = new System.Drawing.Size(233, 26);
            this.radioButtonRamp.TabIndex = 4;
            this.radioButtonRamp.TabStop = true;
            this.radioButtonRamp.Text = "Линейно возрастающее";
            this.radioButtonRamp.UseVisualStyleBackColor = true;
            this.radioButtonRamp.CheckedChanged += new System.EventHandler(this.radioButtonRamp_CheckedChanged);
            // 
            // radioButtonAmp
            // 
            this.radioButtonAmp.AutoSize = true;
            this.radioButtonAmp.Location = new System.Drawing.Point(10, 25);
            this.radioButtonAmp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonAmp.Name = "radioButtonAmp";
            this.radioButtonAmp.Size = new System.Drawing.Size(151, 26);
            this.radioButtonAmp.TabIndex = 5;
            this.radioButtonAmp.TabStop = true;
            this.radioButtonAmp.Text = "Усилительное";
            this.radioButtonAmp.UseVisualStyleBackColor = true;
            this.radioButtonAmp.CheckedChanged += new System.EventHandler(this.radioButtonAmp_CheckedChanged);
            // 
            // radioButtonDif
            // 
            this.radioButtonDif.AutoSize = true;
            this.radioButtonDif.Location = new System.Drawing.Point(10, 57);
            this.radioButtonDif.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonDif.Name = "radioButtonDif";
            this.radioButtonDif.Size = new System.Drawing.Size(288, 26);
            this.radioButtonDif.TabIndex = 6;
            this.radioButtonDif.TabStop = true;
            this.radioButtonDif.Text = "Реальное дифференцирующее";
            this.radioButtonDif.UseVisualStyleBackColor = true;
            this.radioButtonDif.CheckedChanged += new System.EventHandler(this.radioButtonDif_CheckedChanged);
            // 
            // radioButtonExo
            // 
            this.radioButtonExo.AutoSize = true;
            this.radioButtonExo.Location = new System.Drawing.Point(10, 88);
            this.radioButtonExo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonExo.Name = "radioButtonExo";
            this.radioButtonExo.Size = new System.Drawing.Size(135, 26);
            this.radioButtonExo.TabIndex = 7;
            this.radioButtonExo.TabStop = true;
            this.radioButtonExo.Text = "Изодромное";
            this.radioButtonExo.UseVisualStyleBackColor = true;
            this.radioButtonExo.CheckedChanged += new System.EventHandler(this.radioButtonExo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRamp);
            this.groupBox1.Controls.Add(this.radioButtonStep);
            this.groupBox1.Location = new System.Drawing.Point(16, 110);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(248, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Входное воздействие:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDif);
            this.groupBox2.Controls.Add(this.radioButtonAmp);
            this.groupBox2.Controls.Add(this.radioButtonExo);
            this.groupBox2.Location = new System.Drawing.Point(16, 204);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(292, 116);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Корректирующие звено:";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(56, 399);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(72, 30);
            this.textBoxK.TabIndex = 10;
            this.textBoxK.Visible = false;
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(56, 331);
            this.textBoxT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(72, 30);
            this.textBoxT.TabIndex = 11;
            // 
            // textBoxtk
            // 
            this.textBoxtk.Location = new System.Drawing.Point(56, 366);
            this.textBoxtk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxtk.Name = "textBoxtk";
            this.textBoxtk.Size = new System.Drawing.Size(72, 30);
            this.textBoxtk.TabIndex = 12;
            // 
            // textBoxTky
            // 
            this.textBoxTky.Location = new System.Drawing.Point(56, 399);
            this.textBoxTky.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxTky.Name = "textBoxTky";
            this.textBoxTky.Size = new System.Drawing.Size(72, 30);
            this.textBoxTky.TabIndex = 13;
            this.textBoxTky.Visible = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 613);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(402, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxRamp
            // 
            this.textBoxRamp.Location = new System.Drawing.Point(286, 328);
            this.textBoxRamp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxRamp.Name = "textBoxRamp";
            this.textBoxRamp.Size = new System.Drawing.Size(72, 30);
            this.textBoxRamp.TabIndex = 15;
            this.textBoxRamp.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.labelKramp);
            this.panel2.Controls.Add(this.pictureBoxTky);
            this.panel2.Controls.Add(this.pictureBoxtk);
            this.panel2.Controls.Add(this.pictureBoxT);
            this.panel2.Controls.Add(this.pictureBoxK);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBoxRamp);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.textBoxTky);
            this.panel2.Controls.Add(this.textBoxT);
            this.panel2.Controls.Add(this.textBoxtk);
            this.panel2.Controls.Add(this.textBoxK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 657);
            this.panel2.TabIndex = 17;
            // 
            // labelKramp
            // 
            this.labelKramp.AutoSize = true;
            this.labelKramp.Location = new System.Drawing.Point(152, 331);
            this.labelKramp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKramp.Name = "labelKramp";
            this.labelKramp.Size = new System.Drawing.Size(134, 22);
            this.labelKramp.TabIndex = 21;
            this.labelKramp.Text = "Коэф. наклона";
            this.labelKramp.Visible = false;
            // 
            // pictureBoxTky
            // 
            this.pictureBoxTky.Image = global::TAU_Complex.Properties.Resources.Tky;
            this.pictureBoxTky.Location = new System.Drawing.Point(21, 399);
            this.pictureBoxTky.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxTky.Name = "pictureBoxTky";
            this.pictureBoxTky.Size = new System.Drawing.Size(27, 24);
            this.pictureBoxTky.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTky.TabIndex = 20;
            this.pictureBoxTky.TabStop = false;
            this.pictureBoxTky.Visible = false;
            // 
            // pictureBoxtk
            // 
            this.pictureBoxtk.Image = global::TAU_Complex.Properties.Resources.tk;
            this.pictureBoxtk.Location = new System.Drawing.Point(21, 366);
            this.pictureBoxtk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxtk.Name = "pictureBoxtk";
            this.pictureBoxtk.Size = new System.Drawing.Size(27, 24);
            this.pictureBoxtk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxtk.TabIndex = 19;
            this.pictureBoxtk.TabStop = false;
            // 
            // pictureBoxT
            // 
            this.pictureBoxT.Image = global::TAU_Complex.Properties.Resources.T;
            this.pictureBoxT.Location = new System.Drawing.Point(21, 331);
            this.pictureBoxT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxT.Name = "pictureBoxT";
            this.pictureBoxT.Size = new System.Drawing.Size(27, 24);
            this.pictureBoxT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxT.TabIndex = 18;
            this.pictureBoxT.TabStop = false;
            // 
            // pictureBoxK
            // 
            this.pictureBoxK.Image = global::TAU_Complex.Properties.Resources.KB;
            this.pictureBoxK.Location = new System.Drawing.Point(21, 399);
            this.pictureBoxK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxK.Name = "pictureBoxK";
            this.pictureBoxK.Size = new System.Drawing.Size(27, 24);
            this.pictureBoxK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxK.TabIndex = 17;
            this.pictureBoxK.TabStop = false;
            this.pictureBoxK.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TAU_Complex.Properties.Resources.Схема_точности;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 657);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Resize += new System.EventHandler(this.Form5_Resize);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonStep;
        private System.Windows.Forms.RadioButton radioButtonRamp;
        private System.Windows.Forms.RadioButton radioButtonAmp;
        private System.Windows.Forms.RadioButton radioButtonDif;
        private System.Windows.Forms.RadioButton radioButtonExo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.TextBox textBoxtk;
        private System.Windows.Forms.TextBox textBoxTky;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxRamp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxTky;
        private System.Windows.Forms.PictureBox pictureBoxtk;
        private System.Windows.Forms.PictureBox pictureBoxT;
        private System.Windows.Forms.PictureBox pictureBoxK;
        private System.Windows.Forms.Label labelKramp;
    }
}