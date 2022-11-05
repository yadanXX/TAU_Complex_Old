using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TAU_Complex
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public double f(double x)
        {
            string input = ("вход"); // строка которую нужно разобрать
            org.mariuszgromada.math.mxparser.Function f = new org.mariuszgromada.math.mxparser.Function(input); // создаем функцию

            double result;

            return result = f.calculate(x);

        }
    }
}
