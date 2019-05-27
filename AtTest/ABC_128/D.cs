using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int[] vs = ReadInts();
            int n = nk[0];
            int k = nk[1];

            int res = int.MinValue;
            for (int l = 0; l <= n; l++)
            {
                for (int r = 0; r + l <= n&&r+l<=k; r++)
                {
                    List<int> list = new List<int>();
                    for (int i = 0; i < l; i++) list.Add(vs[i]);
                    for (int i = n - 1; i > n - 1 - r; i--) list.Add(vs[i]);

                    list.Sort();
                    int remain = k - r - l;
                    for (int i = 0; i < remain && 0 < list.Count; i++) {
                        if (list[0] < 0) list.RemoveAt(0);
                    }
                    int temp = 0;
                    for (int i =0; i < list.Count; i++) temp += list[i];
                    res = Max(res, temp);
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
