using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_053
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long x = long.Parse(Console.ReadLine());
            int cycle = 11;
            long turnCnt = 0;
            turnCnt = x / cycle * 2;
            if (x % cycle > 0)
            {
                turnCnt += x % cycle > 6 ? 2 : 1;
            }
            Console.WriteLine(turnCnt);
        }
    }
}
