using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_155
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
            var dict = new Dictionary<string, int>();
            int cnt = 0;
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                if (dict.ContainsKey(s))
                {
                    dict[s]++;
                }
                else
                {
                    dict.Add(s, 1);
                }
                cnt = Max(cnt, dict[s]);
            }
            List<string> res = new List<string>();
            foreach(string key in dict.Keys)
            {
                if (dict[key] == cnt)
                {
                    res.Add(key);
                }
            }
            res.Sort(StringComparer.Ordinal);
            for(int i = 0; i < res.Count; i++)
            {
                WriteLine(res[i]);
            }
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
