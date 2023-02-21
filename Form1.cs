using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;


namespace TAU_Complex
{
    public partial class Form1 : Form
    {
        PointPairList list_1;
        string legend;

        public Form1()
        {
            InitializeComponent();
        }

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
        public void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMain.SelectedIndex)
            {
                case 0:
                    Data.active_value = 1;
                    HideAllPanel();
                    panel1.Show();
                    break;
                case 1:
                    Data.active_value = 2;
                    HideAllPanel();
                    panel2.Show();
                    break;
                case 2:
                    Data.active_value = 3;
                    HideAllPanel();
                    panel3.Show();
                    break;
                case 3:
                    Data.active_value = 4;
                    HideAllPanel();
                    panel4.Show();
                    break;
                case 4:
                    Data.active_value = 5;
                    HideAllPanel();
                    panel5.Show();
                    break;
                case 5:
                    Data.active_value = 6;
                    HideAllPanel();
                    panel6.Show();
                    break;
                case 6:
                    Data.active_value = 7;
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
            myCurve1.Line.Width = 2f;
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
            double k;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox1k.Text);
                tk = Convert.ToDouble(textBox1tk.Text);
                if (tk <= 0 || k <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }

            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;


            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k);
            }
            DrawGraph(pane);
            legend = $"k={textBox1k.Text} tk={textBox1tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            double k;
            double t1;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox2k.Text);
                t1 = Convert.ToDouble(textBox2t1.Text);
                tk = Convert.ToDouble(textBox2tk.Text);
                if (tk <= 0 || k <= 0 || t1 <= 0) throw new Exception();

            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k * (1.0 - Math.Exp(-i / t1)));
            }
            DrawGraph(pane);
            legend = $"k={textBox2k.Text} T={textBox2t1.Text} tk={textBox2tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double k;
            double t1;
            double t2;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox3k.Text);
                t1 = Convert.ToDouble(textBox3t1.Text);
                t2 = Convert.ToDouble(textBox3t2.Text);
                tk = Convert.ToDouble(textBox3tk.Text);
                if (tk <= 0 || k <= 0 || t1 <= 0 || t2 <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            double t3, t4;
            t3 = t1 / 2.0 + Math.Sqrt(Math.Pow(t1, 2) / 4.0 - Math.Pow(t2, 2));
            t4 = t1 / 2.0 - Math.Sqrt(Math.Pow(t1, 2) / 4.0 - Math.Pow(t2, 2));
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();
            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k * (1.0 - t3 / (t3 - t4) * Math.Exp(-i / t3) + t4 / (t3 - t4) * Math.Exp(-i / t4)));
            }
            DrawGraph(pane);
            legend = $"k={textBox3k.Text} T1={textBox3t1.Text} T2={textBox3t2.Text} tk={textBox3tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double k;
            double t1;
            double t2;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox4k.Text);
                t1 = Convert.ToDouble(textBox4t1.Text);
                t2 = Convert.ToDouble(textBox4t2.Text);
                tk = Convert.ToDouble(textBox4tk.Text);
                if (tk <= 0 || k <= 0 || t1 <= 0 || t2 <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            double xi;
            xi = t1 / (2.0 * t2);
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k * (1.0 - Math.Exp((-xi * i) / t2) * (Math.Cos(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2) + xi / (Math.Sqrt(1.0 - Math.Pow(xi, 2))) * Math.Sin(i * Math.Sqrt(1.0 - Math.Pow(xi, 2)) / t2))));
            }
            DrawGraph(pane);
            legend = $"k={textBox4k.Text} T1={textBox4t1.Text} T2={textBox4t2.Text} tk={textBox4tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double k;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox5k.Text);
                tk = Convert.ToDouble(textBox5tk.Text);
                if (tk <= 0 || k <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k * i);
            }
            DrawGraph(pane);
            legend = $"k={textBox5k.Text} tk={textBox5tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double k;
            double t1;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox6k.Text);
                t1 = Convert.ToDouble(textBox6t1.Text);
                tk = Convert.ToDouble(textBox6tk.Text);
                if (tk <= 0 || k <= 0 || t1 <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k * (i - t1 * (1.0 - Math.Exp(-i / t1))));
            }
            DrawGraph(pane);
            legend = $"k={textBox6k.Text} T={textBox6t1.Text} tk={textBox6tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double k;
            double t1;
            double tk;
            try
            {
                k = Convert.ToDouble(textBox7k.Text);
                t1 = Convert.ToDouble(textBox7t1.Text);
                tk = Convert.ToDouble(textBox7tk.Text);
                if (tk <= 0 || k <= 0 || t1 <= 0) throw new Exception();
            }
            catch (Exception)
            {
                Form_error f = new Form_error();
                f.ShowDialog();
                return;
            }
            double Dt;
            if (Data.Dt != 0) Dt = Data.Dt;
            else Dt = tk / 1000;
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            list_1 = new PointPairList();

            for (double i = 0; i < tk; i += Dt)
            {
                list_1.Add(i, k / t1 * Math.Exp(-i / t1));
            }
            DrawGraph(pane);
            legend = $"k={textBox7k.Text} T={textBox7t1.Text} tk={textBox7tk.Text}";
            Data.list1 = list_1;
            Data.legend1 = legend;
            Data.title1 = "График переходной характеристики";
            Data.Ytitle1 = "h(t)";
            Data.Xtitle1 = "t";
        }
    }
}
