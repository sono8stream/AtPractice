using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1369
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
            int t = ReadInt();
            int max = 2 * 1000000 + 10;
            long mask = 1000000000 + 7;
            long[] reses = new long[max];
            bool[] filled = new bool[max];
            reses[3] = 4;
            filled[3] = true;
            for(int i = 4; i < max; i++)
            {
                reses[i] = reses[i - 1] + reses[i - 2] * 2;
                if (!filled[i - 1] && !filled[i - 2])
                {
                    reses[i] += 4;
                    filled[i] = true;
                }
                reses[i] %= mask;
            }

            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                WriteLine(reses[n]);
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
