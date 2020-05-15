using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_167
{
    class C
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
            int[] nmx = ReadInts();
            int n = nmx[0];
            int m = nmx[1];
            int x = nmx[2];
            int[] cs = new int[n];
            int[,] array = new int[n,m];
            for(int i = 0; i < n; i++)
            {
                int[] input = ReadInts();
                cs[i] = input[0];
                for(int j = 0; j < m; j++)
                {
                    array[i, j] = input[j + 1];
                }
            }

            int all = 1 << n;
            int res = int.MaxValue;
            for(int i = 0; i < all; i++)
            {
                int[] vals = new int[m];
                int tmp = 0;
                for(int j=0;j<n;j++)
                {
                    if ((i & (1 << j)) == 0)
                    {
                        continue;
                    }

                    tmp += cs[j];
                    for(int k = 0; k < m; k++)
                    {
                        vals[k] += array[j, k];
                    }
                }

                bool ok = true;
                for(int j = 0; j < m; j++)
                {
                    if (vals[j] < x)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    res = Min(res, tmp);
                }
            }

            if (res == int.MaxValue)
            {
                WriteLine(-1);
            }
            else
            {
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
