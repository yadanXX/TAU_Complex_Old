using System;
using System.Windows.Forms;

namespace TAU_Complex
{
    public partial class Form_options : Form
    {

        public Form_options()
        {
            InitializeComponent();
            textBoxDt.Text = Data.Dt.ToString();
            if (Data.active_value <= 7 || Data.active_value == 13) checkBox1.Visible = true;
            if (Data.active_value == 8 || Data.active_value == 9)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
            if (Data.active_value == 10)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
            }
            if (Data.active_value == 11)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
            if (Data.active_value == 12)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
            }
        }

        private void Form_options_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Data.Dt = Convert.ToDouble(textBoxDt.Text);
            }
            catch { }

            FormSeparate_ZedGraph f = new FormSeparate_ZedGraph();

            if (checkBox1.Checked)
            {
                f.legend_1 = Data.legend1;
                f.list_1 = Data.list1;
                f.title_1 = Data.title1;
                f.Xtitle_1 = Data.Xtitle1;
                f.Ytitle_1 = Data.Ytitle1;

            }
            if (checkBox2.Checked)
            {
                f.legend_2 = Data.legend2;
                f.list_2 = Data.list2;
                f.title_2 = Data.title2;
                f.Xtitle_2 = Data.Xtitle2;
                f.Ytitle_2 = Data.Ytitle2;
            }
            if (checkBox3.Checked)
            {
                f.legend_3 = Data.legend3;
                f.list_3 = Data.list3;
                f.title_3 = Data.title3;
                f.Xtitle_3 = Data.Xtitle3;
                f.Ytitle_3 = Data.Ytitle3;
            }
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
            {
                f.Show();
            }

        }
    }
}
