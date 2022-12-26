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
    //  sigma и mu сделать регулириемии
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Data.active_value = 12;
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
            double k;
            double kp;
            double ky;
            double kd;
            double kr;
            double T;
            double T1;
            double T2;
            double Ty;
            double Td;
            double tk;
            double kramp = 0;
            double rand_value = 0;
            double sigma = 0;
            double mu = 0;
            string legend = "";
            try
            {
                k = Convert.ToDouble(textBoxK.Text);
                kp = Convert.ToDouble(textBoxKp.Text);
                ky = Convert.ToDouble(textBoxKy.Text);
                kd = Convert.ToDouble(textBoxKd.Text);
                kr = Convert.ToDouble(textBoxKr.Text);
                T = Convert.ToDouble(textBoxT.Text);
                T1 = Convert.ToDouble(textBoxT1.Text);
                T2 = Convert.ToDouble(textBoxT2.Text);
                Ty = Convert.ToDouble(textBoxTy.Text);
                Td = Convert.ToDouble(textBoxTd.Text);
                legend += $"K = {k} Kp = {kp} Ky = {ky} Kd = {kd} Kr = {kr} T = {T} T1 = {T1} T2 = {T2} Ty = {Ty} Td = {Td} ";
                if (radioButtonRandom.Checked && comboBox1.SelectedIndex == 1)
                {
                    mu = Convert.ToDouble(textBoxG1.Text);
                    sigma = Convert.ToDouble(textBoxG2.Text);
                    if (sigma <= 0) throw new Exception();
                    legend += $"Мат. Ожидание = {mu} Дисперсия = {sigma} ";

                }             
                            
                tk = Convert.ToDouble(textBoxtk.Text);
                if (tk <= 0) throw new Exception();
                if (radioButtonRamp.Checked)
                {
                    kramp = Convert.ToDouble(textBoxKRamp.Text);
                    legend += $"Коэф. наклона = {kramp} ";
                }
                if (radioButtonRandom.Checked)
                {
                    rand_value = Convert.ToDouble(textBoxRV.Text);
                    legend += $"Кол-во случайных значений = {rand_value} ";
                }
            }
            catch (Exception)
            {

                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }

            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;

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
            double randFreq = tk / rand_value;
            double randCurStage = 0;
            for (double i = 0; i < tk; i += Dt)
            {
                if (radioButtonRandom.Checked)
                {
                    if (i >= randCurStage)
                    {
                        enter = xv(mu, sigma);
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

            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend;
            Data.title2 = "Ошибка";
            Data.Ytitle2 = "E(t)";
            Data.Xtitle2 = "t";

            Data.list3 = list_3;
            Data.legend3 = legend;
            Data.title3 = "Входной сигнал";
            Data.Ytitle3 = "h(t)";
            Data.Xtitle3 = "t";
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
        public static double NextGaussian(double mu, double sigma)
        {
            // рандом по нормальному закону 
            // mu - пик
            // sigma - разброс
            double rand_normal;
            // do
            // {
            //double mu = 0.5;
           // double sigma = mu / 3;
            var u1 = rnd.NextDouble();
            var u2 = rnd.NextDouble();
            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            rand_normal = mu + sigma * rand_std_normal;
            //} while (rand_normal < 0 || rand_normal > 1);
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

        private void radioButtonRamp_CheckedChanged(object sender, EventArgs e)
        {
            labelRamp.Visible = radioButtonRamp.Checked;
            textBoxKRamp.Visible = radioButtonRamp.Checked;
        }

        private void radioButtonRandom_CheckedChanged(object sender, EventArgs e)
        {
            labelRandom.Visible = radioButtonRandom.Checked;
            textBoxRV.Visible = radioButtonRandom.Checked;
            if (!radioButtonRandom.Checked)
            {
                labelG1.Visible = false;
                textBoxG1.Visible = false;
                labelG2.Visible = false;
                textBoxG2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                labelG1.Visible = true;
                textBoxG1.Visible = true;
                labelG2.Visible = true;
                textBoxG2.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (comboBox1.SelectedIndex == 1)
            {
                labelG1.Visible = true;
                textBoxG1.Visible = true;
                labelG2.Visible = true;
                textBoxG2.Visible = true;
            }
            else
            {
                labelG1.Visible = false;
                textBoxG1.Visible = false;
                labelG2.Visible = false;
                textBoxG2.Visible = false;
            }
        }
    }
}
