using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Virtual
{
    class ABC116_D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[][] tds = new long[n][];
            for(int i = 0; i < n; i++)
            {
                tds[i] = ReadLongs();
            }
            tds = tds.OrderBy(a => -a[1]).ToArray();
            long baseSum = 0;
            var kindCnts = new Dictionary<long, long>();
            for (int i = 0; i < k; i++)
            {
                baseSum += tds[i][1];
                if (!kindCnts.ContainsKey(tds[i][0]))
                {
                    kindCnts.Add(tds[i][0], 0);
                }
                kindCnts[tds[i][0]]++;
            }
            long res = baseSum + kindCnts.Count * kindCnts.Count;
            int nowI = k - 1;
            int addI = k;
            while (nowI >= 0)
            {
                while (nowI>=0&&kindCnts[tds[nowI][0]] == 1)
                {
                    nowI--;
                }
                if (nowI < 0) break;

                baseSum -= tds[nowI][1];
                kindCnts[tds[nowI][0]]--;
                while (addI < n && kindCnts.ContainsKey(tds[addI][0]))
                {
                    addI++;
                }
                if (addI == n) break;

                baseSum += tds[addI][1];
                kindCnts.Add(tds[addI][0], 1);
                res = Max(res, baseSum + kindCnts.Count * kindCnts.Count);
            }
            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
