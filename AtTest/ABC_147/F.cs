using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_147
{
    class F
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
            long[] nxd = ReadLongs();
            long n = nxd[0];
            long x = nxd[1];
            long d = nxd[2];
            if (d == 0)
            {
                if (x == 0)
                {
                    WriteLine(1);
                }
                else
                {
                    WriteLine(n + 1);
                }
                return;
            }
            if (d < 0)
            {
                x *= -1;
                d *= -1;
            }
            long baseVal = long.MinValue / 10;
            long[][] ranges = new long[n+1][];
            long minVal = 0;
            long maxVal = 0;
            for(int i = 0; i <= n; i++)
            {
                long fixVal = x * i - baseVal;
                long margin = fixVal % d;
                long min = minVal + fixVal / d;
                long max = maxVal + fixVal / d;
                ranges[i] = new long[3] { margin, min, max };
                minVal += i;
                maxVal += n - i - 1;
            }
            ranges = ranges.OrderBy(a => a[1]).OrderBy(a => a[0]).ToArray();
            long res = 0;
            long prev = -1;
            long prevRight = 0;
            for(int i = 0; i <= n; i++)
            {
                if (ranges[i][0] != prev) prevRight = -1;
                prev = ranges[i][0];
                if (prevRight < ranges[i][1])
                {
                    res += ranges[i][2] - ranges[i][1] + 1;
                    prevRight = ranges[i][2];
                }
                else if(prevRight<ranges[i][2])
                {
                    res += ranges[i][2] - prevRight;
                    prevRight = ranges[i][2];
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
