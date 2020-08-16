using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.M_Solutions_2020
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
            int n = ReadInt();
            int[][] xyps = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xyps[i] = ReadInts();
            }

            int all = 1 << n;
            for (int k = 0; k <= n; k++) {
                int res = int.MaxValue;

                for (int i = 0; i < all; i++)
                {
                    List<int> horizons = new List<int>();
                    List<int> verticals = new List<int>();
                    int div = 1;
                    for (int j = 0; j < n; j++)
                    {
                        if ((div & i) > 0)
                        {
                            horizons.Add(xyps[i][1]);
                        }
                        else
                        {
                            verticals.Add(xyps[i][0]);
                        }
                    }

                    for(int j = 0; j <= k; j++)
                    {
                        int other = k - j;

                    }
                }
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
