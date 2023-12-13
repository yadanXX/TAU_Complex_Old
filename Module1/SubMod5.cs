using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZedGraph;

namespace TAU_Complex.Module1
{
    public partial class SubMod5 : UserControl
    {
        public SubMod5()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double k;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox5k.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBox5tk.Text.Replace(".", ","));
                if (tk <= 0 || k <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            Program.SetDt(tk, new List<double>() { });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;


            Form1.lists[4] = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                Form1.lists[4].Add(i, k * i);
            }
            Form1.DrawGraph();
            string legend = $"k={textBox5k.Text} tk={textBox5tk.Text}";
            Data.list1 = Form1.lists[4];
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";
        }
    }
}
