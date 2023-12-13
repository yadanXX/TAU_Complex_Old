using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TAU_Complex.Module1;
using ZedGraph;


namespace TAU_Complex
{
    public partial class Form1 : Form
    {
        public static List<PointPairList> lists = new List<PointPairList>() { null, null, null, null, null, null, null };
        static PointPairList currentList;
        static ZedGraphControl zedControl;
        static GraphPane pane;

        private UserControl subMod1 = new SubMod1();
        private UserControl subMod2 = new SubMod2();
        private UserControl subMod3 = new SubMod3();
        private UserControl subMod4 = new SubMod4();
        private UserControl subMod5 = new SubMod5();
        private UserControl subMod6 = new SubMod6();
        private UserControl subMod7 = new SubMod7();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideAllPanel();
            comboBoxMain.SelectedIndex = 0;
            zedGraphControl1.GraphPane.Title.Text = "График переходной характеристики";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Qвых(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
            zedControl = zedGraphControl1;
        }
        private void HideAllPanel()
        {
            pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.AxisChange();
            zedGraphControl1.Invalidate();
            panelSideMain.Controls.Clear();
        }
        public void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMain.SelectedIndex)
            {
                case 0:
                    Data.active_value = 1;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod1);
                    DrawGraph();
                    //panel1.Show();
                    break;
                case 1:
                    Data.active_value = 2;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod2);
                    DrawGraph();
                    //panel2.Show();
                    break;
                case 2:
                    Data.active_value = 3;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod3);
                    DrawGraph();
                    //panel3.Show();
                    break;
                case 3:
                    Data.active_value = 4;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod4);
                    DrawGraph();
                    //panel4.Show();
                    break;
                case 4:
                    Data.active_value = 5;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod5);
                    DrawGraph();
                    //panel5.Show();
                    break;
                case 5:
                    Data.active_value = 6;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod6);
                    DrawGraph();
                    //panel6.Show();
                    break;
                case 6:
                    Data.active_value = 7;
                    HideAllPanel();
                    panelSideMain.Controls.Add(subMod7);
                    DrawGraph();
                    //panel7.Show();
                    break;
                default:
                    break;
            }

        }

        public static void DrawGraph()
        {
            currentList = lists[Data.active_value - 1];
            if (currentList == null)
            {
                return;
            }
            LineItem myCurve1 = pane.AddCurve("", currentList, Color.Red, SymbolType.None);
            myCurve1.Line.Width = 2f;
            pane.Title.Text = "График переходной характеристики";
            pane.YAxis.Title.Text = "Qвых(t)";
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
            zedControl.Invalidate();
            zedControl.AxisChange();
            zedControl.Invalidate();
        }


    }
}
