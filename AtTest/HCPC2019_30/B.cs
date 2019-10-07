using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_30
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
            int[] abc = ReadInts();
            int a = abc[0];
            int b = abc[1];
            int c = abc[2];
            var hashSet = new HashSet<int>();
            int start = 0;
            int rot = 0;
            while (!hashSet.Contains(start))
            {
                if (start <= c && c <= start + a)
                {
                    WriteLine(c + rot * 60);
                    return;
                }
                hashSet.Add(start);
                start += a + b;
                if (start >= 60)
                {
                    start %= 60;
                    rot++;
                }
            }
            WriteLine(-1);
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
