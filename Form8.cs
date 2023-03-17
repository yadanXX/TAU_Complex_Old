using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZedGraph;

namespace TAU_Complex
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            Data.active_value = 14;
            zedGraphControl1.GraphPane.Title.Text = "График переходной характиристики";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Qвых(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonRaz.Checked)
            {
                if (radioButton1.Checked)
                {
                    double k1,k;
                    double T1,T2;
                    double tk;
                    string legend = "";
                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text);
                        k = Convert.ToDouble(textBoxkb.Text);
                        T1 = Convert.ToDouble(textBoxT11.Text);
                        T2 = Convert.ToDouble(textBoxT21.Text);
                        tk = Convert.ToDouble(textBoxtk.Text);
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T2 = {T2}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T2 <= 0 || tk <= 0) throw new Exception();
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

                    double xv = 1;
                    double wv1 = 0, wv2, temp1 = 0;

                    for (double i = 0; i < tk; i += Dt)
                    {
                      //  Wlink.PropDifDelay(xv,1/k,T,);

                    }

                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
                else if (radioButton2.Checked)
                { 

                }
            }
            else if (radioButtonVoz.Checked)
            {
                if (radioButton1.Checked)
                {

                }
                else if (radioButton2.Checked)
                {

                }
            }
            else if (radioButtonOtk.Checked)
            {
                if (radioButton1.Checked)
                {

                }
                else if (radioButton2.Checked)
                {

                }
            }
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
