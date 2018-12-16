using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_017
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            var fs = new int[n+1];
            for(int i = 0; i < n; i++)
            {
                fs[i] = ReadInt();
            }
            fs[n] = fs[n - 1];
            var sums = new long[n+1];
            sums[n] = 1;
            sums[n - 1] = 2;
            long res = 1;
            long mask = 1000000000 + 7;
            var dict = new Dictionary<int, bool>();
            dict.Add(fs[n - 1], true);
            for (int i = n - 2; i >= 0; i--)
            {
                long delta = 0;
                if (dict.ContainsKey(fs[i]))
                {
                    dict = new Dictionary<int, bool>();
                    dict.Add(fs[i], true);
                    delta = sums[i + 1];
                }
                else
                {
                    dict.Add(fs[i], true);
                    delta = sums[i + 1] + sums[i + 2];
                }
                res += delta;
                sums[i] = sums[i + 1] + delta;
                Console.WriteLine(delta + " " + sums[i]);
            }
            Console.WriteLine(res);
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
