using System;
using System.Runtime.Remoting.Messaging;

#pragma warning disable 1587
/// <summary>
/// <param name = "xnext">Следующее приближение переменной x</param>
/// <param name = "x0">Текущее приближение переменной x</param>
/// <param name = "ynext">Следующее приближение переменной y</param>
/// <param name = "y0">Текущее приближение переменной y</param>
/// <param name = "znext">Следующее приближение переменной z</param>
/// <param name = "z0">Текущее приближение переменной z</param>
/// <param name = "Beta">Свободный член</param>
/// <param name = "Alpha">Коэффициент перед переменными</param>
/// <param name = "Epsilon">Точность</param>
/// </summary>
#pragma warning restore 1587
namespace Lab3_CM
{
    class Configuration
    {
        public const double
            Epsilon1 = 0.001,
            Epsilon2 = 0.00001;

        public double
            xnext,
            ynext,
            znext;

        public const double
            Beta1 = -0.33333333,
            Beta2 = 1,
            Beta3 = 0.5;

        public const double
            Alpha12 = 0.3333333333,
            Alpha13 = 0.3333333333,
            Alpha21 = 0.5,
            Alpha23 = 0.25,
            Alpha31 = -0.333333,
            Alpha32 = -0.5;

        public double XFormula(double x0, double y0, double z0)
        {
            return xnext = Beta1 + Alpha12 * y0 + Alpha13 * z0;
        }

        public double YFormula(double x0, double y0, double z0)
        {
            return ynext = Beta2 + Alpha21 * x0 + Alpha23 * z0;
        }

        public double ZFormula(double x0, double y0, double z0)
        {
            return znext = Beta3 + Alpha31 * x0 + Alpha32 * y0;
        }

        public bool IsEndCondition1(double xnext, double ynext, double znext, double xprev, double yprev, double zprev)
        {
            return Math.Abs(xnext - xprev) + Math.Abs(ynext - yprev) + Math.Abs(znext - zprev) <= Epsilon1;
        }
        public bool IsEndCondition2(double xnext, double ynext, double znext, double xprev, double yprev, double zprev)
        {
            return Math.Abs(xnext - xprev) + Math.Abs(ynext - yprev) + Math.Abs(znext - zprev) <= Epsilon2;
        }

        public double Condition(double xnext, double ynext, double znext, double xprev, double yprev, double zprev)
        {
            return Math.Abs(xnext - xprev) + Math.Abs(ynext - yprev) + Math.Abs(znext - zprev);
        }
    }
}
