using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day1
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] nab = ReadLongs();
            long n = nab[0];
            long a = nab[1];
            long b = nab[2];
            List<long> ds = new List<long>();
            ds.Add(0);
            if (b > 0) ds.AddRange(ReadLongs());
            ds.Add(n + 1);
            ds.Sort();

            long cnt = 0;
            for (int i = 1; i < ds.Count; i++)
            {
                long remain = ds[i] - ds[i - 1] - 1;
                cnt += (remain + 1) / a - 1;
                if ((remain + 1) % a > 0) cnt++;
            }

            WriteLine(n - cnt - b);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
