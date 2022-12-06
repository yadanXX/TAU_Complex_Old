using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAU_Complex
{
    public static class Wlink
    {
        public static double NonEnertion(double xv, double k)
        {
            return xv * k;
        }
        public static (double, double, double) Integrating(double xv, double k, double T, double x1, double x2, double Dt)
        {
            /* xv - вход
             * k - коэф усиления
             * T - постоянная времени
             * x1 - предыдущий выход1(промежуточный), после изменения текущий1
             * x2 - предыдущий выход2(промежуточный), после изменения текущий2 x'
             * Dt - дельта t
             * x3 - выход1'' (промежуточный производный)
             * x - выход
             */
            double x, x3;
            x3 = xv - x2;
            x2 = x2 + (x3 * Dt) / T;
            x1 = x1 + x2 * Dt;
            x = k * x1;
            return (x, x1, x2);
        }
        public static (double, double) Aperiodic(double xv, double k, double T, double x1, double Dt)
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
        public static (double, double) Exodrom(double xv, double k, double T0, double T1, double xi1, double Dt)
        {
            /* xv - вход
            * k - коэф усиления
            * T0,T1 - постоянная времени
            * xi1 - предыдущий выход1(промежуточный), после изменения текущий1
            * Dt - дельта t
            * x - выход
            */
            double x;
            xi1 = xi1 + xv * Dt / T1;
            x = xi1 + xv * T0 / T1 * k;
            return (x, xi1);
        }
        public static (double, double) Difdelay(double xv, double k, double T0, double T1, double xi1, double Dt)
        {
            /* xv - вход
            * k - коэф усиления
            * T0,T1 - постоянная времени
            * xi1 - предыдущий выход1(промежуточный), после изменения текущий1
            * Dt - дельта t
            * x - выход
            */
            double x;
            x = (xv - xi1) / T0 * T1 * k;
            xi1 = xi1 + (xv - xi1) / T0 * Dt;
            return (x, xi1);
        }

    }
}
