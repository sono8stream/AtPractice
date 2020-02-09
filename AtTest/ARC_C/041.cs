using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _041
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
            int[] nl = ReadInts();
            int n = nl[0];
            int l = nl[1];
            long[][] xds = new long[n][];
            for(int i = 0; i < n; i++)
            {
                string[] xd = Read().Split();
                xds[i] = new long[2] { int.Parse(xd[0]), xd[1][0] };
            }
            long first = xds[0][1];
            List<long[]> blocks = new List<long[]>();
            long now = first;
            blocks.Add(new long[2] { 1, xds[0][0] });
            for(int i = 1; i < n; i++)
            {
                if (now == xds[i][1])
                {
                    blocks[blocks.Count - 1][0]++;
                    if (now == 'R')
                    {
                        blocks[blocks.Count - 1][1] = xds[i][0];
                    }
                }
                else
                {
                    blocks.Add(new long[2] { 1, xds[i][0] });
                    now = xds[i][1];
                }
            }
            long res = 0;
            now = first;
            int tmp = 0;
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (now != xds[i][1])
                {
                    now = xds[i][1];
                    tmp++;
                    cnt = 0;
                }

                if (now == 'L')
                {
                    res += xds[i][0] - blocks[tmp][1] - cnt;
                }
                else
                {
                    res += blocks[tmp][1] - xds[i][0] - (blocks[tmp][0] - cnt - 1);
                }
                cnt++;
            }
            if (first == 'L')
            {
                res += (blocks[0][1] - 1) * blocks[0][0];
                blocks.RemoveAt(0);
            }
            for (int i = 0; i + 1 < blocks.Count; i += 2)
            {
                long more = Max(blocks[i][0], blocks[i + 1][0]);
                long delta = blocks[i + 1][1] - blocks[i][1] - 1;
                res += delta * more;
            }
            if (blocks.Count % 2 == 1)
            {
                res += (l - blocks[blocks.Count - 1][1]) * blocks[blocks.Count - 1][0];
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
