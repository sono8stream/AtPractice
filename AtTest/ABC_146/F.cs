using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_146
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            string s = Read();
            bool[] cans = new bool[n + 1];
            for (int i = 0; i <= n; i++) cans[i] = s[i] == '0';
            Array.Reverse(cans);
            List<int> res = new List<int>();
            int now = 0;
            while (now < n)
            {
                bool can = false;
                for (int i = Min(m, n - now); i >= 1; i--)
                {
                    if (cans[now + i])
                    {
                        can = true;
                        now += i;
                        res.Add(i);
                        break;
                    }
                }
                if (!can)
                {
                    WriteLine(-1);
                    return;
                }
            }
            res.Reverse();
            res.ForEach((item) => { Write(item+" "); });
            WriteLine();
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
