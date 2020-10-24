using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_105
{
    class C
    {
        static void Main(string[] args)
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
            long[] ws = ReadLongs();
            long[][] lvs = new long[m][];
            for (int i = 0; i < m; i++)
            {
                lvs[i] = ReadLongs();
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (lvs[i][1] < ws[j])
                    {
                        WriteLine(-1);
                        return;
                    }
                }
            }

            ///複数ラクダを並べたとき，両端が最低でもどれだけ離れているべきか計算
            int all = 1 << n;
            long[] constraints = new long[all];
            for (int i = 0; i < all; i++)
            {
                long sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        sum += ws[j];
                    }
                }

                for (int j = 0; j < m; j++)
                {
                    if (sum > lvs[j][1])
                    {
                        constraints[i] = Max(constraints[i], lvs[j][0]);
                    }
                }
            }

            ///すべての並べ方に対して最短距離を計算
            int[][] permutations = Permutations(n);
            long res = long.MaxValue;
            for (int i = 0; i < permutations.Length; i++)
            {
                long[] dists = new long[n];
                for (int j = 1; j < n; j++)
                {
                    int to = permutations[i][j];
                    long dist = 0;
                    int now = (1 << to);
                    for (int k = j - 1; k >= 0; k--)
                    {
                        int from = permutations[i][k];
                        now += (1 << from);
                        dist = Max(dist, dists[k] + constraints[now]);
                    }
                    dists[j] = dist;
                }

                res = Min(res, dists[n - 1]);
            }

            WriteLine(res);
        }

        static int[][] Permutations(int n)
        {
            int all = 1;
            for (int i = 1; i <= n; i++)
            {
                all *= i;
            }
            int[][] res = new int[all][];
            for (int i = 0; i < all; i++)
            {
                res[i] = new int[n];
            }
            int delta = all;
            for (int i = 0; i < n; i++)
            {
                int nextDelta = delta / (n - i);
                for (int j = 0; j < all; j += delta)
                {
                    bool[] used = new bool[n];
                    for (int k = 0; k < i; k++)
                    {
                        used[res[j][k]] = true;
                    }
                    List<int> remain = new List<int>();
                    for (int k = 0; k < n; k++)
                    {
                        if (!used[k])
                        {
                            remain.Add(k);
                        }
                    }
                    for (int k = 0; k < delta; k += nextDelta)
                    {
                        int num = k / nextDelta;
                        for (int l = 0; l < nextDelta; l++)
                        {
                            res[j + k + l][i] = remain[num];
                        }
                    }
                }
                delta = nextDelta;
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
