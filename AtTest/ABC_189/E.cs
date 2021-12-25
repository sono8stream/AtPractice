using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_189
{
    class E
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
            long[][] poses = new long[n][];
            for(int i = 0; i < n; i++)
            {
                poses[i] = ReadLongs();
            }

            int m = ReadInt();
            long[][,] oprs = new long[m][,];
            for(int i = 0; i < m; i++)
            {
                oprs[i] = new long[3, 3];
                oprs[i][2, 2] = 1;
                string[] row = Read().Split();
                if (row[0][0] == '1')
                {
                    oprs[i][0, 1] = 1;
                    oprs[i][1, 0] = -1;
                }
                if (row[0][0] == '2')
                {
                    oprs[i][0, 1] = -1;
                    oprs[i][1, 0] = 1;
                }
                if (row[0][0] == '3')
                {
                    long p = long.Parse(row[1]);
                    oprs[i][0, 0] = -1;
                    oprs[i][0, 2] = 2 * p;
                    oprs[i][1, 1] = 1;
                }
                if (row[0][0] == '4')
                {
                    long p = long.Parse(row[1]);
                    oprs[i][0, 0] = 1;
                    oprs[i][1, 1] = -1; 
                    oprs[i][1, 2] = 2 * p;
                }

                if (i > 0)
                {
                    oprs[i] = Multi(oprs[i], oprs[i - 1]);
                }
            }

            int q = ReadInt();
            for(int i = 0; i < q; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0];
                int b = ab[1]-1;
                if (a == 0)
                {
                    WriteLine(poses[b][0] + " " + poses[b][1]);
                }
                else
                {
                    long[,] firstPos = new long[3, 1];
                    firstPos[0, 0] = poses[b][0];
                    firstPos[1, 0] = poses[b][1];
                    firstPos[2, 0] = 1;
                    long[,] pos = Multi(oprs[a - 1], firstPos);
                    WriteLine(pos[0, 0] + " " + pos[1, 0]);
                }
            }
        }

        static long[,] Multi(long[,] left,long[,] right)
        {
            int rows = left.GetLength(0);
            int cols = right.GetLength(1);
            long[,] res = new long[3, 3];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    res[i, j] = left[i, 0] * right[0, j]
                        + left[i, 1] * right[1, j]
                        + left[i, 2] * right[2, j];
                }
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
