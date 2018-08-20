using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class ABC_055_B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int div = 1000000000 + 7;
            long pow = 1;
            for (int i = 1; i <= n; i++)
            {
                pow *= i;
                pow %= div;
            }
            Console.WriteLine(pow);
        }
    }
}
