using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1B
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int[] pq = ReadInts();
            int p = pq[0];
            int q = pq[1];
            int[][] poses = new int[p][];
            char[] dirs = new char[p];
            for (int i = 0; i < p; i++)
            {
                string[] s = Read().Split();
                poses[i] = new int[2] { int.Parse(s[0]), int.Parse(s[1]) };
                dirs[i] = s[2][0];
            }

            int[] xCnts = new int[q + 1];
            int[] yCnts = new int[q + 1];
            for (int i = 0; i <= q; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    switch (dirs[j])
                    {
                        case 'N':
                            if (i > poses[j][1]) yCnts[i]++;
                            break;
                        case 'E':
                            if (i > poses[j][0]) xCnts[i]++;
                            break;
                        case 'S':
                            if (i < poses[j][1]) yCnts[i]++;
                            break;
                        case 'W':
                            if (i < poses[j][0]) xCnts[i]++;
                            break;
                    }
                }
            }
            int x = 0;
            int y = 0;
            for (int i = 0; i <= q; i++)
            {
                if (xCnts[x] < xCnts[i])
                {
                    x = i;
                }
                if (yCnts[y] < yCnts[i])
                {
                    y = i;
                }
            }
            return () => WriteLine(x + " " + y);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
