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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TAU_Complex
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            Data.active_value = 17;
            InitializeComponent();
            zedGraphControlLeft.GraphPane.Title.Text = "Переходная характеристика";
            zedGraphControlLeft.GraphPane.YAxis.Title.Text = "Q(t)";
            zedGraphControlLeft.GraphPane.XAxis.Title.Text = "t";

            zedGraphControlRight.GraphPane.Title.Text = "Переходная характеристика";
            zedGraphControlRight.GraphPane.YAxis.Title.Text = "Q(t)";
            zedGraphControlRight.GraphPane.XAxis.Title.Text = "t";

            dataGridViewA.RowCount = 3;
            dataGridViewA.ColumnCount = 3;
            dataGridViewA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewB.RowCount = 3;
            dataGridViewB.ColumnCount = 1;
            dataGridViewB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewD.RowCount = 1;
            dataGridViewD.ColumnCount = 3;
            dataGridViewD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < 2; i++) for (int j = 0; j < 3; j++)
                {
                    dataGridViewA.Rows[i].Cells[j].Value = 0;
                    dataGridViewA.Rows[i].Cells[j].ReadOnly = true;
                    dataGridViewB.Rows[i].Cells[0].Value = 0;
                }
            dataGridViewA.Rows[0].Cells[1].Value = 1;
            dataGridViewA.Rows[1].Cells[2].Value = 1;

            for (int i = 0; i < 3; i++) dataGridViewA.Rows[2].Cells[i].Value = -1;
            dataGridViewB.Rows[0].Cells[0].ReadOnly = true;
            dataGridViewB.Rows[1].Cells[0].ReadOnly = true;
            dataGridViewB.Rows[2].Cells[0].Value = 1;

            for (int i = 0; i < 3; i++) dataGridViewD.Rows[0].Cells[i].Value = 0;

        }


        private void buttonLeft_Click(object sender, EventArgs e)
        {
            double k;
            double a1, a2, a3;
            double tk;
            try
            {
                k = Convert.ToDouble(dataGridViewB.Rows[2].Cells[0].Value.ToString().Replace(".", ","));
                a1 = -1 * Convert.ToDouble(dataGridViewA.Rows[2].Cells[2].Value.ToString().Replace(".", ","));
                a2 = -1 * Convert.ToDouble(dataGridViewA.Rows[2].Cells[1].Value.ToString().Replace(".", ","));
                a3 = -1 * Convert.ToDouble(dataGridViewA.Rows[2].Cells[0].Value.ToString().Replace(".", ","));
                tk = Convert.ToDouble(textBoxtkLeft.Text.Replace(".", ","));
                if (radioButton2.Checked)
                {
                    a1 += Convert.ToDouble(dataGridViewD.Rows[0].Cells[2].Value.ToString().Replace(".", ","));
                    a2 += Convert.ToDouble(dataGridViewD.Rows[0].Cells[1].Value.ToString().Replace(".", ","));
                    a3 += Convert.ToDouble(dataGridViewD.Rows[0].Cells[0].Value.ToString().Replace(".", ","));
                }
                if (tk <= 0 || a1 <= 0 || a2 <= 0 || a3 <= 0 || k <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }


            PointPairList list_1 = new PointPairList();

            Program.SetDt(tk, new List<double>() { a1, a2, a3 });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;


            double wv1;
            double temp1 = 0, temp2 = 0, temp3 = 0;



            for (double i = 0; i < tk; i += Dt)
            {
                (wv1, temp1, temp2, temp3) = Wlink.Mod(1, k, a1, a2, a3, temp1, temp2, temp3, Dt);
                list_1.Add(i, wv1);
            }

            DrawGraph(zedGraphControlLeft, list_1, "График переходной характиристики", "Qвых(t)", "t");

            string legend = $" k={textBoxk.Text} a1={textBoxa1.Text} a2={textBoxa2.Text} a3={textBoxa3.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            double k;
            double a1, a2, a3;
            double tk;
            try
            {
                k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                a1 = Convert.ToDouble(textBoxa1.Text.Replace(".", ","));
                a2 = Convert.ToDouble(textBoxa2.Text.Replace(".", ","));
                a3 = Convert.ToDouble(textBoxa3.Text.Replace(".", ","));
                tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                if (tk <= 0 || a1 <= 0 || a2 <= 0 || a3 <= 0 || k <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }


            PointPairList list_1 = new PointPairList();

            Program.SetDt(tk, new List<double>() { a1, a2, a3 });
            double Dt = Data.Dt;
            if (Program.DtCheck(tk, Dt)) return;


            double wv1;
            double temp1 = 0, temp2 = 0, temp3 = 0;


            for (double i = 0; i < tk; i += Dt)
            {
                (wv1, temp1, temp2, temp3) = Wlink.Mod(1, k, a1, a2, a3, temp1, temp2, temp3, Dt);
                list_1.Add(i, wv1);
            }

            DrawGraph(zedGraphControlRight, list_1, "График переходной характиристики", "Qвых(t)", "t");

            string legend = $" k={textBoxk.Text} a1={textBoxa1.Text} a2={textBoxa2.Text} a3={textBoxa3.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "Qвых(t)";
            Data.Xtitle1 = "t";
        }

        private double[,] Multiplication(double[,] a, double[,] b)
        {
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        private void panelMain_Resize(object sender, EventArgs e)
        {
            panelLeft.Width = panelMain.Width / 2;
            panelRight.Width = panelMain.Width / 2;
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panelD.Visible = true;
                pictureBoxLeft.Image = Properties.Resources.В_пространстве_состояний_с_обратной_связью;
                pictureBoxLeft.Height = 249;
            }
            else
            {
                panelD.Visible = false;
                pictureBoxLeft.Image = Properties.Resources.В_пространстве_состояний_без_обратной_связи;
                pictureBoxLeft.Height = 140;
            }
        }

    }
}
