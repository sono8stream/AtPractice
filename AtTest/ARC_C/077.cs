using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _077
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] array = ReadInts();
            long res = long.MaxValue;
            long now = 0;
            int[] ups = new int[m];
            List<int>[] downs = new List<int>[m];
            for(int i = 0; i < m; i++)
            {
                downs[i] = new List<int>();
            }
            int cnt = 0;
            for(int i = 0; i < n-1; i++)
            {
                now += Min((m + array[i + 1] - array[i]) % m, array[i + 1] % m + 1);
                ups[(array[i] + 1) % m]++;
                downs[array[i + 1] % m].Add(i);

                if ((array[i + 1] + 1) % m < (array[i] + 1) % m)
                {
                    cnt++;
                }
            }
            res = now;

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < downs[i - 1].Count; j++)
                {
                    int index = downs[i - 1][j];
                    now += (m + array[index + 1] - array[index]) % m - 1;
                    cnt--;
                }

                now -= cnt;
                res = Min(res, now);

                cnt += ups[i];
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
