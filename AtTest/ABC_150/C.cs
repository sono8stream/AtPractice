using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_150
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
            int n = ReadInt();
            int[] ps = ReadInts();
            int[] qs = ReadInts();
            int[][] permutations=Permutations(n);
            int a = 0;
            int b = 0;
            for(int i = 0; i < permutations.Length; i++)
            {
                bool isP = true;
                bool isQ = true;
                for(int j = 0; j < n; j++)
                {
                    if (permutations[i][j] + 1 != ps[j])
                    {
                        isP = false;
                    }
                    if (permutations[i][j] + 1 != qs[j])
                    {
                        isQ = false;
                    }
                }
                if (isP) a = i;
                if (isQ) b = i;
            }
            WriteLine(Abs(a - b));
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
