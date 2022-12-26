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
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(349, 346);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 246);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(349, 351);
            this.zedGraphControl2.TabIndex = 1;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraphControl1);
            this.panel1.Controls.Add(this.zedGraphControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(329, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 597);
            this.panel1.TabIndex = 2;
            // 
            // radioButtonStep
            // 
            this.radioButtonStep.AutoSize = true;
            this.radioButtonStep.Location = new System.Drawing.Point(12, 23);
            this.radioButtonStep.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonStep.Name = "radioButtonStep";
            this.radioButtonStep.Size = new System.Drawing.Size(119, 20);
            this.radioButtonStep.TabIndex = 3;
            this.radioButtonStep.TabStop = true;
            this.radioButtonStep.Text = "Ступеньчатое";
            this.radioButtonStep.UseVisualStyleBackColor = true;
            // 
            // radioButtonRamp
            // 
            this.radioButtonRamp.AutoSize = true;
            this.radioButtonRamp.Location = new System.Drawing.Point(12, 50);
            this.radioButtonRamp.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRamp.Name = "radioButtonRamp";
            this.radioButtonRamp.Size = new System.Drawing.Size(182, 20);
            this.radioButtonRamp.TabIndex = 4;
            this.radioButtonRamp.TabStop = true;
            this.radioButtonRamp.Text = "Линейно возрастающее";
            this.radioButtonRamp.UseVisualStyleBackColor = true;
            this.radioButtonRamp.CheckedChanged += new System.EventHandler(this.radioButtonRamp_CheckedChanged);
            // 
            // radioButtonAmp
            // 
            this.radioButtonAmp.AutoSize = true;
            this.radioButtonAmp.Location = new System.Drawing.Point(8, 23);
            this.radioButtonAmp.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonAmp.Name = "radioButtonAmp";
            this.radioButtonAmp.Size = new System.Drawing.Size(119, 20);
            this.radioButtonAmp.TabIndex = 5;
            this.radioButtonAmp.TabStop = true;
            this.radioButtonAmp.Text = "Усилительное";
            this.radioButtonAmp.UseVisualStyleBackColor = true;
            this.radioButtonAmp.CheckedChanged += new System.EventHandler(this.radioButtonAmp_CheckedChanged);
            // 
            // radioButtonDif
            // 
            this.radioButtonDif.AutoSize = true;
            this.radioButtonDif.Location = new System.Drawing.Point(8, 52);
            this.radioButtonDif.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonDif.Name = "radioButtonDif";
            this.radioButtonDif.Size = new System.Drawing.Size(229, 20);
            this.radioButtonDif.TabIndex = 6;
            this.radioButtonDif.TabStop = true;
            this.radioButtonDif.Text = "Реальное дифференцирующее";
            this.radioButtonDif.UseVisualStyleBackColor = true;
            this.radioButtonDif.CheckedChanged += new System.EventHandler(this.radioButtonDif_CheckedChanged);
            // 
            // radioButtonExo
            // 
            this.radioButtonExo.AutoSize = true;
            this.radioButtonExo.Location = new System.Drawing.Point(8, 80);
            this.radioButtonExo.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonExo.Name = "radioButtonExo";
            this.radioButtonExo.Size = new System.Drawing.Size(108, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 100);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(203, 77);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Входное воздействие:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDif);
            this.groupBox2.Controls.Add(this.radioButtonAmp);
            this.groupBox2.Controls.Add(this.radioButtonExo);
            this.groupBox2.Location = new System.Drawing.Point(13, 185);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(239, 105);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Корректирующие звено:";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(46, 363);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(60, 22);
            this.textBoxK.TabIndex = 10;
            this.textBoxK.Visible = false;
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(46, 301);
            this.textBoxT.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(60, 22);
            this.textBoxT.TabIndex = 11;
            // 
            // textBoxtk
            // 
            this.textBoxtk.Location = new System.Drawing.Point(46, 333);
            this.textBoxtk.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxtk.Name = "textBoxtk";
            this.textBoxtk.Size = new System.Drawing.Size(60, 22);
            this.textBoxtk.TabIndex = 12;
            // 
            // textBoxTky
            // 
            this.textBoxTky.Location = new System.Drawing.Point(46, 363);
            this.textBoxTky.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTky.Name = "textBoxTky";
            this.textBoxTky.Size = new System.Drawing.Size(60, 22);
            this.textBoxTky.TabIndex = 13;
            this.textBoxTky.Visible = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 557);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(329, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxRamp
            // 
            this.textBoxRamp.Location = new System.Drawing.Point(234, 298);
            this.textBoxRamp.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRamp.Name = "textBoxRamp";
            this.textBoxRamp.Size = new System.Drawing.Size(60, 22);
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 597);
            this.panel2.TabIndex = 17;
            // 
            // labelKramp
            // 
            this.labelKramp.AutoSize = true;
            this.labelKramp.Location = new System.Drawing.Point(124, 301);
            this.labelKramp.Name = "labelKramp";
            this.labelKramp.Size = new System.Drawing.Size(103, 16);
            this.labelKramp.TabIndex = 21;
            this.labelKramp.Text = "Коэф. наклона";
            this.labelKramp.Visible = false;
            // 
            // pictureBoxTky
            // 
            this.pictureBoxTky.Image = global::TAU_Complex.Properties.Resources.Tky;
            this.pictureBoxTky.Location = new System.Drawing.Point(17, 363);
            this.pictureBoxTky.Name = "pictureBoxTky";
            this.pictureBoxTky.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxTky.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTky.TabIndex = 20;
            this.pictureBoxTky.TabStop = false;
            this.pictureBoxTky.Visible = false;
            // 
            // pictureBoxtk
            // 
            this.pictureBoxtk.Image = global::TAU_Complex.Properties.Resources.tk;
            this.pictureBoxtk.Location = new System.Drawing.Point(17, 333);
            this.pictureBoxtk.Name = "pictureBoxtk";
            this.pictureBoxtk.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxtk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxtk.TabIndex = 19;
            this.pictureBoxtk.TabStop = false;
            // 
            // pictureBoxT
            // 
            this.pictureBoxT.Image = global::TAU_Complex.Properties.Resources.T;
            this.pictureBoxT.Location = new System.Drawing.Point(17, 301);
            this.pictureBoxT.Name = "pictureBoxT";
            this.pictureBoxT.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxT.TabIndex = 18;
            this.pictureBoxT.TabStop = false;
            // 
            // pictureBoxK
            // 
            this.pictureBoxK.Image = global::TAU_Complex.Properties.Resources.KB;
            this.pictureBoxK.Location = new System.Drawing.Point(17, 363);
            this.pictureBoxK.Name = "pictureBoxK";
            this.pictureBoxK.Size = new System.Drawing.Size(22, 22);
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
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 597);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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