using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using ZedGraph;
using static System.Net.Mime.MediaTypeNames;

namespace TAU_Complex
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Data.active_value = 11;
            zedGraphControl1.GraphPane.Title.Text = "График переходной характиристики";
            zedGraphControl2.GraphPane.Title.Text = "Ошибка";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Qвых(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "∆Q(t)";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "t";
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            zedGraphControl1.Height = panel1.Height / 2;
            zedGraphControl2.Height = panel1.Height / 2;
        }

        public delegate double Deleg(double value1, double value2);

        private void button1_Click(object sender, EventArgs e)
        {
            double k = 1;
            double T;
            double tk;
            double Tky = 1;
            double KRamp = 1;
            string legend = "";
            try
            {
                if (radioButtonAmp.Checked)
                {
                    k = Convert.ToDouble(textBoxK.Text.Replace(".", ","));
                    legend += $"k = {k} ";
                }
                T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                legend += $"T = {T} ";
                tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                if (tk <= 0) throw new Exception();
                if (radioButtonDif.Checked || radioButtonExo.Checked)
                {
                    Tky = Convert.ToDouble(textBoxTky.Text.Replace(".", ","));
                    legend += $"Tky = {Tky} ";
                }
                if (radioButtonRamp.Checked)
                {
                    KRamp = Convert.ToDouble(textBoxRamp.Text.Replace(".", ","));
                    legend += $"Коэф. наклона = {KRamp}  ";
                }
                if (k <= 0 || T <= 0 || Tky <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }

            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 10000;

            if (Program.DtCheck(tk, Dt)) return;

            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();

            Deleg xv = NS;
            if (radioButtonStep.Checked) xv = step;
            else if (radioButtonRamp.Checked) xv = ramp;


            double wv1 = 0, wv2 = 0, wv3 = 0, temp1 = 0, temp2 = 0, temp31 = 0, temp32 = 0;

            for (double i = 0; i < tk; i += Dt)
            {
                if (radioButtonAmp.Checked)
                {
                    (wv1) = Wlink.NonEnertion(xv(i, KRamp) - wv3, k);
                }
                else if (radioButtonDif.Checked)
                {
                    (wv1, temp1) = Wlink.Difdelay(xv(i, KRamp) - wv3, k, Tky, 1, temp1, Dt);
                }
                else if (radioButtonExo.Checked)
                {
                    (wv1, temp1) = Wlink.Exodrom(xv(i, KRamp) - wv3, k, Tky, 1, temp1, Dt);
                }
                (wv2, temp2) = Wlink.Aperiodic(wv1, 1, T, temp2, Dt);
                (wv3, temp31, temp32) = Wlink.Integrating(wv2, 1, 1, temp31, temp32, Dt);
                list_1.Add(i, wv3);
                list_2.Add(i, xv(i, KRamp) - wv3);
            }
            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Ошибка", "∆Q(t)", "t");



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


        double ramp(double x, double k)
        {
            return x * k;
        }
        double step(double x, double k)
        {
            return 1;
        }
        double NS(double x, double k)
        {
            return 0;
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

        private void radioButtonRamp_CheckedChanged(object sender, EventArgs e)
        {
            labelKramp.Visible = radioButtonRamp.Checked;
            textBoxRamp.Visible = radioButtonRamp.Checked;
        }

        private void radioButtonAmp_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxK.Visible = radioButtonAmp.Checked;
            textBoxK.Visible = radioButtonAmp.Checked;
        }

        private void radioButtonDif_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxTky.Visible = radioButtonDif.Checked;
            textBoxTky.Visible = radioButtonDif.Checked;
        }

        private void radioButtonExo_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxTky.Visible = radioButtonExo.Checked;
            textBoxTky.Visible = radioButtonExo.Checked;
        }
    }
}