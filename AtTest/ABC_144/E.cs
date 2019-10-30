using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_144
{
    class E
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
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            long[] fs = ReadLongs();
            Array.Sort(array);
            Array.Sort(fs);
            long bottom = -1;
            long top = long.MaxValue / 4;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top + 1) / 2;
                long cnt = 0;
                for(int i = 0; i < n; i++)
                {
                    long val = array[i] * fs[n - i - 1];
                    if (val > mid)
                    {
                        long delta = (val - mid) / fs[n - i - 1];
                        if ((val - mid) % fs[n - i - 1] > 0) delta++;
                        cnt += delta;
                    }
                }
                if (cnt <= k) top = mid;
                else bottom = mid;
            }
            WriteLine(top);
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
