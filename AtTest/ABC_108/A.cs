using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_108
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int odd = (k + 1) / 2;
            int even = k / 2;
            Console.WriteLine(odd * even);
        }
    }
}
