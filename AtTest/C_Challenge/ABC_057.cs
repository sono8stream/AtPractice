using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_057
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            double rn = Math.Sqrt(n);
            for (long i = (long)rn; i >=1; i--)
            {
                if (n % i != 0) continue;

                long b = n / i;
                int digit = (int)Math.Log10(b) + 1;
                Console.WriteLine(digit);
                return;
            }
        }
    }
}
