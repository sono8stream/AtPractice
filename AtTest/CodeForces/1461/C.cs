using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1461
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
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                int[] array = ReadInts();
                string[][] oprs = new string[m][];
                for(int j = 0; j < m; j++)
                {
                    oprs[j] = Read().Split();
                }

                int[] sorted = new int[n];
                for(int j = 0; j < n; j++)
                {
                    sorted[j] = array[j];
                }
                Array.Sort(sorted);

                int last = n-1;
                for(int j = n - 1; j >= 0; j--)
                {
                    if (array[j] == sorted[j])
                    {
                        last--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (last < 0)
                {
                    WriteLine(1);
                    continue;
                }

                double res = 0;
                for(int j = m - 1; j >= 0; j--)
                {
                    int idx = int.Parse(oprs[j][0]) - 1;
                    double prob = double.Parse(oprs[j][1]);
                    if (idx < last)
                    {
                        continue;
                    }

                    res = prob + (1 - prob) * res;
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
