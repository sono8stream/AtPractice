using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_102
{
    class ABC_102_D
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            long[] array = new long[n];
            long[] sums = new long[n];//累積和
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
                if (i == 0)
                {
                    sums[i] = array[i];
                }
                else
                {
                    sums[i] = sums[i - 1] + array[i];
                }
            }

            long min = 0;
            int leftIndex = 0, rightIndex = 2;
            long[] rangeSums = new long[4];
            for (int i = 2; i < n - 1; i++)//真ん中の区切り数ループ
            {
                while (leftIndex < i - 1
                    && Math.Abs(sums[i - 1] - 2 * sums[leftIndex + 1])
                    < Math.Abs(sums[i - 1] - 2 * sums[leftIndex]))
                {
                    leftIndex++;
                }
                while (rightIndex < n - 1
                    && Math.Abs(sums[n - 1] - 2 * sums[rightIndex + 1] + sums[i - 1])
                    < Math.Abs(sums[n - 1] - 2 * sums[rightIndex] + sums[i - 1]))
                {
                    rightIndex++;
                }
                rangeSums[0] = sums[leftIndex];
                rangeSums[1] = sums[i - 1] - sums[leftIndex];
                rangeSums[2] = sums[rightIndex] - sums[i - 1];
                rangeSums[3] = sums[n - 1] - sums[rightIndex];
                Array.Sort(rangeSums);
                if (i == 2 || rangeSums[3] - rangeSums[0] < min)
                {
                    min = rangeSums[3] - rangeSums[0];
                }
            }

            Console.WriteLine(min);
        }
    }
}
