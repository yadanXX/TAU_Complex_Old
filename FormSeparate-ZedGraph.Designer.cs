namespace TAU_Complex
{
    partial class FormSeparate_ZedGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeparate_ZedGraph));
            this.zedGraphControlSeparate1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControlSeparate2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControlSeparate3 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControlSeparate1
            // 
            this.zedGraphControlSeparate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControlSeparate1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSeparate1.Name = "zedGraphControlSeparate1";
            this.zedGraphControlSeparate1.ScrollGrace = 0D;
            this.zedGraphControlSeparate1.ScrollMaxX = 0D;
            this.zedGraphControlSeparate1.ScrollMaxY = 0D;
            this.zedGraphControlSeparate1.ScrollMaxY2 = 0D;
            this.zedGraphControlSeparate1.ScrollMinX = 0D;
            this.zedGraphControlSeparate1.ScrollMinY = 0D;
            this.zedGraphControlSeparate1.ScrollMinY2 = 0D;
            this.zedGraphControlSeparate1.Size = new System.Drawing.Size(946, 217);
            this.zedGraphControlSeparate1.TabIndex = 0;
            this.zedGraphControlSeparate1.UseExtendedPrintDialog = true;
            this.zedGraphControlSeparate1.Visible = false;
            // 
            // zedGraphControlSeparate2
            // 
            this.zedGraphControlSeparate2.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControlSeparate2.Location = new System.Drawing.Point(0, 217);
            this.zedGraphControlSeparate2.Name = "zedGraphControlSeparate2";
            this.zedGraphControlSeparate2.ScrollGrace = 0D;
            this.zedGraphControlSeparate2.ScrollMaxX = 0D;
            this.zedGraphControlSeparate2.ScrollMaxY = 0D;
            this.zedGraphControlSeparate2.ScrollMaxY2 = 0D;
            this.zedGraphControlSeparate2.ScrollMinX = 0D;
            this.zedGraphControlSeparate2.ScrollMinY = 0D;
            this.zedGraphControlSeparate2.ScrollMinY2 = 0D;
            this.zedGraphControlSeparate2.Size = new System.Drawing.Size(946, 153);
            this.zedGraphControlSeparate2.TabIndex = 1;
            this.zedGraphControlSeparate2.UseExtendedPrintDialog = true;
            this.zedGraphControlSeparate2.Visible = false;
            // 
            // zedGraphControlSeparate3
            // 
            this.zedGraphControlSeparate3.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControlSeparate3.Location = new System.Drawing.Point(0, 370);
            this.zedGraphControlSeparate3.Name = "zedGraphControlSeparate3";
            this.zedGraphControlSeparate3.ScrollGrace = 0D;
            this.zedGraphControlSeparate3.ScrollMaxX = 0D;
            this.zedGraphControlSeparate3.ScrollMaxY = 0D;
            this.zedGraphControlSeparate3.ScrollMaxY2 = 0D;
            this.zedGraphControlSeparate3.ScrollMinX = 0D;
            this.zedGraphControlSeparate3.ScrollMinY = 0D;
            this.zedGraphControlSeparate3.ScrollMinY2 = 0D;
            this.zedGraphControlSeparate3.Size = new System.Drawing.Size(946, 294);
            this.zedGraphControlSeparate3.TabIndex = 2;
            this.zedGraphControlSeparate3.UseExtendedPrintDialog = true;
            this.zedGraphControlSeparate3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraphControlSeparate3);
            this.panel1.Controls.Add(this.zedGraphControlSeparate2);
            this.panel1.Controls.Add(this.zedGraphControlSeparate1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 665);
            this.panel1.TabIndex = 3;
            // 
            // FormSeparate_ZedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 665);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeparate_ZedGraph";
            this.Text = "Графики";
            this.Load += new System.EventHandler(this.FormSeparate_ZedGraph_Load);
            this.Resize += new System.EventHandler(this.FormSeparate_ZedGraph_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControlSeparate1;
        private ZedGraph.ZedGraphControl zedGraphControlSeparate2;
        private ZedGraph.ZedGraphControl zedGraphControlSeparate3;
        private System.Windows.Forms.Panel panel1;
    }
}