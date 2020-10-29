using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class Donuts2015_B
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
            int[][] bcis = new int[m][];
            for(int i = 0; i < m; i++)
            {
                int[] bci = ReadInts();
                int val = 0;
                for(int j = 0; j < bci[1]; j++)
                {
                    val += 1 << (bci[2 + j] - 1);
                }

                bcis[i] = new int[2] { bci[0], val };
            }

            int all = 1 << n;
            int res = 0;
            for(int i = 0; i < all; i++)
            {
                int cnt = 0;
                int tmp = 0;
                for(int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        cnt++;
                        tmp += array[j];
                    }
                }

                if (cnt != 9)
                {
                    continue;
                }

                for(int j = 0; j < m; j++)
                {
                    int val = (i & bcis[j][1]);
                    int comboCnt = 0;
                    for(int k = 0; k < n; k++)
                    {
                        if ((val & (1 << k)) > 0)
                        {
                            comboCnt++;
                        }
                    }
                    if (comboCnt>=3)
                    {
                        tmp += bcis[j][0];
                    }
                }

                if (res < tmp)
                {
                    res = Max(res, tmp);
                }
                res = Max(res, tmp);
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
