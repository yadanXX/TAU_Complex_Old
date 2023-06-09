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

namespace TAU_Complex
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            Data.active_value = 18;
            InitializeComponent();
            zedGraphControl1.GraphPane.Title.Text = "Переходная характеристика";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Q(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k;
            double T1, T2;
            double tk, D;
            try
            {
                k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                T2 = Convert.ToDouble(textBoxT2.Text.Replace(".", ","));
                D = Convert.ToDouble(textBoxD.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                if (tk <= 0 || T1 <= 0 || T2 <= 0 || D <= 0 || k <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }


            PointPairList list_1 = new PointPairList();

            Program.SetDt(tk, new List<double>() { T1, T2, });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;


            double wv1 = 0;
            double temp11 = 0, temp12 = 0;

            list_1.Add(0, 0);
            list_1.Add(D, 0);
            

            for (double i = D*2; i < tk; i += D)
            {
                list_1.Add(i, list_1.Last().Y);
                list_1.Add(i, -T1 * list_1[list_1.Count - 2].Y - (T2+k) * list_1[list_1.Count - 3].Y + k );

            }

            DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

            string legend = $" k={textBoxk.Text} T1={textBoxT1.Text} T2={textBoxT2.Text} D={textBoxD.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";
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
    }
}
