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
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(462, 281);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 287);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(462, 285);
            this.zedGraphControl2.TabIndex = 1;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraphControl1);
            this.panel1.Controls.Add(this.zedGraphControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(434, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 572);
            this.panel1.TabIndex = 2;
            // 
            // radioButtonStep
            // 
            this.radioButtonStep.AutoSize = true;
            this.radioButtonStep.Location = new System.Drawing.Point(9, 19);
            this.radioButtonStep.Name = "radioButtonStep";
            this.radioButtonStep.Size = new System.Drawing.Size(94, 17);
            this.radioButtonStep.TabIndex = 3;
            this.radioButtonStep.TabStop = true;
            this.radioButtonStep.Text = "Ступеньчатое";
            this.radioButtonStep.UseVisualStyleBackColor = true;
            // 
            // radioButtonRamp
            // 
            this.radioButtonRamp.AutoSize = true;
            this.radioButtonRamp.Location = new System.Drawing.Point(9, 41);
            this.radioButtonRamp.Name = "radioButtonRamp";
            this.radioButtonRamp.Size = new System.Drawing.Size(148, 17);
            this.radioButtonRamp.TabIndex = 4;
            this.radioButtonRamp.TabStop = true;
            this.radioButtonRamp.Text = "Линейно возрастающее";
            this.radioButtonRamp.UseVisualStyleBackColor = true;
            // 
            // radioButtonAmp
            // 
            this.radioButtonAmp.AutoSize = true;
            this.radioButtonAmp.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAmp.Name = "radioButtonAmp";
            this.radioButtonAmp.Size = new System.Drawing.Size(98, 17);
            this.radioButtonAmp.TabIndex = 5;
            this.radioButtonAmp.TabStop = true;
            this.radioButtonAmp.Text = "Усилительное";
            this.radioButtonAmp.UseVisualStyleBackColor = true;
            // 
            // radioButtonDif
            // 
            this.radioButtonDif.AutoSize = true;
            this.radioButtonDif.Location = new System.Drawing.Point(6, 42);
            this.radioButtonDif.Name = "radioButtonDif";
            this.radioButtonDif.Size = new System.Drawing.Size(181, 17);
            this.radioButtonDif.TabIndex = 6;
            this.radioButtonDif.TabStop = true;
            this.radioButtonDif.Text = "Реальное дифференцирующее";
            this.radioButtonDif.UseVisualStyleBackColor = true;
            // 
            // radioButtonExo
            // 
            this.radioButtonExo.AutoSize = true;
            this.radioButtonExo.Location = new System.Drawing.Point(6, 65);
            this.radioButtonExo.Name = "radioButtonExo";
            this.radioButtonExo.Size = new System.Drawing.Size(89, 17);
            this.radioButtonExo.TabIndex = 7;
            this.radioButtonExo.TabStop = true;
            this.radioButtonExo.Text = "Изодромное";
            this.radioButtonExo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRamp);
            this.groupBox1.Controls.Add(this.radioButtonStep);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDif);
            this.groupBox2.Controls.Add(this.radioButtonAmp);
            this.groupBox2.Controls.Add(this.radioButtonExo);
            this.groupBox2.Location = new System.Drawing.Point(13, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(214, 15);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(100, 20);
            this.textBoxK.TabIndex = 10;
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(214, 41);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(100, 20);
            this.textBoxT.TabIndex = 11;
            // 
            // textBoxtk
            // 
            this.textBoxtk.Location = new System.Drawing.Point(214, 67);
            this.textBoxtk.Name = "textBoxtk";
            this.textBoxtk.Size = new System.Drawing.Size(100, 20);
            this.textBoxtk.TabIndex = 12;
            // 
            // textBoxTky
            // 
            this.textBoxTky.Location = new System.Drawing.Point(214, 93);
            this.textBoxTky.Name = "textBoxTky";
            this.textBoxTky.Size = new System.Drawing.Size(100, 20);
            this.textBoxTky.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxRamp
            // 
            this.textBoxRamp.Location = new System.Drawing.Point(17, 331);
            this.textBoxRamp.Name = "textBoxRamp";
            this.textBoxRamp.Size = new System.Drawing.Size(100, 20);
            this.textBoxRamp.TabIndex = 15;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 572);
            this.Controls.Add(this.textBoxRamp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTky);
            this.Controls.Add(this.textBoxtk);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Resize += new System.EventHandler(this.Form5_Resize);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}