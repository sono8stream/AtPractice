using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.Combination
{
    class Combination_Permutation
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            long mask = 1000000000 + 7;
            long cnt = Combination(n, m, mask);

            Console.WriteLine(cnt);
        }

        static long Combination(long n,long m)
        {
            if (n - m < m) m = n - m;

            long val = Permutation(n, m);
            long div = Permutation(m, m);
            return val / div;
        }

        static long Permutation(long n, long m)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= (n - i);
            }
            return val;
        }

        static long Combination(long n, long m, long mask)
        {
            if (n < m) return 0;

            if (n - m < m) m = n - m;

            long val = Permutation(n, m, mask);
            long div = Permutation(m, m, mask);
            return MultiMod(val, ReverseMod(div, mask - 2, mask), mask);
        }

        static long Permutation(long n, long m, long mask)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
        }

        static long[] AllPermutations(long n, long mask)
        {
            var perms = new long[n + 1];
            perms[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                perms[i] = MultiMod(perms[i - 1], i, mask);
            }
            return perms;
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long ReverseMod(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = ReverseMod(a, pow / 2, mask);
                long nextMod = MultiMod(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return MultiMod(nextMod, a, mask);
                }
            }
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

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
