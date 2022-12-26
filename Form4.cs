using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;


namespace TAU_Complex
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Data.active_value = 10;
        }


        private void Form4_Resize(object sender, EventArgs e)
        {
            // !!!!!!!!
            panel1.Height = panelmain.Height / 2;
            panel1.Width = panelmain.Width / 2;
            panel2.Height = panelmain.Height / 2;
            panel2.Width = panelmain.Width / 2;
            panel3.Height = panelmain.Height / 2;
            panel3.Width = panelmain.Width / 2;
            panel4.Height = panelmain.Height / 2;
            panel4.Width = panelmain.Width / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k;
            double T;
            double tk;
            double tau;
            double w;

            try
            {
                k = Convert.ToDouble(textBoxK.Text);
                T = Convert.ToDouble(textBoxT.Text);
                tk = Convert.ToDouble(textBoxtk.Text);
                if (tk <= 0) throw new Exception();
                tau = Convert.ToDouble(textBoxtau.Text);
                w = Convert.ToDouble(textBoxw.Text);
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }


            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            PointPairList list_3 = new PointPairList();


            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;

            double XInt = 0;
            double x1I = 0, x2I = 0;
            double xv = 1;
            double err = 0;
            List<double> delay = new List<double>();
            for (double i = 0; i < tk; i += Dt)
            {
                (XInt, x1I, x2I) = Wlink.Integrating(xv - err, k, T, x1I, x2I, Dt);
                delay.Add(XInt);
                if (delay.Count >= tau / Dt)
                {
                    err = delay[0];
                    list_1.Add(i, delay[0]);
                    delay.RemoveAt(0);
                }
            }
            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");


            double u = 0, v = 0, deter = 0;

            for (double i = 0; i < w; i += Dt)
            {
                u = -k * (Math.Sin(tau * i) + T * i * Math.Cos(tau * i));
                v = -k * (Math.Cos(tau * i) - T * i * Math.Sin(tau * i));
                deter = Math.Pow(T, 2) * Math.Pow(i, 3) + i;
                list_2.Add(u / deter, v / deter);
            }
            DrawGraph(zedGraphControl2, list_2, "АФЧХ", "jv(w)", "u(w)");


            double sus_k, sus_t;
            for (double i = 0; i < Math.PI / (2 * tau); i += Dt)
            {
                sus_k = i / (Math.Sin(tau * i));
                sus_t = 1d / (i * Math.Tan(tau * i));
                //if (sus_k < 0 || sus_t < 0)
                //{
                //    break;
                //}
                list_3.Add(sus_k, sus_t);
            }
            DrawGraph(zedGraphControl3, list_3, "Область устойчивости", "T", "K");
            string legend = $" k={textBoxK.Text} T={textBoxT.Text}  w={textBoxw.Text} tau={textBoxtau.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend;
            Data.title2 = "АФЧХ";
            Data.Ytitle2 = "jv(w)";
            Data.Xtitle2 = "u(w)";

            Data.list3 = list_3;
            Data.legend3 = legend;
            Data.title3 = "Область устойчивости";
            Data.Ytitle3 = "T";
            Data.Xtitle3 = "K";

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
