﻿using System;
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
    public partial class Form1 : Form
    {
        PointPairList list_1;


        public Form1()
        {
            InitializeComponent();
        }
        string legend;
        private void Form2_Load(object sender, EventArgs e)
        {

            HideAllPanel();
            comboBoxMain.SelectedIndex = 0;
        }
        private void HideAllPanel()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMain.SelectedIndex)
            {
                case 0:
                    HideAllPanel();
                    panel1.Show();
                    break;
                case 1:
                    HideAllPanel();
                    panel2.Show();
                    break;
                case 2:
                    HideAllPanel();
                    panel3.Show();
                    break;
                case 3:
                    HideAllPanel();
                    panel4.Show();
                    break;
                case 4:
                    HideAllPanel();
                    panel5.Show();
                    break;
                case 5:
                    HideAllPanel();
                    panel6.Show();
                    break;
                case 6:
                    HideAllPanel();
                    panel7.Show();
                    break;
                default:
                    break;
            }

        }

        private void DrawGraph(GraphPane pane)
        {
            LineItem myCurve1 = pane.AddCurve("", list_1, Color.Red, SymbolType.None);

            pane.Title.Text = "График переходной характеристики";
            pane.YAxis.Title.Text = "h(t)";
            pane.XAxis.Title.Text = "t";            
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
            zedGraphControl1.Invalidate();
            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox1k.Text);
            double tk = Convert.ToDouble(textBox1tk.Text);

            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k);
            }
            DrawGraph(pane);
            legend = $"k={textBox1k.Text} tk={textBox1tk.Text}";
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox2k.Text);
            double t1 = Convert.ToDouble(textBox2t1.Text);
            double tk = Convert.ToDouble(textBox2tk.Text);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k * (1.0 - Math.Exp(-i / t1)));
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox2k.Text} T={textBox2t1.Text} tk={textBox2tk.Text}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox3k.Text);
            double t1 = Convert.ToDouble(textBox3t1.Text);
            double t2 = Convert.ToDouble(textBox3t2.Text);
            double tk = Convert.ToDouble(textBox3tk.Text);
            double t3, t4;
            t3 = t1 / 2.0 + Math.Sqrt(Math.Pow(t1, 2) / 4.0 - Math.Pow(t2, 2));
            t4 = t1 / 2.0 - Math.Sqrt(Math.Pow(t1, 2) / 4.0 - Math.Pow(t2, 2));
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k * (1.0 - t3 / (t3 - t4) * Math.Exp(-i / t3) + t4 / (t3 - t4) * Math.Exp(-i / t4)));
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox3k.Text} T1={textBox3t1.Text} T2={textBox3t2.Text} tk={textBox3tk.Text}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox4k.Text);
            double t1 = Convert.ToDouble(textBox4t1.Text);
            double t2 = Convert.ToDouble(textBox4t2.Text);
            double tk = Convert.ToDouble(textBox4tk.Text);
            double xi;
            xi = t1 / (2.0 * t2);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k * (1.0 - Math.Exp((-xi * i) / t2) * (Math.Cos(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2) + xi / (Math.Sqrt(1.0 - Math.Pow(xi, 2))) * Math.Sin(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2))));
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox4k.Text} T1={textBox4t1.Text} T2={textBox4t2.Text} tk={textBox4tk.Text}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox5k.Text);
            double tk = Convert.ToDouble(textBox5tk.Text);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k * i);
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox5k.Text} tk={textBox5tk.Text}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox6k.Text);
            double t1 = Convert.ToDouble(textBox6t1.Text);
            double tk = Convert.ToDouble(textBox6tk.Text);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k * (i - t1 * (1.0 - Math.Exp(-i / t1))));
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox6k.Text} T={textBox6t1.Text} tk={textBox6tk.Text}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(textBox7k.Text);
            double t1 = Convert.ToDouble(textBox7t1.Text);
            double tk = Convert.ToDouble(textBox7tk.Text);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += 0.01)
            {
                list_1.Add(i, k / t1 * Math.Exp(-i / t1));
            }
            DrawGraph(pane);
            //LineItem myCurve1 = pane.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            //myCurve1.Line.IsVisible = true;
            //pane.YAxis.Scale.MinAuto = true;
            //pane.YAxis.Scale.MaxAuto = true;
            //pane.AxisChange();
            //zedGraphControl1.Invalidate();
            legend = $"k={textBox7k.Text} T={textBox7t1.Text} tk={textBox7tk.Text}";
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            FormSeparate_ZedGraph f = new FormSeparate_ZedGraph(list_1,legend);
            f.Show();
        }
    }
}