using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC060_E
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
            List<int> xs = ReadInts().ToList();
            int l = ReadInt();
            int q = ReadInt();
            xs.Add(xs[xs.Count - 1] + l);
            int[][] abs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                abs[i] = ReadInts();
                if (abs[i][0] > abs[i][1])
                {
                    int tmp = abs[i][0];
                    abs[i][0] = abs[i][1];
                    abs[i][1] = tmp;
                }
                abs[i][0]--;
                abs[i][1]--;
            }
            int top = 40;
            int[,] nexts = new int[n+1, top];
            int max = n;
            nexts[n, 0] = n;
            for (int i = n - 1; i >= 0; i--)
            {
                while (xs[max] - xs[i] > l)
                {
                    max--;
                }
                nexts[i, 0] = max;
            }
            for(int i = 1; i < top; i++)
            {
                for(int j = n ; j >= 0; j--)
                {
                    if (j == n)
                    {
                        nexts[j, i] = n ;
                    }
                    else
                    {
                        nexts[j, i] = nexts[nexts[j, i - 1], i - 1];
                    }
                }
            }
            for(int i = 0; i < q; i++)
            {
                int now = abs[i][0];
                long cnt = 0;
                while (now < abs[i][1])
                {
                    bool moved = false;
                    for(int j = top - 1; j >= 0; j--)
                    {
                        if (nexts[now,j] > abs[i][1]) continue;
                        cnt += (long)Pow(2, j);
                        now = nexts[now, j];
                        moved = true;
                        break;
                    }
                    if (!moved)
                    {
                        cnt++;
                        now = nexts[now, 0];
                    }
                }
                WriteLine(cnt);
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
