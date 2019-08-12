using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
{
    class B
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] mnk = ReadInts();
            int m = mnk[0];
            int n = mnk[1];
            int k = mnk[2];
            int[] xs = ReadInts();

            int res = 0;
            for(int i = 1; i <= m; i++)
            {
                var remain = new HashSet<int>();
                for(int j = 1; j <= k; j++)
                {
                    remain.Add(j);
                }

                int tmp = 0;
                for(int j = 0; j < n; j++)
                {
                    int delta = Abs(xs[j] - i);
                    if (delta == 0)
                    {
                        tmp++;
                    }
                    else if (remain.Contains(delta))
                    {
                        tmp++;
                        remain.Remove(delta);
                    }
                }
                res = Max(res, tmp);
            }
            WriteLine(res);
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
