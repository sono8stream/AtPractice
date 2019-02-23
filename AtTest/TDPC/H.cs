using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TDPC
{
    class H
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nwc = ReadInts();
            int n = nwc[0];
            int w = nwc[1];
            int c = nwc[2];
            int[][] wvcs = new int[n][];
            for(int i =0; i < n; i++)
            {
                int[] wvc = ReadInts();
                wvcs[i] = new int[3] { wvc[0], wvc[1], wvc[2] - 1 };
            }
            Array.Sort(wvcs, (a, b) => a[2] - b[2]);
            int[,] dpC = new int[50, w + 1];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j <= w; j++)
                {
                    if (j + wvcs[i][0] > w) break;
                    if (j > 0 && dpC[wvcs[i][2], j] == 0) continue;
                    dpC[wvcs[i][2], j + wvcs[i][0]]
                        = Max(dpC[wvcs[i][2], j + wvcs[i][0]],
                        dpC[wvcs[i][2], j]);
                }
            }
            int[,] dp = new int[c + 1, w + 1];
            //i種類の色，重さjのときの価値の最大
            for(int i = 0; i < 50; i++)
            {
                for(int j = 0; j <= w; j++)
                {
                    
                }
            }
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
