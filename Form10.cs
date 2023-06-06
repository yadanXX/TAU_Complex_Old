using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TAU_Complex
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            Data.active_value = 16;
            zedGraphControl1.GraphPane.Title.Text = "Переходная характеристика";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Q(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";

            zedGraphControl2.GraphPane.Title.Text = "Ошибка";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "∆Q(t)";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "t";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void Form10_Resize(object sender, EventArgs e)
        {
            zedGraphControl1.Height = panelGraph.Height / 2;
            zedGraphControl2.Height = panelGraph.Height / 2;
        }

        public delegate double Deleg(double a);

        private void button1_Click(object sender, EventArgs e)
        {
            double k1, k2, k3, k4;
            double T3, T4;
            double tk;
            try
            {
                k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                k2 = Convert.ToDouble(textBoxk2.Text.Replace(".", ","));
                k3 = Convert.ToDouble(textBoxk3.Text.Replace(".", ","));
                k4 = Convert.ToDouble(textBoxk4.Text.Replace(".", ","));
                T3 = Convert.ToDouble(textBoxT3.Text.Replace(".", ","));
                T4 = Convert.ToDouble(textBoxT4.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                if (tk <= 0 || T3 <= 0 || T4 <= 0 || k1 <= 0 || k2 <= 0 || k3 <= 0 || k4 <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }


            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();

            Program.SetDt(tk, new List<double>() { T3, T4,});
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;

            Deleg xv = NS;
            if (radioButton1.Checked) xv = step;
            else if (radioButton2.Checked) xv = sinus;

            double wv1, wv2, wv3, wv4=0, wv5=0;
            double temp3 = 0, temp41 = 0, temp42 = 0;

            for (double i = 0; i < tk; i += Dt)
            {
                list_2.Add(i, xv(i) - wv5);
                wv1 = Wlink.NonEnertion(xv(i) - wv5, k1);
                wv2 = wv1 - Wlink.NonEnertion(wv4, k2);                
                if (wv2 <= -1 || wv2 >= 1)
                {
                    wv2 = wv2 / Math.Abs(wv2);
                }
                
                (wv3, temp3) = Wlink.Aperiodic(wv2, k3, T3, temp3, Dt);
                (wv4, temp41, temp42) = Wlink.Oscillatory(wv3, k4, T4, T4, temp41, temp42, Dt);
                wv5 = Wlink.IdealInter(wv4, 1, wv5, Dt);

                list_1.Add(i, wv5);
                
            }

            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Ошибка", "∆Q(t)", "t");

            string legend = $" k1={textBoxk1.Text} k2={textBoxk2.Text} k3={textBoxk3.Text} k4={textBoxk4.Text} T3={textBoxT3.Text} T4={textBoxT4.Text} ";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend;
            Data.title2 = "Ошибка";
            Data.Ytitle2 = "∆Q(t)";
            Data.Xtitle2 = "t";
        }

        private void DrawGraph(ZedGraphControl zedGraphControl, PointPairList list_1, string TitleText, string YText, string XText)
        {
            /*
             * zedGraphControl - рабоячая область Zграфика
             * list_1 - массив точек x и y на графике
             * TitleText - заголовок графика
             * YText , XText - подписи осей
             * Результат - постоение графика на выйбраной рабочей области с входными данными и нанесением сетки
             */
            GraphPane pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();
            LineItem myCurve1 = pane.AddCurve("", list_1, Color.Red, SymbolType.None);
            myCurve1.Line.Width = 2f;
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

        double sinus(double time)
        {
            return Math.Sin(0.5 * time);
        }
        double step(double a)
        {
            return 1;
        }
        double NS(double a)
        {
            return 0;
        }
    }
}
