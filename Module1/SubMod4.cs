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
    public partial class SubMod4 : UserControl
    {
        public SubMod4()
        {
            InitializeComponent();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double k;
            double t1;
            double t2;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox4k.Text.Replace(".", ","));
                t1 = Convert.ToDouble(textBox4t1.Text.Replace(".", ","));
                t2 = Convert.ToDouble(textBox4t2.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBox4tk.Text.Replace(".", ","));
                if (tk <= 0 || k <= 0 || t1 <= 0 || t2 <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            Program.SetDt(tk, new List<double>() { t1, t2 });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;

            double xi;
            xi = t1 / (2.0 * t2);
            Form1.lists[3] = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                Form1.lists[3].Add(i, k * (1.0 - Math.Exp((-xi * i) / t2) * (Math.Cos(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2) + xi / (Math.Sqrt(1.0 - Math.Pow(xi, 2))) * Math.Sin(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2))));
            }
            Form1.DrawGraph();
            string legend = $"k={textBox4k.Text} T1={textBox4t1.Text} T2={textBox4t2.Text} tk={textBox4tk.Text}";
            Data.list1 = Form1.lists[3];
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";
        }
    }
}
