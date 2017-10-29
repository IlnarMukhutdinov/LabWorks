using System;

namespace Lab3_CM
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            Console.Write("Введите начальное приближение x0 = ");
            double xprev = double.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введите начальное приближение y0 = ");
            double yprev = double.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введите начальное приближение z0 = ");
            double zprev = double.Parse(Console.ReadLine());
            Console.Write("\n");

            int count = 1;
            Console.WriteLine("\t K  |x(K)      |x(K+1)    |y(K)      |y(K+1)    |z(K)      |z(K+1)    |E    ");
            for (; count < 1000; count++)
            {
                config.XFormula(xprev, yprev, zprev);
                config.YFormula(xprev, yprev, zprev);
                config.ZFormula(xprev, yprev, zprev);

                Console.WriteLine("\t {0:D2} |{1, -10:F4}|{2, -10:F4}|{3, -10:F4}|{4, -10:F4}|{5, -10:F4}|{6, -10:F4}|{7, -10:F5}       ", 
                    count, xprev, config.xnext, yprev, config.ynext, zprev, config.znext, config.Condition(config.xnext, config.ynext, config.znext, xprev, yprev, zprev));

                if (config.IsEndCondition1(config.xnext, config.ynext, config.znext, xprev, yprev, zprev))
                    break;
                xprev = config.xnext;
                yprev = config.ynext;
                zprev = config.znext;
            }
            
            Console.ReadKey();
        }

    }
}
