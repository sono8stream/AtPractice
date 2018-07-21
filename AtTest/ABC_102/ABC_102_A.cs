using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_102
{
    class ABC_102_A
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long val = 0;
            if (n % 2 == 0)
            {
                val = n;
            }
            else
            {
                val = n * 2;
            }
            Console.WriteLine(val);
        }
    }
}
