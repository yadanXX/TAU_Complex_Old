using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TAU_Complex
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k1 = Convert.ToDouble(textBoxK1.Text);
            double k2 = Convert.ToDouble(textBoxK2.Text);
            double T1 = Convert.ToDouble(textBoxT.Text);
            double T2 = 0.1;
            double tk = Convert.ToDouble(textBoxtk.Text);
            double w = Convert.ToDouble(textBoxW.Text);
            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            double Dt = 0.001;
            double XAper = 0, XInt = 0;
            double x1A = 0, x2A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            if (comboBoxNu.Text == "0")
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (XAper, x1A) = Aperiodic(xv - XAper, k1, T1, x1A, Dt);
                    (XAper, x2A) = Aperiodic(XAper, k2, T2, x2A, Dt);
                    list_1.Add(i, XAper);
                }

                double u, v, deter; // u - действительная часть, v - мнимая, deter - общий знаменатель

                for (double i = 0; i < w; i += 0.01)
                {
                    u = k1 * k2 * (1 - Math.Pow(i, 2) * T1 * T2);
                    v = -(i * k1 * k2 * (T1 + T2));
                    deter = ((Math.Pow(i, 2) * T1 + 1) * (Math.Pow(i, 2) * T2 + 1));
                    list_2.Add(u / deter, v / deter);
                }
            }
            else
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (XAper, x1A) = Aperiodic(xv - XInt, k1, T1, x1A, Dt);
                    (XInt, x1I, x2I) = Integrating(XAper, k2, T2, x1I, x2I, Dt);
                    list_1.Add(i, XInt);
                }

                double u, v, deter; // u - действительная часть, v - мнимая, deter - общий знаменатель

                for (double i = 0; i < w; i += 0.01)
                {
                    u = k1 * k2 * (T1 + T2);
                    v = k1 * k2 * (1d - Math.Pow(i, 2) * T1 * T2);
                    deter = (i * T2 + 1) * (i * T1 + 1);
                    list_2.Add(u / deter, v / deter * i);
                }

            }


            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Годограф Найквиста", "u(w)", "vj(w)");
        }
        private (double, double) Aperiodic(double xv, double k, double T, double x1, double Dt)
        {
            /* xv - вход
             * k - коэф усиления
             * T - постоянная времени
             * x1 - предыдущий выход1(промежуточный), после изменения текущий1
             * Dt - дельта t
             * x2 - выход1' (промежуточный производный)
             * x - выход
             */
            double x, x2;
            x2 = (xv - x1) / T;
            x1 = (x1 + Dt * x2);
            x = k * x1;
            return (x, x1);
        }
        private (double, double, double) Integrating(double xv, double k, double T, double x1, double x2, double Dt)
        {
            /* xv - вход
             * k - коэф усиления
             * T - постоянная времени
             * x1 - предыдущий выход1(промежуточный), после изменения текущий1
             * x2 - предыдущий выход2(промежуточный), после изменения текущий2 x'
             * Dt - дельта t
             * x3 - выход1'' (промежуточный производный)
             * x - выход
             */
            double x, x3;
            x3 = xv - x2;
            x2 = x2 + (x3 * Dt) / T;
            x1 = x1 + x2 * Dt;
            x = k * x1;
            return (x, x1, x2);
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            // событие по равномерному изменению по высоте двух графов 
            zedGraphControl1.Height = panel3.Size.Height / 2;
            zedGraphControl2.Height = panel3.Size.Height / 2;
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

    }
}
