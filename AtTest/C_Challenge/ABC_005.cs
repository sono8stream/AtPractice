using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_005
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            var aArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                aArray[i] = int.Parse(input[i]);
            }
            int m = int.Parse(Console.ReadLine());
            input = Console.ReadLine().Split(' ');
            var bArray = new int[m];
            for (int i = 0; i < m; i++)
            {
                bArray[i] = int.Parse(input[i]);
            }

            int bArrayNow = 0;
            int minTime = bArray[bArrayNow] - t;
            for (int i = 0; i < n; i++)
            {
                if (aArray[i] >= minTime && aArray[i] <= bArray[bArrayNow])
                {
                    bArrayNow++;
                    if (bArrayNow == m)
                    {
                        Console.WriteLine("yes");
                        return;
                    }
                    minTime = bArray[bArrayNow] - t;
                }
            }

            Console.WriteLine("no");
        }
    }
}
