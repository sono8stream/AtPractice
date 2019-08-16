using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_137
{
    class C
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
            Dictionary<string, long> dict = new Dictionary<string, long>();
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                char[] cs = s.ToCharArray();
                Array.Sort(cs);
                string ss = new string(cs);
                if (!dict.ContainsKey(ss)) dict.Add(ss, 0);
                dict[ss]++;
            }

            long res = 0;
            foreach(string s in dict.Keys)
            {
                res += (dict[s] * (dict[s] - 1)) / 2;
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
