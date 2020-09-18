using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1401
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
            for(int i = 0; i < t; i++)
            {
                int[] xyz1 = ReadInts();
                int x1 = xyz1[0];
                int y1 = xyz1[1];
                int z1 = xyz1[2];
                int[] xyz2 = ReadInts();
                int x2 = xyz2[0];
                int y2 = xyz2[1];
                int z2 = xyz2[2];

                long res = 0;
                if (y1 > x2)
                {
                    y1 -= x2;
                    x2 = 0;
                }
                else
                {
                    x2 -= y1;
                    y1 = 0;
                }
                if (y1 > y2)
                {
                    y1 -= y2;
                    y2 = 0;
                }
                else
                {
                    y2 -= y1;
                    y1 = 0;
                }
                res -= y1 * 2;
                z2 -= y1;
                y1 = 0;

                if (z1 > y2)
                {
                    res += y2 * 2;
                }
                else
                {
                    res += z1 * 2;
                }

                WriteLine(res);
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
