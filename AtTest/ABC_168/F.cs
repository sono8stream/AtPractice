using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_168
{
    class F
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
            int[][] horizon = new int[n][];
            for(int i = 0; i < n; i++)
            {
                horizon[i] = ReadInts();
            }
            Array.Sort(horizon, (a, b) => a[2] - b[2]);
            int[][] vertical = new int[n][];
            for(int i = 0; i < m; i++)
            {
                vertical[i] = ReadInts();
            }
            Array.Sort(vertical, (a, b) => a[2] - b[2]);

            List<int>[] hCrosses = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                hCrosses[i] = new List<int>();
                for(int j = 0; j < m; j++)
                {
                    if(horizon[i][2]>= vertical[j][1]
                        && horizon[i][2]<= vertical[j][2]
                        && horizon[i][0]<=vertical[j][0]
                        && horizon[i][1] >= vertical[j][0])
                    {
                        hCrosses[i].Add(vertical[j][0]);
                    }
                }
            }
            List<int>[] vCrosses = new List<int>[m];
            for (int i = 0; i < m; i++)
            {
                hCrosses[i] = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if(vertical[i][1]<=horizon[j][2]
                        &&vertical[i][2]>=horizon[j][2]
                        &&vertical[i][0]>=horizon[j][0]
                        && vertical[i][0] <= horizon[j][1])
                    {
                        vCrosses[i].Add(horizon[j][2]);
                    }
                }
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
