using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_164
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
            string s = Read();
            s =string.Concat(s.Reverse());
            int[] remains = new int[s.Length];
            int div = 1;
            int tmp = 0;
            int mask = 2019;
            for(int i = 0; i <s.Length; i++)
            {
                tmp+= (s[i] - '0') * div;
                tmp %= mask;
                remains[i] = tmp;
                div *= 10;
                div %= mask;
            }

            int res = 0;
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            for(int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(remains[i]))
                {
                    res += dict[remains[i]];
                    dict[remains[i]]++;
                }
                else
                {
                    dict.Add(remains[i], 1);
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
