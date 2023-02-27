using System;
using System.Windows.Forms;

namespace TAU_Complex
{
    public partial class Form_error : Form
    {
        public Form_error(string EText = null)
        {
            InitializeComponent();
            label1.Text = "Некорректные входные значения";
            if (EText != null)
            {
                label1.Text = EText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
