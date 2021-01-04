using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1462
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
            int t = ReadInt();
            string ans = "2020";
            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                string s = Read();
                bool[] pre = new bool[4];
                bool[] suf = new bool[4];
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (s.Substring(0, j + 1) == ans.Substring(0, j + 1))
                        {
                            pre[j] = true;
                        }
                    }
                }
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (s.Substring(n - 1 - j) == ans.Substring(3 - j))
                        {
                            suf[j] = true;
                        }
                    }
                }
                bool ok = false;
                for(int j = 0; j < 3; j++)
                {
                    if (pre[j] && suf[2 - j])
                    {
                        ok = true;
                    }
                }
                if (pre[3] || suf[3])
                {
                    ok = true;
                }
                WriteLine(ok ? "YES" : "NO");
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
