using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
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
                if (t / Dt >= 10000000) throw new Exception();
                return false;
            }
            catch (Exception)
            {
                Form_error f = new Form_error("Уменьшите шаг дискретизации Dt \rили конечное время построения tk");
                f.ShowDialog();
                return true;
            }
        }
        public static void SetDt(double tk, List<double> listT)
        {
            switch (Data.TypeDt)
            {
                case 1: Data.Dt = tk / 10000; break;
                case 2:
                    try
                    {
                        Data.Dt = listT.Min() / 100;
                        break;
                    }
                    catch (Exception)
                    {
                        Form_error f = new Form_error();
                        f.ShowDialog();
                        return;
                    }

                case 3: break; // Присваивание Dt произошло в options                
            }

        }

    }
}
