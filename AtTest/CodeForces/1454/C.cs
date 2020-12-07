using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1454
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

                bool[] used = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    used[array[j] - 1] = true;
                }
                int[] prevs = new int[n];
                for (int j = 0; j < n; j++)
                {
                    prevs[j] = -1;
                }
                int[] cnts = new int[n];
                for (int j = 0; j < n; j++)
                {
                    int now = array[j]-1;
                    if (prevs[now] + 1 < j)
                    {
                        cnts[now]++;
                    }
                    prevs[now] = j;
                }
                for(int j = 0; j < n; j++)
                {
                    if (used[j] && prevs[j] + 1 < n)
                    {
                        cnts[j]++;
                    }
                }

                int res = int.MaxValue;
                for(int j = 0; j < n; j++)
                {
                    if (used[j])
                    {
                        res = Min(res, cnts[j]);
                    }
                }

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
