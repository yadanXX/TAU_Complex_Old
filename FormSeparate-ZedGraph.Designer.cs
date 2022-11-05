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
            this.zedGraphControlSeparate = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphControlSeparate
            // 
            this.zedGraphControlSeparate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlSeparate.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSeparate.Name = "zedGraphControlSeparate";
            this.zedGraphControlSeparate.ScrollGrace = 0D;
            this.zedGraphControlSeparate.ScrollMaxX = 0D;
            this.zedGraphControlSeparate.ScrollMaxY = 0D;
            this.zedGraphControlSeparate.ScrollMaxY2 = 0D;
            this.zedGraphControlSeparate.ScrollMinX = 0D;
            this.zedGraphControlSeparate.ScrollMinY = 0D;
            this.zedGraphControlSeparate.ScrollMinY2 = 0D;
            this.zedGraphControlSeparate.Size = new System.Drawing.Size(916, 623);
            this.zedGraphControlSeparate.TabIndex = 0;
            this.zedGraphControlSeparate.UseExtendedPrintDialog = true;
            // 
            // FormSeparate_ZedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 623);
            this.Controls.Add(this.zedGraphControlSeparate);
            this.Name = "FormSeparate_ZedGraph";
            this.Text = "FormSeparate_ZedGraph";
            this.Load += new System.EventHandler(this.FormSeparate_ZedGraph_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControlSeparate;
    }
}