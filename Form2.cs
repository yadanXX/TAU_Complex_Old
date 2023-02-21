using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

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
            Data.active_value = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // double k = Math.Pow(Convert.ToDouble(textBoxK1.Text), 1d / 3d);
            double k1;
            double k2;
            double k3;
            double T1;
            double T2;
            double tk;
            double w;
            try
            {
                k1 = Convert.ToDouble(textBoxK1.Text);
                k2 = Convert.ToDouble(textBoxK2.Text);
                k3 = Convert.ToDouble(textBoxK3.Text);
                T1 = Convert.ToDouble(textBoxT1.Text);
                T2 = Convert.ToDouble(textBoxT2.Text);
                tk = Convert.ToDouble(textBoxtk.Text);
                if (tk <= 0 || k1 <= 0 || k2 <= 0 || k3 <= 0 || T1 <= 0 || T2 <= 0) throw new Exception();
                w = Convert.ToDouble(textBoxW.Text);
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

            double XNon, XAper, XInte = 0;
            double x1A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            for (double i = 0; i < tk; i += Dt)
            {
                XNon = Wlink.NonEnertion(xv - XInte, k1);
                (XAper, x1A) = Wlink.Aperiodic(XNon, k2, T1, x1A, Dt);
                (XInte, x1I, x2I) = Wlink.Integrating(XAper, k3, T2, x1I, x2I, Dt);
                list_1.Add(i, XInte);
            }
            list1 = list_1;
            legend1 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} k3={textBoxK3.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} tk={textBoxtk.Text}";
            for (double i = 0; i < w; i += Dt)
            {
                list_2.Add(k1 * k2 * k3 - Math.Pow(i, 2) * (T1 + T2), i - T1 * T2 * Math.Pow(i, 3));
            }
            list2 = list_2;
            legend2 = $"k1={textBoxK1.Text} k2={textBoxK2.Text} k3={textBoxK3.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} w={textBoxW.Text}";
            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "h(t)", "t");
            DrawGraph(zedGraphControl2, list_2, "Годограф Михайлова", "jv(w)", "u(w)");

            Data.list1 = list_1;
            Data.legend1 = legend1;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend2;
            Data.title2 = "Годограф Михайлова";
            Data.Ytitle2 = "jv(w)";
            Data.Xtitle2 = "u(w)";

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

    }
}
