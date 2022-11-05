using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TAU_Complex
{
    public partial class Form2 : Form
    {        
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k = Math.Pow(Convert.ToDouble(textBoxK.Text), 1d / 3d);
            double T = Convert.ToDouble(textBoxT.Text);
            double tk = Convert.ToDouble(textBoxtk.Text);
            double w = Convert.ToDouble(textBoxW.Text);
            double T2 = 0.1;
            GraphPane pane1 = zedGraphControl1.GraphPane;
            pane1.CurveList.Clear();
            GraphPane pane2 = zedGraphControl2.GraphPane;
            pane2.CurveList.Clear();
            PointPairList list_1 = new PointPairList();
            PointPairList list_2 = new PointPairList();
            double Dt = 0.001;
            double XNon, XAper, XInte = 0;
            double x1A = 0, x1I = 0, x2I = 0;
            double xv = 1;
            for (double i = 0; i < tk; i += Dt)
            {
                XNon = NonEnertion(xv - XInte, k);
                (XAper, x1A) = Aperiodic(XNon, k, T, x1A, Dt);
                (XInte, x1I, x2I) = Integrating(XAper, k, 0.1, Dt, x1I, x2I);
                list_1.Add(i, XInte);
            }

            for (double i = 0; i < w; i += 0.01)
            {
                list_2.Add(k - Math.Pow(i, 2) * (T + T2), i - T * T2 * Math.Pow(i, 3));
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
        private double NonEnertion(double xv, double k)
        {
            return xv * k;
        }
        private (double, double) Aperiodic(double xv, double k, double T, double x1, double Dt)
        {
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

        private void Form2_Resize(object sender, EventArgs e)
        {            
            zedGraphControl1.Height = panel3.Size.Height / 2;
            zedGraphControl2.Height = panel3.Size.Height / 2;
        }
    }
}
