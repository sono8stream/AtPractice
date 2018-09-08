using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_061
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
            long k = long.Parse(input[1]);
            var array = new long[100000];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ');
                int a= int.Parse(input[0]);
                long b = long.Parse(input[1]);
                array[a-1] += b;
            }

            long cnt = 0;
            for(int i = 0; i < 100000; i++)
            {
                cnt += array[i];
                if (k <= cnt)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
