using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1236
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            List<int>[] rows = new List<int>[n];
            List<int>[] cols = new List<int>[m];
            for(int i = 0; i < n; i++)
            {
                rows[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                cols[i] = new List<int>();
            }

            for(int i = 0; i < k; i++)
            {
                int[] pos = ReadInts();
                int y = pos[0] - 1;
                int x = pos[1] - 1;
                rows[y].Add(x);
                cols[x].Add(y);
            }

            int dir = 0;
            long res = 0;
            int[] begins = new int[4] { -1, 0, m - 1, n - 1 };
            int[] lasts = new int[4] { m - 1, n - 1, 0, 0 };
            int[] poses = new int[4] { 0, m - 1, n - 1, 0 };
            while (true)
            {
                int last = lasts[dir];
                if (dir == 0)
                {
                    foreach(int pos in rows[poses[dir]])
                    {
                        if (begins[dir] < pos)
                        {
                            last = Min(last, pos - 1);
                        }
                    }
                }
                if (dir == 1)
                {
                    foreach (int pos in cols[poses[dir]])
                    {
                        if (begins[dir] < pos)
                        {
                            last = Min(last, pos - 1);
                        }
                    }

                }
                if (dir == 2)
                {
                    foreach (int pos in rows[poses[dir]])
                    {
                        if (begins[dir] > pos)
                        {
                            last = Max(last, pos + 1);
                        }
                    }
                }
                if (dir == 3)
                {
                    foreach (int pos in cols[poses[dir]])
                    {
                        if (begins[dir] > pos)
                        {
                            last = Max(last, pos + 1);
                        }
                    }
                }

                if (last == begins[dir])
                {
                    break;
                }
                else
                {
                    res += Abs(last - begins[dir]);
                    begins[(dir + 1) % 4] = poses[dir];
                    if (dir == 0 || dir == 3)
                    {
                        lasts[(dir + 3) % 4] = poses[dir] + 1;
                    }
                    else
                    {
                        lasts[(dir + 3) % 4] = poses[dir] - 1;
                    }
                    poses[(dir + 1) % 4] = last;
                    dir = (dir + 1) % 4;
                }
            }

            long max = n;
            max *= m;
            max -= k;
            if (res == max)
            {
                WriteLine("Yes");
            }
            else
            {
                WriteLine("No");
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
