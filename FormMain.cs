using System;
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
        public FormMain()
        {
            InitializeComponent();
            this.Text = String.Empty;
            this.ControlBox = false;
            buttonClose.Visible = false;
            button_help.Visible = false;
            button_options.Visible = false;
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
            if (activeForm != null)
                activeForm.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1(), sender);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form2(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form4(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form5(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form6(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form7(), sender);
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


    }
}
