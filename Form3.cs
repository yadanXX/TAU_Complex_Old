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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k1 = Convert.ToDouble(textBoxK1.Text);
            double k2 = Convert.ToDouble(textBoxK2.Text);
            double T1 = Convert.ToDouble(textBoxT.Text);
            double T2 = 0.1;
            double tk = Convert.ToDouble(textBoxtk.Text);
            double w = Convert.ToDouble(textBoxW.Text);
            GraphPane pane1 = zedGraphControl1.GraphPane;
            pane1.CurveList.Clear();
            GraphPane pane2 = zedGraphControl2.GraphPane;
            pane2.CurveList.Clear();
            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            double Dt = 0.001;
            double XNon = 0, XAper = 0, XInte = 0;
            double x1A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            for (double i = 0; i < tk; i += Dt)
            {
                (XAper, x1A) = Aperiodic(xv - XAper, k1, T1, x1A, Dt);
                (XAper, x1A) = Aperiodic(XAper, k2, T2, x1A, Dt);
                list_1.Add(i, XAper);
            }

            for (double i = 0; i < w; i += 0.01)
            {
                list_2.Add(k1 * k2 * ((1 - Math.Pow(i, 2) * T1 * T2)) / ((Math.Pow(i, 2) * Math.Pow(T1, 2) + 1) * (Math.Pow(i, 2) * Math.Pow(T2, 2) + 1)), - (i * k1 * k2 * (T1 + T2)) / ((Math.Pow(i, 2) * Math.Pow(T1, 2) + 1) * (Math.Pow(i, 2) * Math.Pow(T2, 2) + 1)));
            }

            LineItem myCurve1 = pane1.AddCurve("Исходная функция", list_1, Color.Red, SymbolType.None);
            pane1.YAxis.Scale.MinAuto = true;
            pane1.YAxis.Scale.MaxAuto = true;
            pane1.AxisChange();
            zedGraphControl1.Invalidate();
            LineItem myCurve2 = pane2.AddCurve("Исходная функция", list_2, Color.Red, SymbolType.None);
            pane2.YAxis.Scale.MinAuto = true;
            pane2.YAxis.Scale.MaxAuto = true;
            pane2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        private (double, double) Aperiodic(double xv, double k, double T, double x1, double Dt)
        {
            /* xv - вход
             * k - коэф усиления
             * T - постоянная времени
             * x1 - предыдущий выход1(промежуточный), после изменения текущий1
             * Dt - дельта t
             * x2 - выход1' (промежуточный производный)
             * x - выход
             */
            double x, x2;
            x2 = (xv - x1) / T;
            x1 = (x1 + Dt * x2);
            x = k * x1;
            return (x, x1);
        }
        private (double, double, double) Integrating(double xv, double k, double T, double Dt, double x1, double x2)
        {
            double x, x3;
            x3 = xv - x2;
            x2 = x2 + (x3 * Dt) / T;
            x1 = x1 + x2 * Dt;
            x = k * x1;
            return (x, x1, x2);
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            zedGraphControl1.Height = panel3.Size.Height / 2;
            zedGraphControl2.Height = panel3.Size.Height / 2;
        }
    }
}