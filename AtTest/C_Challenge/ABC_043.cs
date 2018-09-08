using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_043
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var array = new int[n];
            string[] input = Console.ReadLine().Split(' ');
            int average = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
                average += array[i];
            }
            average /= n;
            int cost0 = 0, cost1 = 0, cost2 = 0;
            for (int i = 0; i < n; i++)
            {
                cost0 += (average - array[i])
                    * (average - array[i]);
                cost1 += (average + 1 - array[i])
                    * (average + 1 - array[i]);
                cost2 += (average - 1 - array[i])
                    * (average - 1 - array[i]);
            }
            if (cost0 < cost1 && cost0 < cost2)
            {
                Console.WriteLine(cost0);
            }
            else if (cost1 < cost0 && cost1 < cost2)
            {
                Console.WriteLine(cost1);
            }
            else
            {
                Console.WriteLine(cost1);
            }
        }
    }
}
