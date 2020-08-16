using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ABC156_F
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
            int[] kq = ReadInts();
            int k = kq[0];
            int q = kq[1];
            long[] ds = ReadLongs();
            for (int i = 0; i < q; i++)
            {
                long[] nxm = ReadLongs();
                long n = nxm[0];
                long x = nxm[1];
                long m = nxm[2];

                long sum = x % m;
                for (int j = 0; j < Min(k, n); j++)
                {
                    long delta = ds[j] % m;
                    long cnt = (n - 1) / k;
                    if ((n - 1) % k > j)
                    {
                        cnt++;
                    }
                    if (delta > 0)
                    {
                        sum += delta * cnt;
                    }
                    else
                    {
                        sum += m * cnt;
                    }
                }

                long res = n - 1 - sum / m;
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
