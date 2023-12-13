namespace TAU_Complex
{
    partial class Form1
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
            this.comboBoxMain = new System.Windows.Forms.ComboBox();
            this.panelComboBox = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panelSideMain = new System.Windows.Forms.Panel();
            this.panelComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxMain
            // 
            this.comboBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMain.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.comboBoxMain.FormattingEnabled = true;
            this.comboBoxMain.Items.AddRange(new object[] {
            "Идеальное усилительное (безынерционное) звено",
            "Апериодическое (инерционное) звено",
            "Апериодическое звено второго порядка",
            "Колебательное звено",
            "Идеальное интегрирующее звено",
            "Инерционное (реальное) интегрирующее звено",
            "Инерционное дифференцирующее звено"});
            this.comboBoxMain.Location = new System.Drawing.Point(0, 0);
            this.comboBoxMain.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxMain.Name = "comboBoxMain";
            this.comboBoxMain.Size = new System.Drawing.Size(1249, 31);
            this.comboBoxMain.TabIndex = 0;
            this.comboBoxMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxMain_SelectedIndexChanged);
            // 
            // panelComboBox
            // 
            this.panelComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelComboBox.Controls.Add(this.comboBoxMain);
            this.panelComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComboBox.Location = new System.Drawing.Point(0, 0);
            this.panelComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelComboBox.Name = "panelComboBox";
            this.panelComboBox.Size = new System.Drawing.Size(1249, 33);
            this.panelComboBox.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphControl1.Location = new System.Drawing.Point(440, 33);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(809, 747);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // panelSideMain
            // 
            this.panelSideMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMain.Location = new System.Drawing.Point(0, 33);
            this.panelSideMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelSideMain.Name = "panelSideMain";
            this.panelSideMain.Size = new System.Drawing.Size(440, 747);
            this.panelSideMain.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1249, 780);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.panelSideMain);
            this.Controls.Add(this.panelComboBox);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelComboBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelComboBox;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panelSideMain;
        public System.Windows.Forms.ComboBox comboBoxMain;
    }
}