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
    public partial class SubMod2 : UserControl
    {
        public SubMod2()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            double k;
            double t1;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox2k.Text.Replace(".", ","));
                t1 = Convert.ToDouble(textBox2t1.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBox2tk.Text.Replace(".", ","));
                if (tk <= 0 || k <= 0 || t1 <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            Program.SetDt(tk, new List<double>() { t1 });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;

            Form1.lists[1] = new PointPairList();
            for (double i = 0; i < tk; i += Dt)
            {
                Form1.lists[1].Add(i, k * (1.0 - Math.Exp(-i / t1)));
            }
            Form1.DrawGraph();
            string legend = $"k={textBox2k.Text} T={textBox2t1.Text} tk={textBox2tk.Text}";
            Data.list1 = Form1.lists[1];
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";
        }
    }
}
