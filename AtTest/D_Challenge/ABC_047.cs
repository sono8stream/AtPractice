using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_047
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nt = ReadLongs();
            int n = (int)nt[0];
            int[] array = ReadInts();
            var maxSellIndex = new int[n];
            maxSellIndex[n - 1] = n - 1;
            int maxSurplus = 0;
            for(int i = n - 2; i >= 0; i--)
            {
                if (array[maxSellIndex[i + 1]] < array[i])
                {
                    maxSellIndex[i] = i;
                }
                else
                {
                    maxSellIndex[i] = maxSellIndex[i + 1];
                }
                maxSurplus
                    = Math.Max(array[maxSellIndex[i]] - array[i], maxSurplus);
            }
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                int tmp = array[maxSellIndex[i]] - array[i];
                if (tmp == maxSurplus)
                {
                    res++;
                }
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
