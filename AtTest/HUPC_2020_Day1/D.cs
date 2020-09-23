using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_2020_Day1
{
    class D
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
                int n = ReadInt();

                long[][] xys = new long[n][];
                for (int j = 0; j < n; j++)
                {
                    xys[j] = ReadLongs();
                }

                if (n <= 2 || Validate(xys, 0, 1) || Validate(xys, 1, 2) || Validate(xys, 2, 0))
                {
                    WriteLine("Yes");
                }
                else
                {
                    WriteLine("No");
                }
            }
        }

        static bool Validate(long[][] xys, int a, int b)
        {
            long[] ab = new long[2] { xys[b][0] - xys[a][0], xys[b][1] - xys[a][1] };

            List<int> others = new List<int>();
            for (int i = 0; i < xys.Length; i++)
            {
                long x = xys[i][0] - xys[a][0];
                long y = xys[i][1] - xys[a][1];
                if (ab[0] * y - x * ab[1] == 0)
                {

                }
                else
                {
                    others.Add(i);
                }
            }

            if (others.Count <= 1)
            {
                return true;
            }

            long[] cd = new long[2] {xys[others[1]][0]-xys[others[0]][0],
                xys[others[1]][1]-xys[others[0]][1]};
            int cnt = 0;
            for (int i = 0; i < others.Count; i++)
            {
                long x = xys[others[i]][0] - xys[others[0]][0];
                long y = xys[others[i]][1] - xys[others[0]][1];
                if (cd[0] * y - x * cd[1] == 0)
                {

                }
                else
                {
                    cnt++;
                }
            }

            return cnt == 0 && ab[0] * cd[1] - cd[0] * ab[1] == 0;
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
