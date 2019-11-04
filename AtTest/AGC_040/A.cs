using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_040
{
    class A
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
            int[] left = new int[s.Length + 1];
            int[] right = new int[s.Length + 1];
            int tmp = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '<') tmp++;
                else tmp = 0;
                left[i + 1] = tmp;
            }
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '>') tmp++;
                else tmp = 0;
                right[i] = tmp;
            }
            long res = 0;
            for(int i = 0; i < s.Length + 1; i++)
            {
                res += Max(left[i], right[i]);
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
