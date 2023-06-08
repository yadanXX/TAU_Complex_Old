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
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TAU_Complex
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            Data.active_value = 15;
            zedGraphControl1.GraphPane.Title.Text = "Карта корней";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Мнимая ось";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Вещественная ось";

            zedGraphControl2.GraphPane.Title.Text = "Переходная характеристика/ЛАЧХ";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Q(t)/Амплитуда (дБ)";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "t/Частота (Гц)";
        }
        private void Form9_Resize(object sender, EventArgs e)
        {
            zedGraphControl1.Height = panelGraph.Height / 2;
            zedGraphControl2.Height = panelGraph.Height / 2;
        }

        PointPairList list_1 = new PointPairList(); // карта корней
        PointPairList list_2 = new PointPairList(); // переходная
        PointPairList list_3 = new PointPairList(); // лачх
        PointPairList list_32 = new PointPairList(); // лачх

        private void button1_Click(object sender, EventArgs e)
        {
            list_1.Clear();
            list_2.Clear();
            list_3.Clear();
            list_32.Clear();

            double k1, k2;
            double T1, T2, T3;
            double tk;
            try
            {
                k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                k2 = Convert.ToDouble(textBoxk2.Text.Replace(".", ","));
                T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                T2 = Convert.ToDouble(textBoxT2.Text.Replace(".", ","));
                T3 = Convert.ToDouble(textBoxT3.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                if (tk <= 0 || T1 <= 0 || T2 <= 0 || T3 <= 0 || k1 <= 0 || k2 <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }

            Program.SetDt(tk, new List<double>() { T1, T2, T3 });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;

            double wv1, wv2 = 0, temp1 = 0, temp2 = 0, temp3 = 0;

            if (radioButton1.Checked)
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (wv1, temp1) = Wlink.PropDifDelay(1 - wv2, k2, T3, T2, temp1, Dt);
                    (wv2, temp2) = Wlink.Aperiodic(wv1, k1, T1, temp2, Dt);

                    list_2.Add(i, wv2);
                }
                List<double> maxT = new List<double> { 1 / T1, 1 / T2, 1 / T3 };
                for (double i = Math.Pow(10, -3); i < maxT.Max() + 100; i += 0.01)
                {
                    list_3.Add(i, 20 * Math.Log10(k1 * k2) + 20 * Math.Log10(Math.Pow(1 + T2 * T2 * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(1 + T1 * T1 * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(1 + T3 * T3 * i * i, 0.5)));
                }
                list_32.Add(1 / T1, list_3.InterpolateX(1 / T1));
                list_32.Add(1 / T2, list_3.InterpolateX(1 / T2));
                list_32.Add(1 / T3, list_3.InterpolateX(1 / T3));
            }
            else if (radioButton2.Checked)
            {
                double si;
                try
                {
                    si = Convert.ToDouble(textBoxsi.Text.Replace(".", ","));
                    if (si <= 0) throw new Exception();
                }
                catch (Exception)
                {
                    Form_error f = new Form_error();
                    f.ShowDialog();
                    throw;
                }

                for (double i = 0; i < tk; i += Dt)
                {
                    (wv1, temp1) = Wlink.PropDifDelay(1 - wv2, k2, T3, T2, temp1, Dt);
                    (wv2, temp2, temp3) = Wlink.Oscillatory(wv1, k1, T1, T1 * si * 2, temp2, temp3, Dt);
                    list_2.Add(i, wv2);
                }

                List<double> maxT = new List<double> { 1 / T1, 1 / T2, 1 / T3, 1 / (T1 * 2 * si) };
                for (double i = Math.Pow(10, -3); i < maxT.Max() + 100; i += 0.01)
                {
                    list_3.Add(i, 20 * Math.Log10(k1 * k2) + 20 * Math.Log10(Math.Pow(1 + T2 * T2 * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(1 + T1 * T1 * T1 * T1 * i * i * i * i + 4 * si * si * T1 * T1 * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(1 + T3 * T3 * i * i, 0.5)));
                }
                list_32.Add(1 / T1, list_3.InterpolateX(1 / T1));
                list_32.Add(1 / (T1 * 2 * si), list_3.InterpolateX(1 / (T1 * 2 * si)));
                list_32.Add(1 / T2, list_3.InterpolateX(1 / T2));
                list_32.Add(1 / T3, list_3.InterpolateX(1 / T3));
            }
            else if (radioButton3.Checked)
            {
                for (double i = 0; i < tk; i += Dt)
                {
                    (wv1, temp1) = Wlink.PropDifDelay(1 - wv2, k2, T3, T2, temp1, Dt);
                    (wv2, temp2, temp3) = Wlink.Integrating(wv1, k1, T1, temp2, temp3, Dt);
                    list_2.Add(i, wv2);
                }
                List<double> maxT = new List<double> { 1 / T1, 1 / T2, 1 / T3 };
                for (double i = Math.Pow(10, -3); i < maxT.Max() + 100; i += 0.01)
                {
                    list_3.Add(i, 20 * Math.Log10(k1 * k2) + 20 * Math.Log10(Math.Pow(1 + T2 * T2 * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(i * i + T1 * T1 * i * i * i * i, 0.5)) - 20 * Math.Log10(Math.Pow(1 + T3 * T3 * i * i, 0.5)));
                }
                list_32.Add(1 / T1, list_3.InterpolateX(1 / T1));
                list_32.Add(1 / T2, list_3.InterpolateX(1 / T2));
                list_32.Add(1 / T3, list_3.InterpolateX(1 / T3));
            }


            if (radioButtonT.Checked)
            {
                DrawGraph(zedGraphControl2, list_2, "График переходной характиристики", "Qвых(t)", "t");
            }
            else if (radioButtonHz.Checked)
            {
                DrawGraphLg(zedGraphControl2, list_3, "ЛАЧХ", "Амплитуда (дБ)", "Частота (рад/сек)", list_32);
            }           

            string legend = $" k1={textBoxk1.Text} k2={textBoxk2.Text}  T1={textBoxT1.Text} T2={textBoxT2.Text} T3={textBoxT3.Text}";
            Data.list1 = list_2;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";

            Data.list2 = list_2;
            Data.legend2 = legend;
            Data.title2 = "";
            Data.Ytitle2 = "";
            Data.Xtitle2 = "";

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

        private void DrawGraphLg(ZedGraphControl zedGraph, PointPairList list, string TitleText, string YText, string XText, PointPairList list2)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            LineItem myCurve1 = pane.AddCurve("", list, Color.Red, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("", list2, Color.Blue, SymbolType.Diamond);
            myCurve1.Line.Width = 2f;
            myCurve2.Line.IsVisible = false;
            myCurve2.Symbol.Size = 10;
            myCurve2.Symbol.Fill.Color = Color.Blue;
            myCurve2.Symbol.Fill.Type = FillType.Solid;
            pane.Title.Text = TitleText;
            pane.YAxis.Title.Text = YText;
            pane.XAxis.Title.Text = XText;
            // !!!
            // Установим логарифмический тип оси
            pane.XAxis.Type = AxisType.Log;

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
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) panelsi.Visible = true;
            else panelsi.Visible = false;

            if (radioButton1.Checked) pictureBoxDiagram.Image = Properties.Resources.cхема_с_апериодическим;
            if (radioButton2.Checked) pictureBoxDiagram.Image = Properties.Resources.cхема_с_колебательным;
            if (radioButton3.Checked) pictureBoxDiagram.Image = Properties.Resources.cхема_с_интегрирующим;
        }

        private void radioButtonTHZ_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonT.Checked)
            {
                DrawGraph(zedGraphControl2, list_2, "График переходной характиристики", "Qвых(t)", "t");
            }
            else if (radioButtonHz.Checked)
            {
                DrawGraphLg(zedGraphControl2, list_3, "ЛАЧХ", "Амплитуда (дБ)", "Частота (рад/сек)", list_32);
            }
        }
    }
}
