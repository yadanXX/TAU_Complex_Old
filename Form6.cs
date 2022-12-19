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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private static Random rnd = new Random();

        private void Form6_Resize(object sender, EventArgs e)
        {
            zedGraphControl1.Height = panel1.Height / 2;
            zedGraphControl2.Height = panel1.Height / 2;
        }

        public delegate double Deleg(double value1, double value2);

        private void button1_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBoxK.Text);
            double kp = Convert.ToDouble(textBoxKp.Text);
            double ky = Convert.ToDouble(textBoxKy.Text);
            double kd = Convert.ToDouble(textBoxKd.Text);
            double kr = Convert.ToDouble(textBoxKr.Text);
            double T = Convert.ToDouble(textBoxT.Text);
            double T1 = Convert.ToDouble(textBoxT1.Text);
            double T2 = Convert.ToDouble(textBoxT2.Text);
            double Ty = Convert.ToDouble(textBoxTy.Text);
            double Td = Convert.ToDouble(textBoxTd.Text);
            double tk = Convert.ToDouble(textBoxtk.Text);
            double kramp = Convert.ToDouble(textBoxKRamp.Text);

            double Dt = 0.001;

            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            PointPairList list_3 = new PointPairList();

            Deleg xv = step;
            if (radioButtonStep.Checked) xv = step;
            else if (radioButtonRamp.Checked) xv = ramp;
            else if (radioButtonRandom.Checked)
            {
                if (comboBox1.SelectedIndex == 0) xv = Random;
                else if (comboBox1.SelectedIndex == 1) xv = NextGaussian;
            }
            double wv1, wv01, wv02, wv03, wv04, wv2, wv3, wv4 = 0, temp01 = 0, temp02 = 0, temp03 = 0, temp04 = 0, temp2 = 0, temp31 = 0, temp32 = 0;
            double enter = 0;
            double randFreq = tk / kramp;
            double randCurStage = 0;
            for (double i = 0; i < tk; i += Dt)
            {
                if (radioButtonRandom.Checked)
                {
                    if (i >= randCurStage)
                    {
                        enter = xv(i, kramp);
                        randCurStage += randFreq;
                    }
                }
                else enter = xv(i, kramp);
                (wv01, temp01) = Wlink.Dif(enter, k, temp01, Dt);
                (wv02, temp02) = Wlink.PropDifDelay(wv01, 1, T, T1, temp02, Dt);
                (wv03, temp03) = Wlink.PropDifDelay(wv02, 1, T, T2, temp03, Dt);
                (wv04, temp04) = Wlink.Aperiodic(wv03, 1, T, temp04, Dt);
                wv1 = Wlink.NonEnertion(enter - wv4, kp);
                (wv2, temp2) = Wlink.Aperiodic(wv1 + wv04, ky, Ty, temp2, Dt);
                (wv3, temp31, temp32) = Wlink.Integrating(wv2, kd, Td, temp31, temp32, Dt);
                wv4 = Wlink.NonEnertion(wv3, kr);
                list_1.Add(i, wv4);
                list_2.Add(i, enter - wv4);
                list_3.Add(i, enter);
            }
            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Ошибка", "E(t)", "t");
            DrawGraph(zedGraphControl3, list_3, "Входной сигнал", "h(t)", "t");
        }
        private double ramp(double x, double k)
        {
            return x * k;
        }
        private double step(double x, double k)
        {
            return 1;
        }
        double Random(double x, double k)
        {
            return Math.Round(rnd.NextDouble(), 1);
        }
        public static double NextGaussian(double x, double k)
        {
            // рандом по нормальному закону 
            // mu - пик
            // sigma - разброс
            double rand_normal;
            do
            {
                double mu = 0.5;
                double sigma = 0.5;
                var u1 = rnd.NextDouble();
                var u2 = rnd.NextDouble();
                var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                rand_normal = mu + sigma * rand_std_normal;
            } while (rand_normal < 0 || rand_normal > 1);
            return Math.Round(rand_normal, 1);
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
