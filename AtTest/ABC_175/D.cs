using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_175
{
    class D
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] ps = ReadInts();
            long[] cs = ReadLongs();
            for(int i = 0; i < n; i++)
            {
                ps[i]--;
            }

            long res = long.MinValue;
            int[] visits = new int[n];
            for(int i = 0; i < n; i++)
            {
                if (visits[i] > 0)
                {
                    continue;
                }

                List<int> poses = new List<int>();
                int now = i;
                long cycleScore = 0;
                while (visits[now] == 0)
                {
                    visits[now] = 1;
                    poses.Add(now);
                    now = ps[now];
                    cycleScore += cs[now];
                }

                long baseVal = 0;
                long remain;
                if (k / poses.Count > 1)
                {
                    baseVal = Max(0, cycleScore * (k / poses.Count - 1));
                    remain = k % poses.Count + poses.Count;
                }
                else
                {
                    remain = k;
                }
                for(int j = 0; j < poses.Count; j++)
                {
                    long val = 0;
                    for(int l = 1; l <= remain; l++)
                    {
                        val += cs[poses[(j + l) % poses.Count]];
                        res = Max(res, baseVal + val);
                    }
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
