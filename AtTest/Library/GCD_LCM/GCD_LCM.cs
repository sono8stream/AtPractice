using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.GCD_LCM
{
    class GCD_LCM
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            Console.WriteLine(GCD(63,27));
            Console.WriteLine(LCM(63, 27));
        }

        static long GCD(long a,long b)
        {
            if (b > a)
            {
                long temp = b;
                b=a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a,long b)
        {
            long c = GCD(a, b);
            return a * b / c;
        }
    }
}
