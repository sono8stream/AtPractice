using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_056
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long x = long.Parse(Console.ReadLine());
            long min = 0, max = 100000;
            while (max - min != 1)
            {
                long mid = (min + max) / 2;
                long sum = (mid * (mid + 1)) / 2;
                long sum2 = ((mid - 1) * mid) / 2;
                if (sum2 < x && x <= sum)
                {
                    Console.WriteLine(mid);
                    return;
                }
                else if (x <= sum2)
                {
                    max = mid;
                }
                else if (sum < x)
                {
                    min = mid;
                }
            }
            Console.WriteLine(min);
        }
    }
}