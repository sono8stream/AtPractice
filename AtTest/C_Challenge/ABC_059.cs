using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_059
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            var array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(input[i]);
            }

            long sum = 0;
            bool plus = true;
            long firstPlusCnt = 0;
            for(int i = 0; i < n; i++)
            {
                sum += array[i];
                if (plus && sum <= 0)
                {
                    firstPlusCnt += 1-sum;
                    sum = 1;
                }
                else if (!plus && 0 <= sum)
                {
                    firstPlusCnt += 1 + sum;
                    sum = -1;
                }
                plus = !plus;
            }

            sum = 0;
            plus = false;
            long firstMinusCnt = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                if (plus && sum <= 0)
                {
                    firstMinusCnt += 1-sum;
                    sum = 1;
                }
                else if (!plus && 0 <= sum)
                {
                    firstMinusCnt += 1 + sum;
                    sum = -1;
                }
                plus = !plus;
            }

            if (firstPlusCnt < firstMinusCnt)
            {
                Console.WriteLine(firstPlusCnt);
            }
            else
            {
                Console.WriteLine(firstMinusCnt);
            }
        }
    }
}
