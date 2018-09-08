using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_108
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            long zeroCnt = 0, halfCnt = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % k == 0) zeroCnt++;
                if (i % k == k / 2) halfCnt++;
            }
            if (k % 2 != 0) halfCnt = 0;

            Console.WriteLine(zeroCnt * zeroCnt * zeroCnt
                + halfCnt * halfCnt * halfCnt);
        }
    }
}
