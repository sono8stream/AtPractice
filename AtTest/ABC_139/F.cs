using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_139
{
    class F
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
            int n = ReadInt();
            long[][] xys = new long[n][];
            for (int i = 0; i < n; i++) xys[i] = ReadLongs();
            var set = new Dictionary<long,HashSet<long>>();
            set.Add(0, new HashSet<long>());
            set[0].Add(0);
            for(int i = 0; i < n; i++)
            {
                var next = new Dictionary<long, HashSet<long>>();
                foreach(long x in set.Keys)
                {
                    if (!next.ContainsKey(x))
                    {
                        next.Add(x, new HashSet<long>());
                    }
                    long nextX = x + xys[i][0];
                    if (!next.ContainsKey(nextX))
                    {
                        next.Add(nextX, new HashSet<long>());
                    }
                    foreach (long y in set[x])
                    {
                        next[x].Add(y);
                        long nextY = y + xys[i][1];
                        next[nextX].Add(nextY);
                    }
                }
                set = next;
            }

            double res = 0;
            foreach(long x in set.Keys)
            {
                foreach(long y in set[x])
                {
                    res = Max(res, Sqrt(x * x + y * y));
                }
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
