using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_181
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
            int[][] xys = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xys[i] = ReadInts();
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    for(int k = j + 1; k < n; k++)
                    {
                       long a = xys[j][0] - xys[i][0];
                        long b = xys[j][1] - xys[i][1];
                        long c = xys[k][0] - xys[i][0];
                        long d = xys[k][1] - xys[i][1];

                        long left = (a * a + b * b) * (c * c + d * d);
                        long right = a * c + b * d;
                        right *= right;

                        if (left == right)
                        {
                            WriteLine("Yes");
                            return;
                        }
                    }
                }
            }

            WriteLine("No");
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
