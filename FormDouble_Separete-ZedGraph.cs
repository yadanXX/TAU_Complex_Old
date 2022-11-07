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
    public partial class FormDouble_Separete_ZedGraph : Form
    {
        public FormDouble_Separete_ZedGraph(PointPairList list1, string legend1, PointPairList list2, string legend2, string title1 = "График переходной характеристики", string Ytitle1 = "h(t)", string Xtitle1 = "t", string title2 = "Годограф Михайлова", string Ytitle2 = "jv(w)", string Xtitle2 = "u(w)")
        {
            this.list1 = list1;
            this.legend1 = legend1;
            this.title1 = title1;
            this.Ytitle1 = Ytitle1;
            this.Xtitle1 = Xtitle1;
            this.list2 = list2;
            this.legend2 = legend2;
            this.title2 = title2;
            this.Ytitle2 = Ytitle2;
            this.Xtitle2 = Xtitle2;
            InitializeComponent();
        }
        PointPairList list1, list2;
        string legend1, legend2;
        string title1, title2;
        string Ytitle1, Ytitle2;

        string Xtitle1, Xtitle2;
        private void FormDouble_Separete_ZedGraph_Load(object sender, EventArgs e)
        {
            DrawGraph(zedGraphControl1, legend1, list1, title1, Ytitle1, Xtitle1);
            DrawGraph(zedGraphControl2, legend2, list2, title2, Ytitle2, Xtitle2);

        }
        private void DrawGraph(ZedGraphControl Z, string legend, PointPairList list, string title, string Ytitle, string Xtitle)
        {
            GraphPane pane = Z.GraphPane;
            pane.CurveList.Clear();
            LineItem myCurve1 = pane.AddCurve(legend, list, Color.Red, SymbolType.None);
            pane.Title.Text = title;
            pane.YAxis.Title.Text = Ytitle;
            pane.XAxis.Title.Text = Xtitle;
            // !!!
            // Указываем, что расположение легенды мы будет задавать
            // в виде координат левого верхнего угла
            pane.Legend.Position = LegendPos.Float;

            // Координаты будут отсчитываться в системе координат окна графика
            pane.Legend.Location.CoordinateFrame = CoordType.ChartFraction;

            // Задаем выравнивание, относительно которого мы будем задавать координаты
            // В данном случае мы будем располагать легенду справа внизу
            pane.Legend.Location.AlignH = AlignH.Right;
            pane.Legend.Location.AlignV = AlignV.Bottom;

            // Задаем координаты легенды
            // Вычитаем 0.02f, чтобы был небольшой зазор между осями и легендой
            pane.Legend.Location.TopLeft = new PointF(1.0f - 0.02f, 1.0f - 0.02f);
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
            Z.AxisChange();
            Z.Invalidate();
        }

        private void FormDouble_Separete_ZedGraph_Resize(object sender, EventArgs e)
        {
            // событие по равномерному изменению по высоте двух графов 
            zedGraphControl1.Height = FormDouble_Separete_ZedGraph.ActiveForm.Size.Height / 2;
            zedGraphControl2.Height = FormDouble_Separete_ZedGraph.ActiveForm.Size.Height / 2;
        }

    }
}
