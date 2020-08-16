using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1379
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
            for (int i = 0; i < t; i++)
            {
                long[] lrm = ReadLongs();
                long l = lrm[0];
                long r = lrm[1];
                long m = lrm[2];

                for (long j = l; j <= r; j++)
                {
                    long remain = m % j;
                    if (remain == 0)
                    {
                        WriteLine(j + " " + j + " " + j);
                        break;
                    }
                    else {
                        if (m / j > 0 && remain < j - remain && remain <= r - l)
                        {
                            WriteLine(j + " " + (l + remain) + " " + l);
                            break;
                        }
                        else if (j - remain <= r - l)
                        {
                            WriteLine(j + " " + l + " " + (l + j - remain));
                            break;
                        }
                    }
                }
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
