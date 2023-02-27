using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace TAU_Complex
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public static bool DtCheck(double t, double Dt)
        {
            try
            {
                if (t / Dt >= 100000) throw new Exception();
                return false;
            }
            catch (Exception)
            {
                Form_error f = new Form_error("Уменьшите шаг дискретизации Dt \rили конечное время построения tk");
                f.ShowDialog();
                return true;
            }
        }

    }
}
