using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_Challenge
{
    class _018_B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] array = new int[n][];
            for(int i = 0; i < n; i++)
            {
                array[i] = ReadInts();
                for (int j = 0; j < array[i].Length; j++) array[i][j]--;
            }

            int bottom = 0;
            int top = n;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;

                bool[] used = new bool[m];
                bool can = true;
                while (true)
                {
                    int[] cnt = new int[m];
                    for(int i = 0; i < n; i++)
                    {
                        for(int j = 0; j < m; j++)
                        {
                            if (used[array[i][j]]) continue;

                            cnt[array[i][j]]++;
                            break;
                        }
                    }

                    if (cnt.Sum() < n)
                    {
                        can = false;
                        break;
                    }

                    if (cnt.Max() <= mid)
                    {
                        can = true;
                        break;
                    }

                    used[Array.IndexOf(cnt, cnt.Max())] = true;
                }

                if (can)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }

            WriteLine(top);
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
