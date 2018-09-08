using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_060
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
            long t = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var ts = new long[n];
            for (int i = 0; i < n; i++)
            {
                ts[i] = long.Parse(input[i]);
            }

            long allTime = 0;
            long initIndex = 0;
            for(int i = 1; i < n; i++)
            {
                if (ts[i - 1] + t < ts[i])
                {
                    allTime += ts[i - 1] + t - ts[initIndex];
                    initIndex = i;
                }
            }
            allTime += ts[n - 1] + t - ts[initIndex];

            Console.WriteLine(allTime);
        }
    }
}
