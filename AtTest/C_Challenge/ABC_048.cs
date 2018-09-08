using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_048
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
            long x = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(input[i]);
            }

            long cnt = 0;
            for(int i = 1; i < n; i++)
            {
                long sum = array[i - 1] + array[i];
                if (sum <= x) continue;

                long margin = sum - x;
                if (array[i] >= margin)
                {
                    array[i] -= margin;
                }
                else
                {
                    array[i - 1] -= margin - array[i];
                    array[i] = 0;
                }
                cnt += margin;
            }
            Console.WriteLine(cnt);
        }
    }
}
