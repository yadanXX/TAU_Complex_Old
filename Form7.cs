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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Data.active_value = 13;
            zedGraphControl1.GraphPane.Title.Text = "График переходной характиристики";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Qвых(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
            ShowDio(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonHFB.Checked)
            {
                double k1;
                double k2;
                double T1;
                double tk;
                string legend = "";
                try
                {
                    k1 = Convert.ToDouble(textBoxk1.Text);
                    k2 = Convert.ToDouble(textBoxk2.Text);
                    T1 = Convert.ToDouble(textBoxT1.Text);
                    tk = Convert.ToDouble(textBoxtk.Text);
                    legend += $"k1 = {k1} k2 = {k2} T1 = {T1}";
                    if (k1 <= 0 || k1 <= 0 || T1 <= 0 || tk <= 0) throw new Exception();
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
                    (wv1, temp1) = Wlink.Aperiodic(xv - wv1, k1, T1, temp1, Dt);
                    list_1.Add(i, wv1);
                    wv2 = wv1 * k2;
                    wv1 = wv1 - wv2;

                }

                DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                Data.list1 = list_1;
                Data.legend1 = legend;
                Data.title1 = "График переходной характеристики";
                Data.Ytitle1 = "Qвых(t)";
                Data.Xtitle1 = "t";
            }
            else if (radioButtonIFB.Checked)
            {
                double k1;
                double k2;
                double T1;
                double T2, Tnu;
                double tk;
                string legend = "";
                try
                {
                    k1 = Convert.ToDouble(textBoxk1.Text);
                    k2 = Convert.ToDouble(textBoxk2.Text);
                    T1 = Convert.ToDouble(textBoxT1.Text);
                    tk = Convert.ToDouble(textBoxtk.Text);
                    T2 = Convert.ToDouble(textBoxT2.Text);
                    Tnu = Convert.ToDouble(textBoxTnu.Text);
                    legend += $"k1 = {k1} k2 = {k2} T1 = {T1} T2 = {T2} Tnu = {Tnu}";
                    if (k1 <= 0 || k1 <= 0 || T1 <= 0 || tk <= 0 || T2 <= 0 || Tnu <= 0) throw new Exception();
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
                double wv1 = 0, wv2 = 0, temp1 = 0, temp2 = 0;

                for (double i = 0; i < tk; i += Dt)
                {
                    wv1 = wv1 - wv2;
                    (wv1, temp1) = Wlink.Aperiodic(xv - wv1, k1, T1, temp1, Dt);
                    list_1.Add(i, wv1);
                    (wv2, temp2) = Wlink.PropDifDelay(wv1, 1 / k2, Tnu, T2, temp2, Dt);

                }

                DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                Data.list1 = list_1;
                Data.legend1 = legend;
                Data.title1 = "График переходной характеристики";
                Data.Ytitle1 = "Qвых(t)";
                Data.Xtitle1 = "t";
            }
            else if (radioButton1.Checked)
            {
                double k1;
                double k2;
                double k3;
                double T1;
                double tk;
                string legend = "";
                try
                {
                    k1 = Convert.ToDouble(textBoxk1.Text);
                    k2 = Convert.ToDouble(textBoxk2.Text);
                    k3 = Convert.ToDouble(textBoxk3.Text);
                    T1 = Convert.ToDouble(textBoxT1.Text);
                    tk = Convert.ToDouble(textBoxtk.Text);
                    legend += $"k1 = {k1} k2 = {k2} k3 = {k3} T1 = {T1}";
                    if (k1 <= 0 || k1 <= 0 || T1 <= 0 || tk <= 0 || k3 <= 0) throw new Exception();
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
                double wv1 = 0, wv2 = 0, wv3, temp1 = 0;

                for (double i = 0; i < tk; i += Dt)
                {
                    wv2 = Wlink.IdealInter(xv - wv1, k2, wv2, Dt);
                    wv3 = Wlink.NonEnertion(xv - wv1, k3);
                    (wv1, temp1) = Wlink.Aperiodic(wv2 + wv3, k1, T1, temp1, Dt);
                    list_1.Add(i, wv1);
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
                double k1;
                double k2;
                double k3;
                double T1;
                double T2;
                double tk;
                string legend = "";
                try
                {
                    k1 = Convert.ToDouble(textBoxk1.Text);
                    k2 = Convert.ToDouble(textBoxk2.Text);
                    k3 = Convert.ToDouble(textBoxk3.Text);
                    T1 = Convert.ToDouble(textBoxT1.Text);
                    T2 = Convert.ToDouble(textBoxT2.Text);
                    tk = Convert.ToDouble(textBoxtk.Text);
                    legend += $"k1 = {k1} k2 = {k2} k3 = {k3} T1 = {T1} T2 = {T2}";
                    if (k1 <= 0 || k2 <= 0 || T1 <= 0 || T2 <= 0 || tk <= 0 || k3 <= 0) throw new Exception();
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
                double wv1 = 0, wv2 = 0, wv3, temp11 = 0, temp12 = 0;

                for (double i = 0; i < tk; i += Dt)
                {
                    wv2 = Wlink.IdealInter(xv - wv1, k2, wv2, Dt);
                    wv3 = Wlink.NonEnertion(xv - wv1, k3);
                    (wv1, temp11, temp12) = Wlink.Oscillatory(wv2 + wv3, k1, T1, T2, temp11, temp12, Dt);
                    list_1.Add(i, wv1);
                }

                DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                Data.list1 = list_1;
                Data.legend1 = legend;
                Data.title1 = "График переходной характеристики";
                Data.Ytitle1 = "Qвых(t)";
                Data.Xtitle1 = "t";
            }
            else if (radioButton3.Checked)
            {
                double k1;
                double k2;
                double k3;
                double T1;
                double tk;
                string legend = "";
                try
                {
                    k1 = Convert.ToDouble(textBoxk1.Text);
                    k2 = Convert.ToDouble(textBoxk2.Text);
                    k3 = Convert.ToDouble(textBoxk3.Text);
                    T1 = Convert.ToDouble(textBoxT1.Text);
                    tk = Convert.ToDouble(textBoxtk.Text);
                    legend += $"k1 = {k1} k2 = {k2} k3 = {k3} T1 = {T1}";
                    if (k1 <= 0 || k2 <= 0 || T1 <= 0 || tk <= 0 || k3 <= 0) throw new Exception();
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
                double wv1 = 0, wv2 = 0, wv3, temp11 = 0, temp12 = 0;

                for (double i = 0; i < tk; i += Dt)
                {
                    wv2 = Wlink.IdealInter(xv - wv1, k2, wv2, Dt);
                    wv3 = Wlink.NonEnertion(xv - wv1, k3);
                    (wv1, temp11, temp12) = Wlink.Integrating(wv2 + wv3, k1, T1, temp11, temp12, Dt);
                    list_1.Add(i, wv1);
                }

                DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                Data.list1 = list_1;
                Data.legend1 = legend;
                Data.title1 = "График переходной характеристики";
                Data.Ytitle1 = "Qвых(t)";
                Data.Xtitle1 = "t";
            }
        }
        private void radioButtonHFB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHFB.Checked)
            {
                panelT2.Visible = false;
                panelTnu.Visible = false;
                ShowDio(1);
                
            }
            else if (radioButtonIFB.Checked)
            {
                panelT2.Visible = true;
                panelTnu.Visible = true;
                ShowDio(2);
            }
        }

        private void radioButtonNSFB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNSFB.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                radioButtonHFB.Checked = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                panelk3.Visible = false;                
            }
            else if (radioButtonISOL.Checked)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                radioButtonHFB.Checked = false;
                radioButtonIFB.Checked = false;
                radioButton1.Checked = true;
                panelk3.Visible = true;
                panelTnu.Visible = false;
                ShowDio(3);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) ShowDio(3);
            if (radioButton3.Checked) ShowDio(5);
            if (radioButton2.Checked)
            {
                panelT2.Visible = true;
                ShowDio(4);
            }
            else panelT2.Visible = false;
        }

        private void ShowDio(int select) 
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            switch (select)
            {
                case 1:
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    pictureBox2.Visible = true;
                    break;
                case 3:
                    pictureBox3.Visible = true;
                    break;
                case 4:
                    pictureBox4.Visible = true;
                    break;
                case 5:
                    pictureBox5.Visible = true;
                    break;
                default:
                    break;
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

        private void pictureBoxBut1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void pictureBoxBut2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void pictureBoxBut3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }
    }
}
