using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_054
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long n = long.Parse(input[0]);
            long m = long.Parse(input[1]);
            long allCnt = 0;
            if (n * 2 > m)
            {
                allCnt = m / 2;
            }
            else
            {
                allCnt = n;
                allCnt += (m - n * 2) / 4;
            }
            Console.WriteLine(allCnt);
        }
    }
}
