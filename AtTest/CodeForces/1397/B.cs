using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1397
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
            int n = ReadInt();
            long[] array = ReadLongs();
            Array.Sort(array);

            long bottom = 1;
            long top = 1000000000 + 10;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long now = 1;
                bool ok = true;
                for (int i = 0; i < n; i++)
                {
                    if (1.0 * now * mid >= long.MaxValue / 10)
                    {
                        ok = false;
                        break;
                    }
                    else
                    {
                        now *= mid;
                    }
                }
                if (ok)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }

            long res = long.MaxValue;
            for(int i = 1; i <= bottom; i++)
            {
                long tmp = 0;
                long now = 1;
                for(int j = 0; j < n; j++)
                {
                    tmp += Abs(now - array[j]);
                    now *= i;
                }
                res = Min(res, tmp);
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
