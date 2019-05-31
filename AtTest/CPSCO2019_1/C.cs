using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CPSCO2019_1
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] array = ReadLongs();
            List<int[]> list = EnumerateCombination(n, k);
            int res = int.MaxValue;
            for(int i = 0; i < list.Count; i++)
            {
                long sum = 0;
                for(int j = 0; j < list[i].Length; j++)
                {
                    sum += array[list[i][j]];
                }
                int tmp = 0;
                while (sum > 0)
                {
                    if (sum % 10 >= 5) tmp++;
                    tmp += (int)(sum % 5);
                    sum /= 10;
                }
                res = Min(res, tmp);
            }
            WriteLine(res);
        }
        static List<int[]> EnumerateCombination(int n, int m)
        {
            var all = new List<List<int>>[n];
            for (int i = 0; i <= n - m; i++)
            {
                var list = new List<int>();
                list.Add(i);
                all[i] = new List<List<int>>();
                all[i].Add(list);
            }

            for (int i = 1; i < m; i++)
            {
                var next = new List<List<int>>[n];
                for (int j = i; j <= n - m + i; j++)
                {
                    next[j] = new List<List<int>>();
                    for (int k = i - 1; k < j; k++)
                    {
                        for (int l = 0;
                            all[k] != null && l < all[k].Count; l++)
                        {
                            var list = new List<int>();
                            list.AddRange(all[k][l]);
                            list.Add(j);
                            next[j].Add(list);
                        }
                    }
                }
                all = next;
            }

            var res = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; all[i] != null && j < all[i].Count; j++)
                {
                    res.Add(all[i][j].ToArray());
                }
            }
            return res;
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
