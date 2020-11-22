using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1417
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[] array = ReadInts();

                List<int>[] poses = new List<int>[n];
                for(int j = 0; j < n; j++)
                {
                    poses[j] = new List<int>();
                }
                for(int j = 0; j < n; j++)
                {
                    poses[array[j] - 1].Add(j);
                }

                int[] res = new int[n+1];
                for(int j = 1; j <= n; j++)
                {
                    res[j] = -1;
                }
                for(int j = 0; j < n; j++)
                {
                    int can = -1;
                    int prev = -1;
                    for (int k = 0; k < poses[j].Count; k++)
                    {
                        int pos = poses[j][k];
                        can = Max(can, pos - prev);
                        prev = pos;
                    }
                    can = Max(can, n - prev);

                    if (can <= n && res[can] == -1)
                    {
                        res[can] = j + 1;
                    }
                }

                int min = -1;
                for (int j = 1; j <= n; j++)
                {
                    if (res[j] > 0 && (min == -1 || min > res[j]))
                    {
                        min = res[j];
                    }
                    Write(min);
                    if (j < n)
                    {
                        Write(' ');
                    }
                }
                WriteLine();
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
