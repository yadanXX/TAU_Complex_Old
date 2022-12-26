using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace TAU_Complex
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Data.active_value = 9;
        }

        PointPairList list1;
        string legend1;
        PointPairList list2;
        string legend2;

        private void button1_Click(object sender, EventArgs e)
        {

            double k1;
            double k2;
            double T1;
            double T2;
            double tk;
            double w;
            try
            {
                k1 = Convert.ToDouble(textBoxK1.Text);
                k2 = Convert.ToDouble(textBoxK2.Text);
                T1 = Convert.ToDouble(textBoxT1.Text);
                T2 = Convert.ToDouble(textBoxT2.Text);
                tk = Convert.ToDouble(textBoxtk.Text);
                if (tk <= 0) throw new Exception();
                w = Convert.ToDouble(textBoxW.Text);
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            double XAper = 0, XInt = 0;
            double x1A = 0, x2A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            if (comboBoxNu.Text == "0")
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (XAper, x1A) = Wlink.Aperiodic(xv - XAper, k1, T1, x1A, Dt);
                    (XAper, x2A) = Wlink.Aperiodic(XAper, k2, T2, x2A, Dt);
                    list_1.Add(i, XAper);
                }
                list1 = list_1;
                legend1 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} tk={textBoxtk.Text}";
                double u, v, deter; // u - действительная часть, v - мнимая, deter - общий знаменатель

                for (double i = 0; i < w; i += Dt)
                {
                    u = k1 * k2 * (1d - Math.Pow(i, 2) * T1 * T2);
                    v = -i * k1 * k2 * (T1 + T2);
                    deter = (Math.Pow(i, 2) * Math.Pow(T1, 2) + 1d) * (Math.Pow(i, 2) * Math.Pow(T2, 2) + 1d);
                    list_2.Add(u / deter, v / deter);
                }
                list2 = list_2;
                legend2 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} w={textBoxW.Text}";
            }
            else
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (XAper, x1A) = Wlink.Aperiodic(xv - XInt, k1, T1, x1A, Dt);
                    (XInt, x1I, x2I) = Wlink.Integrating(XAper, k2, T2, x1I, x2I, Dt);
                    list_1.Add(i, XInt);
                }
                list1 = list_1;
                legend1 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} tk={textBoxtk.Text}";
                double u, v, deter; // u - действительная часть, v - мнимая, deter - общий знаменатель
                for (double i = 0; i < w; i += 0.01)
                {
                    u = -k1 * k2 * (T1 + T2);
                    v = -k1 * k2 * (1d - Math.Pow(i, 2) * T1 * T2);
                    deter = (Math.Pow(i, 2) * Math.Pow(T1, 2) + 1d) * (Math.Pow(i, 2) * Math.Pow(T2, 2) + 1d);
                    list_2.Add(u / deter, v / (deter * i));
                }
                list2 = list_2;
                legend2 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} w={textBoxW.Text}";
            }

            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Годограф Найквиста", "jv(w)", "u(w)");
            Data.list1 = list_1;
            Data.legend1 = legend1;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend2;
            Data.title2 = "Годограф Найквиста";
            Data.Ytitle2 = "jv(w)";
            Data.Xtitle2 = "u(w)";
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
