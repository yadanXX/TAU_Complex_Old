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
using System.CodeDom.Compiler;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TAU_Complex
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            Data.active_value = 14;
            zedGraphControl1.GraphPane.Title.Text = "График переходной характиристики";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Qвых(t)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";
            radioButtonBlock_CheckedChanged(null, null);
            pictureBoxDiagram.Image = Properties.Resources.разомкнутое_апериодическое;

        }

        delegate (double, double) Filter(double xv, double k, double T, double x1, double Dt);
        private static Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            string legend = "";
            double kf = 0, Tf = 0;
            double wvf, tempf = 0;

            Filter filter = delegate (double xv, double k, double T, double x1, double Dt) // анонимное объявление функции для глобалтно определённого делагата Filter
            {
                return (xv, 0);
            };

            if (checkBoxFilter.Checked)
            {
                filter = Wlink.Aperiodic; // переопределение делегата на другую функцию

                try
                {
                    kf = Convert.ToDouble(textBoxkf.Text.Replace(".", ","));
                    Tf = Convert.ToDouble(textBoxTf.Text.Replace(".", ","));
                    legend += $"Kf = {kf} Tf = {Tf} ";
                    if (kf <= 0 || Tf <= 0) throw new Exception();
                }
                catch (Exception)
                {
                    Form_error f = new Form_error();
                    f.ShowDialog();
                    return;
                }
            }

            if (radioButtonRaz.Checked)
            {
                if (radioButtonAper.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;

                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu <= 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double xv = 1;
                    double wv1, wv2, temp1 = 0, temp2 = 0;

                    for (double i = 0; i < tk; i += Dt)
                    {
                        (wvf, tempf) = filter(xv, kf, Tf, tempf, Dt);
                        (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);
                        (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                        list_1.Add(i, wv2);
                    }

                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
                else if (radioButtonOsci.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;
                    double ξ, ξ1;
                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        ξ = Convert.ToDouble(textBoxξ.Text.Replace(".", ","));
                        ξ1 = Convert.ToDouble(textBoxξ1.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu} ξ = {ξ} ξ₁ = {ξ1}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu < 0 || ξ < 0 || ξ1 < 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu, ξ, ξ1 });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double xv = 1;
                    double temp111 = 0, temp112 = 0, temp121 = 0, temp122 = 0, temp131 = 0, temp132 = 0, temp21 = 0, temp22 = 0;
                    double wv111, wv112, wv121, wv122, wv131, wv132, wv2;

                    for (double i = 0; i < tk; i += Dt)
                    {
                        (wvf, tempf) = filter(xv, kf, Tf, tempf, Dt);

                        (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                        (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                        (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                        (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                        (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                        (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                        (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                        list_1.Add(i, wv2);

                    }

                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
            }
            else if (radioButtonVoz.Checked)
            {
                if (radioButtonAper.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;

                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu <= 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double xv = 1;
                    double wv1, wv2, temp1 = 0, temp2 = 0;

                    double invTime, amplit, freq, pointCounter, mathEx, disper;

                    switch (comboBoxOutRage.SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {

                                (wvf, tempf) = filter(xv - outRageStep(amplit, invTime, i), kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);
                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2 += outRageStep(amplit, invTime, i);
                                list_1.Add(i, wv2);
                            }
                            break;

                        case 1:

                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                freq = Convert.ToDouble(textBoxFrequency.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0 || freq <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {

                                (wvf, tempf) = filter(xv - outRageSin(amplit, freq, i, invTime), kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);
                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2 += outRageSin(amplit, freq, i, invTime);
                                list_1.Add(i, wv2);
                            }
                            break;

                        case 2:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                pointCounter = Convert.ToDouble(textBoxPointCount.Text.Replace(".", ","));
                                mathEx = Convert.ToDouble(textBoxExpect.Text.Replace(".", ","));
                                disper = Convert.ToDouble(textBoxDispertion.Text.Replace(".", ","));
                                if (invTime <= 0 || pointCounter <= 0 || disper <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            double outRageRand = 0;
                            double randFreq = (tk - invTime) / pointCounter;
                            double randCurStage = invTime;

                            for (double i = 0; i < tk; i += Dt)
                            {
                                if (i >= randCurStage)
                                {
                                    outRageRand = NextGaussian(mathEx, disper);
                                    randCurStage += randFreq;
                                }

                                (wvf, tempf) = filter(xv - outRageRand, kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);
                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2 += outRageRand;
                                list_1.Add(i, wv2);
                            }
                            break;
                    }

                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
                else if (radioButtonOsci.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;
                    double ξ, ξ1;
                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        ξ = Convert.ToDouble(textBoxξ.Text.Replace(".", ","));
                        ξ1 = Convert.ToDouble(textBoxξ1.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu} ξ = {ξ} ξ₁ = {ξ1}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu < 0 || ξ < 0 || ξ1 < 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu, ξ, ξ1 });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double invTime, amplit, freq, pointCounter, mathEx, disper;

                    double xv = 1;
                    double temp111 = 0, temp112 = 0, temp121 = 0, temp122 = 0, temp131 = 0, temp132 = 0, temp21 = 0, temp22 = 0;
                    double wv111, wv112, wv121, wv122, wv131, wv132, wv2;

                    switch (comboBoxOutRage.SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {
                                (wvf, tempf) = filter(xv - outRageStep(amplit, invTime, i), kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2 += outRageStep(amplit, invTime, i);

                                list_1.Add(i, wv2);
                            }
                            break;

                        case 1:

                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                freq = Convert.ToDouble(textBoxFrequency.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0 || freq <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {
                                (wvf, tempf) = filter(xv - outRageSin(amplit, freq, i, invTime), kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2 += outRageSin(amplit, freq, i, invTime);

                                list_1.Add(i, wv2);
                            }
                            break;

                        case 2:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                pointCounter = Convert.ToDouble(textBoxPointCount.Text.Replace(".", ","));
                                mathEx = Convert.ToDouble(textBoxExpect.Text.Replace(".", ","));
                                disper = Convert.ToDouble(textBoxDispertion.Text.Replace(".", ","));
                                if (invTime <= 0 || pointCounter <= 0 || disper <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            double outRageRand = 0;
                            double randFreq = (tk - invTime) / pointCounter;
                            double randCurStage = invTime;

                            for (double i = 0; i < tk; i += Dt)
                            {
                                if (i >= randCurStage)
                                {
                                    outRageRand = NextGaussian(mathEx, disper);
                                    randCurStage += randFreq;
                                }

                                (wvf, tempf) = filter(xv - outRageRand, kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2 += outRageRand;

                                list_1.Add(i, wv2);
                            }
                            break;
                    }
                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
            }
            else if (radioButtonOtk.Checked)
            {
                if (radioButtonAper.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;

                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu <= 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double xv = 1;
                    double wv1, wv2 = 0, wv2pos = 0, temp1 = 0, temp2 = 0;

                    double invTime, amplit, freq, pointCounter, mathEx, disper;

                    switch (comboBoxOutRage.SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {
                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);

                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2pos = wv2;
                                wv2 += outRageStep(amplit, invTime, i);
                                list_1.Add(i, wv2);
                            }
                            break;

                        case 1:

                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                freq = Convert.ToDouble(textBoxFrequency.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0 || freq <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {

                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);

                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2pos = wv2;
                                wv2 += outRageSin(amplit, freq, i, invTime);
                                list_1.Add(i, wv2);
                            }
                            break;

                        case 2:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                pointCounter = Convert.ToDouble(textBoxPointCount.Text.Replace(".", ","));
                                mathEx = Convert.ToDouble(textBoxExpect.Text.Replace(".", ","));
                                disper = Convert.ToDouble(textBoxDispertion.Text.Replace(".", ","));
                                if (invTime <= 0 || pointCounter <= 0 || disper <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            double outRageRand = 0;
                            double randFreq = (tk - invTime) / pointCounter;
                            double randCurStage = invTime;

                            for (double i = 0; i < tk; i += Dt)
                            {
                                if (i >= randCurStage)
                                {
                                    outRageRand = NextGaussian(mathEx, disper);
                                    randCurStage += randFreq;
                                }


                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);
                                (wv1, temp1) = Wlink.PropDifDelay(wvf, 1 / k1, Tnu, T1, temp1, Dt);

                                (wv2, temp2) = Wlink.Aperiodic(wv1, k, T, temp2, Dt);
                                wv2pos = wv2;
                                wv2 += outRageRand;
                                list_1.Add(i, wv2);
                            }
                            break;
                    }

                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
                else if (radioButtonOsci.Checked)
                {
                    double k1, k;
                    double T1, T, Tnu;
                    double tk;
                    double ξ, ξ1;
                    try
                    {
                        k1 = Convert.ToDouble(textBoxk1.Text.Replace(".", ","));
                        k = Convert.ToDouble(textBoxk.Text.Replace(".", ","));
                        T1 = Convert.ToDouble(textBoxT1.Text.Replace(".", ","));
                        T = Convert.ToDouble(textBoxT.Text.Replace(".", ","));
                        Tnu = Convert.ToDouble(textBoxTnu.Text.Replace(".", ","));
                        tk = Convert.ToDouble(textBoxtk.Text.Replace(".", ","));
                        ξ = Convert.ToDouble(textBoxξ.Text.Replace(".", ","));
                        ξ1 = Convert.ToDouble(textBoxξ1.Text.Replace(".", ","));
                        legend += $"K1 = {k1} K = {k} T1 = {T1} T = {T} Tν = {Tnu} ξ = {ξ} ξ₁ = {ξ1}";
                        if (k1 <= 0 || k <= 0 || T1 <= 0 || T <= 0 || tk <= 0 || Tnu < 0 || ξ < 0 || ξ1 < 0) throw new Exception();
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                    Program.SetDt(tk, new List<double>() { T1, T, Tnu, ξ, ξ1 });
                    double Dt = Data.Dt;
                    if (Program.DtCheck(tk, Dt)) return;

                    PointPairList list_1 = new PointPairList();

                    double invTime, amplit, freq, pointCounter, mathEx, disper;

                    double xv = 1;
                    double temp111 = 0, temp112 = 0, temp121 = 0, temp122 = 0, temp131 = 0, temp132 = 0, temp21 = 0, temp22 = 0;
                    double wv111, wv112, wv121, wv122, wv131, wv132, wv2 = 0;
                    double wv2pos = 0;

                    switch (comboBoxOutRage.SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {
                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2pos = wv2;

                                wv2 += outRageStep(amplit, invTime, i);

                                list_1.Add(i, wv2);
                            }
                            break;

                        case 1:

                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                amplit = Convert.ToDouble(textBoxAmplit.Text.Replace(".", ","));
                                freq = Convert.ToDouble(textBoxFrequency.Text.Replace(".", ","));
                                if (invTime <= 0 || amplit <= 0 || freq <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            for (double i = 0; i < tk; i += Dt)
                            {
                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2pos = wv2;

                                wv2 += outRageSin(amplit, freq, i, invTime);

                                list_1.Add(i, wv2);
                            }
                            break;

                        case 2:
                            try
                            {
                                invTime = Convert.ToDouble(textBoxInvTime.Text.Replace(".", ","));
                                pointCounter = Convert.ToDouble(textBoxPointCount.Text.Replace(".", ","));
                                mathEx = Convert.ToDouble(textBoxExpect.Text.Replace(".", ","));
                                disper = Convert.ToDouble(textBoxDispertion.Text.Replace(".", ","));
                                if (invTime <= 0 || pointCounter <= 0 || disper <= 0) throw new Exception();
                            }
                            catch (Exception)
                            {
                                Form_error f = new Form_error();
                                f.ShowDialog();
                                return;
                            }

                            double outRageRand = 0;
                            double randFreq = (tk - invTime) / pointCounter;
                            double randCurStage = invTime;

                            for (double i = 0; i < tk; i += Dt)
                            {
                                if (i >= randCurStage)
                                {
                                    outRageRand = NextGaussian(mathEx, disper);
                                    randCurStage += randFreq;
                                }

                                (wvf, tempf) = filter(xv + wv2pos - wv2, kf, Tf, tempf, Dt);

                                (wv111, temp111) = Wlink.Difdelay(wvf, 1 / k1, Tnu, T1, temp111, Dt);
                                (wv112, temp112) = Wlink.Difdelay(wv111, 1, Tnu, T1, temp112, Dt);

                                (wv121, temp121) = Wlink.Difdelay(wvf, ξ1, Tnu, T1, temp121, Dt);
                                (wv122, temp122) = Wlink.Aperiodic(wv121, 1 / k1, Tnu, temp122, Dt);

                                (wv131, temp131) = Wlink.Aperiodic(wvf, 1 / k1, Tnu, temp131, Dt);
                                (wv132, temp132) = Wlink.Aperiodic(wv131, 1, Tnu, temp132, Dt);

                                (wv2, temp21, temp22) = Wlink.Oscillatory(wv112 + wv122 + wv132, k, T, 2 * T * ξ, temp21, temp22, Dt);

                                wv2pos = wv2;

                                wv2 += outRageRand;

                                list_1.Add(i, wv2);
                            }
                            break;
                    }
                    DrawGraph(zedGraphControl1, list_1, "График переходной характиристики", "Qвых(t)", "t");

                    Data.list1 = list_1;
                    Data.legend1 = legend;
                    Data.title1 = "График переходной характеристики";
                    Data.Ytitle1 = "Qвых(t)";
                    Data.Xtitle1 = "t";
                }
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

        private void CloseAllPanel()
        {
            panelk.Visible = false;
            panelk1.Visible = false;
            panelk2.Visible = false;
            panelξ.Visible = false;
            panelξ1.Visible = false;
            paneltk.Visible = false;
            panelT.Visible = false;
            panelT1.Visible = false;
            panelT2.Visible = false;
            panelTnu.Visible = false;
        }

        private void radioButtonBlock_CheckedChanged(object sender, EventArgs e)
        {
            setDiagram();
            if (radioButtonAper.Checked)
            {
                CloseAllPanel();
                panelk.Visible = true;
                panelk1.Visible = true;
                panelT.Visible = true;
                panelT1.Visible = true;
                panelTnu.Visible = true;
                paneltk.Visible = true;
            }
            else if (radioButtonOsci.Checked)
            {
                CloseAllPanel();
                panelk.Visible = true;
                panelk1.Visible = true;
                panelT.Visible = true;
                panelT1.Visible = true;
                panelTnu.Visible = true;
                paneltk.Visible = true;
                panelξ.Visible = true;
                panelξ1.Visible = true;
            }

        }

        private void radioButtonDiagram_CheckedChanged(object sender, EventArgs e)
        {
            setDiagram();
            if (radioButtonVoz.Checked || radioButtonOtk.Checked)
            {
                panelOutRageWS.Visible = true;
                comboBoxOutRage.SelectedIndex = 0;
            }
            else
            {
                panelOutRageWS.Visible = false;
            }

        }

        private void setDiagram()
        {
            if (radioButtonAper.Checked)
            {
                if (radioButtonRaz.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.разомкнутое_апериодическое_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.разомкнутое_апериодическое;
                }
                if (radioButtonVoz.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.по_возмущению_апериодическое_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.по_возмущению_апериодическое;
                }
                if (radioButtonOtk.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.по_отклонению_апериодическое_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.по_отклонению_апериодическое;
                }
            }
            else
            {
                if (radioButtonRaz.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.разомкнутое_колебательное_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.разомкнутое_колебательное;
                }
                if (radioButtonVoz.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.по_возмущению_колебательное_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.по_возмущению_колебательное;
                }
                if (radioButtonOtk.Checked)
                {
                    if (checkBoxFilter.Checked) pictureBoxDiagram.Image = Properties.Resources.по_отклонению_колебательное_с_фильтром;
                    else pictureBoxDiagram.Image = Properties.Resources.по_отклонению_колебательное;
                }

            }
            pictureBoxDiagram.SizeMode = PictureBoxSizeMode.Zoom;

        }


        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            setDiagram();
            if (checkBoxFilter.Checked)
            {
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                textBoxkf.Visible = true;
                textBoxTf.Visible = true;
            }
            else
            {
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                textBoxkf.Visible = false;
                textBoxTf.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (checkBoxFilter.Checked) checkBoxFilter.Checked = false;
            else checkBoxFilter.Checked = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            radioButtonOsci.Checked = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            radioButtonAper.Checked = true;
        }

        private void comboBoxOutRage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxOutRage.SelectedIndex)
            {
                case 0:
                    HideOutRageText();
                    panelAmplit.Visible = true;
                    panelInvTime.Visible = true;
                    break;
                case 1:
                    HideOutRageText();
                    panelAmplit.Visible = true;
                    panelInvTime.Visible = true;
                    panelFrequency.Visible = true;
                    break;
                case 2:
                    HideOutRageText();
                    panelInvTime.Visible = true;
                    panelExpect.Visible = true;
                    panelDispertion.Visible = true;
                    panelPointCount.Visible = true;
                    break;
            }
        }

        private void HideOutRageText()
        {
            panelAmplit.Visible = false;
            panelDispertion.Visible = false;
            panelExpect.Visible = false;
            panelFrequency.Visible = false;
            panelInvTime.Visible = false;
            panelPointCount.Visible = false;
        }

        private double outRageStep(double amplit, double invTime, double time)
        {
            if (time >= invTime)
            {
                return amplit;
            }
            else return 0;
        }

        private double outRageSin(double amplit, double frequancy, double time, double invTime)
        {
            if (time >= invTime)
            {
                return amplit * Math.Sin(frequancy * time * 2.0 * Math.PI - invTime * 2.0 * Math.PI);
            }
            else return 0;
        }

        private static double NextGaussian(double mu, double sigma)
        {
            // рандом по нормальному закону 
            // mu - пик
            // sigma - разброс
            double rand_normal;
            // do
            // {
            //double mu = 0.5;
            // double sigma = mu / 3;
            var u1 = rnd.NextDouble();
            var u2 = rnd.NextDouble();
            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            rand_normal = mu + sigma * rand_std_normal;
            //} while (rand_normal < 0 || rand_normal > 1);
            return Math.Round(rand_normal, 1);
        }
    }
}

