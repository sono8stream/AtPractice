using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1355
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
            long[] abcd = ReadLongs();
            long a = abcd[0];
            long b = abcd[1];
            long c = abcd[2];
            long d = abcd[3];

            long res = 0;
            for(long i = a; i <= b; i++)
            {
                long yMax = c - b + 1;
                long zMax = i + c - 1;
                if (zMax > d)
                {
                    long margin = zMax - d;
                    res += (d - c + 1) * (d - c + 1 + 1) / 2 + (d - c + 1) * margin;
                    zMax -= c - 1;
                    if (yMax < zMax)
                    {
                        long remain = zMax - yMax;
                        if (remain > d - c + 1)
                        {
                            res -= (d - c + 1) * (d - c + 1 + 1) / 2 + (d - c + 1) * (remain - (d - c + 1));
                        }
                        else
                        {
                            res -= remain * (remain + 1) / 2;
                        }
                    }
                }
                else
                {
                    zMax -= c - 1;
                    res += zMax * (zMax + 1) / 2;
                    if (yMax < zMax)
                    {
                        res -= (zMax - yMax) * (zMax - yMax + 1) / 2;
                    }
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
