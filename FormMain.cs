using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TAU_Complex
{
    public partial class FormMain : Form
    {
        bool sidebarExpand = true;

        public Button currentButton;
        public Form activeForm;

        public Form1 form1 = new Form1();
        public Form2 form2 = new Form2();
        public Form3 form3 = new Form3();
        public Form4 form4 = new Form4();
        public Form5 form5 = new Form5();

        public Form6 form6 = new Form6();
        public Form7 form7 = new Form7();
        public Form8 form8 = new Form8();
        public Form9 form9 = new Form9();
        public Form10 form10 = new Form10();
        public Form11 form11 = new Form11();
        public Form12 form12 = new Form12();

        public FormMain()
        {
            InitializeComponent();
            this.Text = String.Empty;
            this.ControlBox = false;
            buttonClose.Visible = false;
            button_help.Visible = false;
            button_options.Visible = false;
            ActivateButton(buttonCh1);
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int LParam);

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    // Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    // currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.BackColor = Color.FromArgb(5, 34, 53);
                    //  panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    // ThemeColor.PrimaryColor = color;
                    // ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    // btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSideMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(9, 46, 71);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            //if (activeForm != null)
            //    activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelWorkSpace.Controls.Add(childForm);
            this.panelWorkSpace.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            buttonClose.Visible = true;
            button_help.Visible = true;
            button_options.Visible = true;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            //if (activeForm != null)
            //{
            //    activeForm.Close();
            //}
            DisableButton();
            currentButton = null;
            buttonClose.Visible = false;
            button_help.Visible = false;
            button_options.Visible = false;
        }

        private void button_help_Click(object sender, EventArgs e)
        {

            Form_help f = new Form_help();
            f.Show();
        }

        private void button_options_Click(object sender, EventArgs e)
        {
            Form_options f = new Form_options();
            f.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(form1, sender);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(form2, sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(form3, sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(form4, sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(form5, sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(form6, sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(form7, sender);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(form8, sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(form9, sender);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(form10, sender);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(form11, sender);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            OpenChildForm(form12, sender);
        }
        private void slide_button_Click(object sender, EventArgs e)
        {
            slide_timer.Start();
        }

        private void slide_timer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                panelSideMenu.Width -= 1000;
                if (panelSideMenu.Width == panelSideMenu.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    slide_timer.Stop();
                }
            }
            else
            {
                panelSideMenu.Width += 1000;
                if (panelSideMenu.Width == panelSideMenu.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    slide_timer.Stop();
                }
            }
        }

        private void buttonShut_down_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCh1_Click(object sender, EventArgs e)
        {
            var a = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            for (int i = 0; i < 6; i++) a[i].Visible = true;
            for (int i = 6; i < 12; i++) a[i].Visible = false;
            ActivateButton(sender);
            buttonCh2.BackColor = Color.FromArgb(9, 46, 71);
            buttonCh2.ForeColor = Color.Gainsboro;
            buttonCh2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void buttonCh2_Click(object sender, EventArgs e)
        {
            var a = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            for (int i = 0; i < 6; i++) a[i].Visible = false;
            for (int i = 6; i < 12; i++) a[i].Visible = true;
            ActivateButton(sender);
            buttonCh1.BackColor = Color.FromArgb(9, 46, 71);
            buttonCh1.ForeColor = Color.Gainsboro;
            buttonCh1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
    }
}
