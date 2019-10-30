using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_144
{
    class F
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
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < m; i++)
            {
                int[] st = ReadInts();
                graph[st[0] - 1].Add(st[1] - 1);
            }
            double[] baseDP = new double[n];

            for(int i = n - 2; i >= 0; i--)
            {
                double val = 0;
                for(int j = 0; j < graph[i].Count; j++)
                {
                    val += baseDP[graph[i][j]];
                }
                baseDP[i] += 1 + val / graph[i].Count;
            }

            double res = baseDP[0];
            for(int i = 0; i < n; i++)
            {
                if (graph[i].Count <= 1) continue;
                double[] tempDP = new double[n];
                double nextVal = 0;
                double maxVal = 0;
                for(int j = 0; j < graph[i].Count; j++)
                {
                    nextVal += baseDP[graph[i][j]];
                    maxVal = Max(maxVal, baseDP[graph[i][j]]);
                }
                tempDP[i] = 1 + (nextVal - maxVal) / (graph[i].Count - 1);
                for(int j = i - 1; j >= 0; j--)
                {
                    double val = 0;
                    for(int k = 0; k < graph[j].Count; k++)
                    {
                        if (graph[j][k] <= i) val += tempDP[graph[j][k]];
                        else val += baseDP[graph[j][k]];
                    }
                    tempDP[j] = 1 + val / graph[j].Count;
                }
                res = Min(res, tempDP[0]);
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
