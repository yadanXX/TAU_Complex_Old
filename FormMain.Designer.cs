namespace TAU_Complex
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_tool_menu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelWorkSpace = new System.Windows.Forms.Panel();
            this.slide_timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.buttonShut_down = new System.Windows.Forms.Button();
            this.button_options = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.slide_button = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelWorkSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.panelSideMenu.Controls.Add(this.button6);
            this.panelSideMenu.Controls.Add(this.button5);
            this.panelSideMenu.Controls.Add(this.button4);
            this.panelSideMenu.Controls.Add(this.button3);
            this.panelSideMenu.Controls.Add(this.button2);
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.panel_tool_menu);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelSideMenu.MaximumSize = new System.Drawing.Size(250, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 661);
            this.panelSideMenu.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.LightGray;
            this.button6.Location = new System.Drawing.Point(0, 450);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(250, 80);
            this.button6.TabIndex = 7;
            this.button6.Text = "Исследование инвариантности систем";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 370);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(250, 80);
            this.button5.TabIndex = 6;
            this.button5.Text = "Исследование точности САУ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.LightGray;
            this.button4.Location = new System.Drawing.Point(0, 290);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(250, 80);
            this.button4.TabIndex = 5;
            this.button4.Text = "Исследование устойчивости САУ со звеном чистого запаздывания";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(0, 210);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 80);
            this.button3.TabIndex = 4;
            this.button3.Text = "Исследование устойчивости систем по критерию Найквикса";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(0, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 80);
            this.button2.TabIndex = 3;
            this.button2.Text = "Исследование устойчивости систем по критерию Михайлову";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(0, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 80);
            this.button1.TabIndex = 2;
            this.button1.Text = "Исследование переходных характиристик типовых динамических звеньев";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_tool_menu
            // 
            this.panel_tool_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.panel_tool_menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tool_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_tool_menu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tool_menu.Name = "panel_tool_menu";
            this.panel_tool_menu.Size = new System.Drawing.Size(250, 50);
            this.panel_tool_menu.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.panel2.Controls.Add(this.buttonRoll);
            this.panel2.Controls.Add(this.buttonShut_down);
            this.panel2.Controls.Add(this.button_options);
            this.panel2.Controls.Add(this.button_help);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.slide_button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 50);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // panelWorkSpace
            // 
            this.panelWorkSpace.Controls.Add(this.pictureBox1);
            this.panelWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkSpace.Location = new System.Drawing.Point(250, 50);
            this.panelWorkSpace.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkSpace.Name = "panelWorkSpace";
            this.panelWorkSpace.Size = new System.Drawing.Size(776, 611);
            this.panelWorkSpace.TabIndex = 2;
            // 
            // slide_timer
            // 
            this.slide_timer.Interval = 1;
            this.slide_timer.Tick += new System.EventHandler(this.slide_timer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::TAU_Complex.Properties.Resources.togu;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 611);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRoll
            // 
            this.buttonRoll.BackgroundImage = global::TAU_Complex.Properties.Resources.min;
            this.buttonRoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRoll.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRoll.FlatAppearance.BorderSize = 0;
            this.buttonRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRoll.Location = new System.Drawing.Point(676, 0);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(50, 50);
            this.buttonRoll.TabIndex = 4;
            this.buttonRoll.TabStop = false;
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // buttonShut_down
            // 
            this.buttonShut_down.BackgroundImage = global::TAU_Complex.Properties.Resources.exit;
            this.buttonShut_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShut_down.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonShut_down.FlatAppearance.BorderSize = 0;
            this.buttonShut_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShut_down.Location = new System.Drawing.Point(726, 0);
            this.buttonShut_down.Name = "buttonShut_down";
            this.buttonShut_down.Size = new System.Drawing.Size(50, 50);
            this.buttonShut_down.TabIndex = 3;
            this.buttonShut_down.TabStop = false;
            this.buttonShut_down.UseVisualStyleBackColor = true;
            this.buttonShut_down.Click += new System.EventHandler(this.buttonShut_down_Click);
            // 
            // button_options
            // 
            this.button_options.BackgroundImage = global::TAU_Complex.Properties.Resources.options;
            this.button_options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_options.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_options.FlatAppearance.BorderSize = 0;
            this.button_options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_options.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_options.Location = new System.Drawing.Point(150, 0);
            this.button_options.Name = "button_options";
            this.button_options.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_options.Size = new System.Drawing.Size(50, 50);
            this.button_options.TabIndex = 2;
            this.button_options.TabStop = false;
            this.button_options.UseVisualStyleBackColor = true;
            this.button_options.Click += new System.EventHandler(this.button_options_Click);
            // 
            // button_help
            // 
            this.button_help.BackgroundImage = global::TAU_Complex.Properties.Resources.help;
            this.button_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_help.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_help.FlatAppearance.BorderSize = 0;
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_help.Location = new System.Drawing.Point(100, 0);
            this.button_help.Name = "button_help";
            this.button_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_help.Size = new System.Drawing.Size(50, 50);
            this.button_help.TabIndex = 1;
            this.button_help.TabStop = false;
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::TAU_Complex.Properties.Resources.Close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(50, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonClose.Size = new System.Drawing.Size(50, 50);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // slide_button
            // 
            this.slide_button.BackgroundImage = global::TAU_Complex.Properties.Resources.slide_button_icon;
            this.slide_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.slide_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.slide_button.FlatAppearance.BorderSize = 0;
            this.slide_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slide_button.Location = new System.Drawing.Point(0, 0);
            this.slide_button.Name = "slide_button";
            this.slide_button.Size = new System.Drawing.Size(50, 50);
            this.slide_button.TabIndex = 0;
            this.slide_button.TabStop = false;
            this.slide_button.UseVisualStyleBackColor = true;
            this.slide_button.Click += new System.EventHandler(this.slide_button_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1026, 661);
            this.Controls.Add(this.panelWorkSpace);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(875, 650);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.panelSideMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelWorkSpace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_tool_menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelWorkSpace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button slide_button;
        private System.Windows.Forms.Timer slide_timer;
        private System.Windows.Forms.Button button_options;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.Button buttonShut_down;
    }
}

