using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Mujin_2017
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
            int n = ReadInt();
            int[] horizonCnts = new int[n];
            int[] verticalCnts = new int[n];
            var canYs = new HashSet<int>();
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < n; j++)
                {
                    if (s[j] == '.') continue;

                    horizonCnts[i]++;
                    verticalCnts[j]++;
                    canYs.Add(j);
                }
            }
            if (canYs.Count == 0)
            {
                WriteLine(-1);
                return;
            }

            int minCost = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                int tmp = 0;
                if (!canYs.Contains(i)) tmp++;
                minCost = Min(minCost, tmp+n - horizonCnts[i]);
            }
            int res = minCost;
            for(int i = 0; i < n; i++)
            {
                if (verticalCnts[i] < n) res++;
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
