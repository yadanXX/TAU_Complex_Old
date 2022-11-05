using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
// ало,батон будешь?
namespace TAU_Complex
{
    public partial class FormMain : Form
    {
        private Button currentButton;
        private Form activeForm;
        //тест
        //здравствуйте
        public FormMain()
        {
            InitializeComponent();
            this.Text = String.Empty;
            this.ControlBox = false;
            buttonClose.Visible = false;
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
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // lblTitle.Text = childForm.Text;
            buttonClose.Visible = true;
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
            label1.Text = " ";
            currentButton = null;
            buttonClose.Visible = false;
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
    }
}
