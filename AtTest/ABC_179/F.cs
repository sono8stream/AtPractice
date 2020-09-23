using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_179
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];

            /// ある位置に置くと，それより外側の位置に置いた場合の減少数は固定される
            /// 内側部分の大きさは単調減少

            int h = n - 2;
            int w = n - 2;
            int[] horizons = new int[n - 2];
            int[] verticals = new int[n - 2];
            for (int i = 0; i < n - 2; i++)
            {
                horizons[i] = n - 2;
                verticals[i] = n - 2;
            }

            long res = (long)(n - 2) * (n - 2);
            for (int i = 0; i < q; i++)
            {
                int[] query = ReadInts();
                int l = query[0];
                int r = query[1];
                if (l == 1)
                {
                    if (r - 2 < w)
                    {
                        for (int j = r - 2; j < w; j++)
                        {
                            verticals[j] = h;
                        }
                        w = r - 2;
                    }
                    res -= verticals[r - 2];
                }
                if (l == 2)
                {
                    if (r - 2 < h)
                    {
                        for (int j = r - 2; j < h; j++)
                        {
                            horizons[j] = w;
                        }
                        h = r - 2;
                    }
                    res -= horizons[r - 2];
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
