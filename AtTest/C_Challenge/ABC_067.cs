using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_067
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            long[] sums = new long[n];
            sums[0] = array[0];
            for(int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + array[i];
            }

            long allSum = sums[n - 1];
            long min = long.MaxValue;
            for (int i = 0; i < n - 1; i++)
            {
                long val = Math.Abs(allSum - sums[i] * 2);
                if (val < min)
                {
                    min = val;
                }
            }
            Console.WriteLine(min);
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
