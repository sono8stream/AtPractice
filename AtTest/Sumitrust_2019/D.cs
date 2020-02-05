using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Sumitrust_2019
{
    class D
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
            string s = Read();
            int[][] graph = new int[n][];
            graph[n - 1] = new int[10];
            for (int i = 0; i < 10; i++) graph[n - 1][i] = int.MaxValue;
            for (int i = n - 2; i >= 0; i--)
            {
                graph[i] = new int[10];
                for (int j = 0; j < 10; j++) graph[i][j] = graph[i + 1][j];
                graph[i][s[i + 1] - '0'] = i + 1;
            }
            int[] start = new int[10];
            for (int i = 0; i < 10; i++) start[i] = graph[0][i];
            start[s[0] - '0'] = 0;
            int res = 0;
            for(int i = 0; i < 10; i++)
            {
                int first = start[i];
                if (first == int.MaxValue) continue;
                for(int j = 0; j < 10; j++)
                {
                    int second = graph[first][j];
                    if (second == int.MaxValue) continue;
                    for(int k = 0; k < 10; k++)
                    {
                        int third = graph[second][k];
                        if (third == int.MaxValue) continue;
                        //WriteLine(i + "" + j + "" + k);
                        res++;
                    }
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
