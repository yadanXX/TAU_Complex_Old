using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TAU_Complex
{
    public partial class Form2 : Form
    {
        PointPairList list1;
        string legend1;
        PointPairList list2;
        string legend2;
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // double k = Math.Pow(Convert.ToDouble(textBoxK1.Text), 1d / 3d);
            double k1 = Convert.ToDouble(textBoxK1.Text);
            double k2 = Convert.ToDouble(textBoxK2.Text);
            double k3 = Convert.ToDouble(textBoxK3.Text);
            double T1 = Convert.ToDouble(textBoxT1.Text);
            double T2 = Convert.ToDouble(textBoxT2.Text);
            double tk = Convert.ToDouble(textBoxtk.Text);
            double w = Convert.ToDouble(textBoxW.Text);                       
            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            double Dt = 0.001;
            double XNon, XAper, XInte = 0;
            double x1A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            for (double i = 0; i < tk; i += Dt)
            {
                XNon = NonEnertion(xv - XInte, k1);
                (XAper, x1A) = Aperiodic(XNon, k2, T1, x1A, Dt);
                (XInte, x1I, x2I) = Integrating(XAper, k3, T2, Dt, x1I, x2I);
                list_1.Add(i, XInte);
            }
            list1 = list_1;
            legend1 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} k3={textBoxK3.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} tk={textBoxtk.Text}";
            for (double i = 0; i < w; i += 0.01)
            {
                list_2.Add(k1*k2*k3 - Math.Pow(i, 2) * (T1 + T2), i - T1 * T2 * Math.Pow(i, 3));
            }
            list2 = list_2;
            legend2 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} k3={textBoxK3.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} w={textBoxW.Text}";
            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Годограф Михайлова", "jv(w)", "u(w)");
        }
        private double NonEnertion(double xv, double k)
        {
            return xv * k;
        }
        private (double, double) Aperiodic(double xv, double k, double T, double x1, double Dt)
        {
            double x, x2;
            x2 = (xv - x1) / T;
            x1 = (x1 + Dt * x2);
            x = k * x1;
            return (x, x1);
        }
        private (double, double, double) Integrating(double xv, double k, double T, double Dt, double x1, double x2)
        {
            double x, x3;
            x3 = xv - x2;
            x2 = x2 + (x3 * Dt) / T;
            x1 = x1 + x2 * Dt;
            x = k * x1;
            return (x, x1, x2);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {            
            zedGraphControl1.Height = panel3.Size.Height / 2;
            zedGraphControl2.Height = panel3.Size.Height / 2;
        }
        private void DrawGraph(ZedGraphControl zedGraphControl, PointPairList list_1, string TitleText, string YText, string XText)
        {
            GraphPane pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();
            LineItem myCurve1 = pane.AddCurve("", list_1, Color.Red, SymbolType.None);
            pane.Title.Text = TitleText;
            pane.YAxis.Title.Text = YText;
            pane.XAxis.Title.Text = XText;
            // !!!
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ...
            pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y:
            // Длина штрихов равна одному пикселю, ...
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;
            myCurve1.Line.IsVisible = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.AxisChange();
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSeparate_ZedGraph f = new FormSeparate_ZedGraph(list1, legend1);
            f.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSeparate_ZedGraph f = new FormSeparate_ZedGraph(list2, legend2,title: "Годограф Михайлова",Ytitle: "jv(w)",Xtitle: "u(w)");
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDouble_Separete_ZedGraph f = new FormDouble_Separete_ZedGraph(list1, legend1, list2, legend2);
            f.Show();
        }
    }
}
