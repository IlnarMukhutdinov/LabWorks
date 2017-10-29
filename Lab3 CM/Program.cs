using System;

namespace Lab3_CM
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            Console.Write("Введите начальное приближение x0 = ");
            double x0 = double.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введите начальное приближение y0 = ");
            double y0 = double.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введите начальное приближение z0 = ");
            double z0 = double.Parse(Console.ReadLine());
            Console.Write("\n");

            double xprev = x0, yprev = y0, zprev = z0;
            
            Console.WriteLine("Метод простых итераций для e = 0.001\n");
            Console.WriteLine("\t K  |x(K)      |x(K+1)    |y(K)      |y(K+1)    |z(K)      |z(K+1)    |E    ");
            for (int count = 1; count < 100; count++)
            {
                config.XFormula(yprev, zprev);
                config.YFormula(xprev, zprev);
                config.ZFormula(xprev, yprev);
                
                Console.WriteLine("\t {0, 2:D1} |{1, -10:F4}|{2, -10:F4}|{3, -10:F4}|{4, -10:F4}|{5, -10:F4}|{6, -10:F4}|{7, -10:F5}       ", 
                    count, xprev, config.xnext, yprev, config.ynext, zprev, config.znext, config.Condition(config.xnext, config.ynext, config.znext, xprev, yprev, zprev));

                if (config.IsEndCondition1(config.xnext, config.ynext, config.znext, xprev, yprev, zprev))
                    break;
                xprev = config.xnext;
                yprev = config.ynext;
                zprev = config.znext;
            }

            xprev = x0;
            yprev = y0;
            zprev = z0;

            Console.WriteLine("\nМетод Зейделя для e = 0.001\n");
            Console.WriteLine("\t K  |x(K)      |x(K+1)    |y(K)      |y(K+1)    |z(K)      |z(K+1)    |E    ");

            
            for (int count = 1; count < 100; count++)
            {
                double xnext = config.XFormula(yprev, zprev);
                double ynext = config.YFormula(xnext, zprev);
                config.ZFormula(xnext, ynext);

                Console.WriteLine("\t {0:D2} |{1, -10:F4}|{2, -10:F4}|{3, -10:F4}|{4, -10:F4}|{5, -10:F4}|{6, -10:F4}|{7, -10:F5}       ",
                    count, xprev, config.xnext, yprev, config.ynext, zprev, config.znext, config.Condition(config.xnext, config.ynext, config.znext, xprev, yprev, zprev));

                if (config.IsEndCondition1(config.xnext, config.ynext, config.znext, xprev, yprev, zprev))
                    break;
                xprev = xnext;
                yprev = ynext;
                zprev = config.znext;
            }

            xprev = x0;
            yprev = y0;
            zprev = z0;

            Console.WriteLine("Метод простых итераций для e = 0.00001\n");
            Console.WriteLine("\t K  |x(K)      |x(K+1)    |y(K)      |y(K+1)    |z(K)      |z(K+1)    |E    ");
            for (int count = 1; count < 100; count++)
            {
                config.XFormula(yprev, zprev);
                config.YFormula(xprev, zprev);
                config.ZFormula(xprev, yprev);

                Console.WriteLine("\t {0, 2:D1} |{1, -10:F4}|{2, -10:F4}|{3, -10:F4}|{4, -10:F4}|{5, -10:F4}|{6, -10:F4}|{7, -10:F5}       ",
                    count, xprev, config.xnext, yprev, config.ynext, zprev, config.znext, config.Condition(config.xnext, config.ynext, config.znext, xprev, yprev, zprev));

                if (config.IsEndCondition2(config.xnext, config.ynext, config.znext, xprev, yprev, zprev))
                    break;
                xprev = config.xnext;
                yprev = config.ynext;
                zprev = config.znext;
            }

            xprev = x0;
            yprev = y0;
            zprev = z0;

            Console.WriteLine("\nМетод Зейделя для e = 0.00001\n");
            Console.WriteLine("\t K  |x(K)      |x(K+1)    |y(K)      |y(K+1)    |z(K)      |z(K+1)    |E    ");


            for (int count = 1; count < 100; count++)
            {
                double xnext = config.XFormula(yprev, zprev);
                double ynext = config.YFormula(xnext, zprev);
                config.ZFormula(xnext, ynext);

                Console.WriteLine("\t {0:D2} |{1, -10:F4}|{2, -10:F4}|{3, -10:F4}|{4, -10:F4}|{5, -10:F4}|{6, -10:F4}|{7, -10:F5}       ",
                    count, xprev, config.xnext, yprev, config.ynext, zprev, config.znext, config.Condition(config.xnext, config.ynext, config.znext, xprev, yprev, zprev));

                if (config.IsEndCondition2(config.xnext, config.ynext, config.znext, xprev, yprev, zprev))
                    break;
                xprev = xnext;
                yprev = ynext;
                zprev = config.znext;
            }

            Console.ReadKey();
        }

    }
}
