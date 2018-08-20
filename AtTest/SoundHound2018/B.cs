
using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
{
    class B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            var array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(Console.ReadLine());
            }

            var sums = Sums(array, n, k);
            int minIndex = MinIndex(sums);
            while (sums[minIndex] < 0)
            {
                for (int i = 0; i < k; i++)
                {
                    array[minIndex + i] = 0;
                }
                sums = Sums(array, n, k);
                minIndex = MinIndex(sums);
            }

            long sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum += array[i];
            }
            Console.WriteLine(sum);
        }

        static long[] Sums(long[] array,int n,int k)
        {
            int nn = n - k + 1;
            var newSums = new long[nn];
            newSums[0] = 0;
            for (int i = 0; i < k; i++)
            {
                newSums[0] += array[i];
            }
            for (int i = 1; i < nn; i++)
            {
                newSums[i] = newSums[i - 1] + array[i + k - 1] - array[i - 1];
            }
            return newSums;
        }

        static int MinIndex(long[] array)
        {
            int index = 0;
            for(int i = 1; i < array.Length; i++)
            {
                if(array[i]< array[index])
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
