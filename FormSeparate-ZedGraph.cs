using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace TAU_Complex
{
    public partial class FormSeparate_ZedGraph : Form
    {
        //public FormSeparate_ZedGraph(PointPairList list, string legend1, string title = "График переходной характеристики", string Ytitle = "h(t)", string Xtitle = "t")
        //{
        //    list_1 = list;
        //    legend = legend1;
        //    this.title = title;
        //    this.Ytitle = Ytitle;
        //    this.Xtitle = Xtitle;
        //    InitializeComponent();
        //    if (list_1.Count > 1 ) zedGraphControlSeparate1.Visible=true;
        //}
        public FormSeparate_ZedGraph()
        {
            InitializeComponent();
        }

        public PointPairList list_1;
        public PointPairList list_2;
        public PointPairList list_3;

        public string legend_1;
        public string legend_2;
        public string legend_3;

        public string title_1;
        public string Ytitle_1;
        public string Xtitle_1;

        public string title_2;
        public string Ytitle_2;
        public string Xtitle_2;

        public string title_3;
        public string Ytitle_3;
        public string Xtitle_3;

        public int active_graph = 0;

        private void FormSeparate_ZedGraph_Load(object sender, EventArgs e)
        {

            if (list_1 != null)
            {
                zedGraphControlSeparate1.Visible = true;
                Draw(zedGraphControlSeparate1, list_1, legend_1, title_1, Ytitle_1, Xtitle_1);
                active_graph++;
            }
            else zedGraphControlSeparate1.Height = 0;

            if (list_2 != null)
            {
                zedGraphControlSeparate2.Visible = true;
                Draw(zedGraphControlSeparate2, list_2, legend_2, title_2, Ytitle_2, Xtitle_2);
                active_graph++;
            }
            else zedGraphControlSeparate2.Height = 0;

            if (list_3 != null)
            {
                zedGraphControlSeparate3.Visible = true;
                Draw(zedGraphControlSeparate3, list_3, legend_3, title_3, Ytitle_3, Xtitle_3);
                active_graph++;
            }
            else zedGraphControlSeparate3.Height = 0;

            if (list_1 != null)
            {
                zedGraphControlSeparate1.Height = panel1.Height / active_graph;
            }
            if (list_2 != null)
            {
                zedGraphControlSeparate2.Height = panel1.Height / active_graph;
            }
            if (list_3 != null)
            {
                zedGraphControlSeparate3.Height = panel1.Height / active_graph;
            }
        }

        void Draw(ZedGraphControl zedGraphControl, PointPairList list, string legend, string title, string Ytitle, string Xtitle)
        {
            GraphPane pane = zedGraphControl.GraphPane;
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
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void FormSeparate_ZedGraph_Resize(object sender, EventArgs e)
        {
            if (list_1 != null)
            {
                zedGraphControlSeparate1.Height = panel1.Height / active_graph;
            }
            if (list_2 != null)
            {
                zedGraphControlSeparate2.Height = panel1.Height / active_graph;
            }
            if (list_3 != null)
            {
                zedGraphControlSeparate3.Height = panel1.Height / active_graph;
            }


        }
    }
}
