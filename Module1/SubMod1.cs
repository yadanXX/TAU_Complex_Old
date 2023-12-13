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
    public partial class SubMod1 : UserControl
    {
        public SubMod1()
        {
            InitializeComponent();           
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            double k;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox1k.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBox1tk.Text.Replace(".", ","));
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


            Form1.lists[0] = new PointPairList();
            for (double i = 0; i < tk; i += Dt)
            {
                Form1.lists[0].Add(i, k);
            }
            Form1.DrawGraph();
            string legend = $"k={textBox1k.Text} tk={textBox1tk.Text}";
            Data.list1 = Form1.lists[0];
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";

        }
    }
}
