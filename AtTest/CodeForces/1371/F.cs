using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1371
{
    class F
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] np = ReadInts();
            int n = np[0];
            int p = np[1];
            int[] array = ReadInts();
            Array.Sort(array);

            long min = 0;
            for (int i = 0; i < n; i++)
            {
                if (min + i < array[i])
                {
                    min = array[i] - i;
                }
            }

            long bottom = 0;
            long top = int.MaxValue;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                int cnt = 0;
                int idx = 0;
                bool ok = false;
                for (int i = 0; i < n; i++)
                {
                    while (idx < n && array[idx] <= mid + i)
                    {
                        cnt++;
                        idx++;
                    }
                    if (cnt - i >= p)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }

            long res = Max(bottom - min + 1, 0);
            WriteLine(res);
            for(long i = min; i <= bottom; i++)
            {
                Write(i);
                if (i < bottom)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
