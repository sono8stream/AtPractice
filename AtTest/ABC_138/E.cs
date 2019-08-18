using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_138
{
    class E
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
            string t = Read();
            List<int>[] poses = new List<int>[26];
            for (int i = 0; i < 26; i++) poses[i] = new List<int>();
            for(int i = 0; i < s.Length; i++)
            {
                poses[s[i] - 'a'].Add(i);
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (poses[t[i] - 'a'].Count == 0)
                {
                    WriteLine(-1);
                    return;
                }
            }
            for (int i = 0; i < 26; i++) poses[i].Add(s.Length + 10);
            long res = 0;
            int pos = -1;
            for(int i = 0; i < t.Length; i++)
            {
                int bottom = -1;
                int c = t[i] - 'a';
                int top = poses[c].Count-1;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top + 1) / 2;
                    if (pos < poses[c][mid]) top = mid;
                    else bottom = mid;
                }
                if (top == poses[c].Count-1)
                {
                    res += s.Length - pos;
                    res += poses[c][0];
                    pos = poses[c][0];
                }
                else
                {
                    res += poses[c][top] - pos;
                    pos = poses[c][top];
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
