using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_028
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
            int[] nt = ReadInts();
            int n = nt[0];
            int t = nt[1];
            int all = 0;
            int alicia_cnt = 0;
            for(int i=0;i<n;i++)
            {
                string[] s = Read().Split();
                string name = s[0];
                char r = s[1][0];
                int rate = int.Parse(s[2]);
                if (name.Contains("Alicia") && r != 'N')
                {
                    alicia_cnt += rate;
                }
                all += rate;
            }
            t -= t / 10;
            WriteLine(1.0 * t / all * alicia_cnt);
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
