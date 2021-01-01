using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1463
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
            long[] pows = new long[30];
            pows[0] = 1;
            for(int i = 1; i < 30; i++)
            {
                pows[i] = pows[i - 1] * 2;
            }

            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                long[] array = ReadLongs();
                for(int j = 0; j < n; j++)
                {
                    int idx = 0;
                    long minDelta = long.MaxValue;
                    for(int k = 0; k < 30; k++)
                    {
                        long delta = Abs(pows[k] - array[j]);
                        if (minDelta > delta)
                        {
                            idx = k;
                            minDelta = delta;
                        }
                    }
                    Write(pows[idx]);
                    if (j + 1 < n)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
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
