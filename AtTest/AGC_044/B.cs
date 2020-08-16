using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_044
{
    class B
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
            int[] ps = ReadInts();

            bool[,] left = new bool[n, n];
            int[,] costs = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    costs[i, j] = Min(Min(i, (n - i - 1)), Min(j, n - j - 1));
                }
            }

            int res = 0;
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            for (int i = 0; i < n * n; i++)
            {
                int pos = ps[i] - 1;
                res += costs[pos / n, pos % n];
                left[pos / n, pos % n] = true;

                Queue<int> que = new Queue<int>();
                que.Enqueue(pos);
                while (que.Count > 0)
                {
                    int now = que.Dequeue();

                    int nextCost = costs[now / n, now % n];
                    if (!left[now / n, now % n])
                    {
                        nextCost++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int nextY = now / n + dy[j];
                        int nextX = now % n + dx[j];
                        if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= n
                            || costs[nextY, nextX] <= nextCost)
                        {
                            continue;
                        }

                        costs[nextY, nextX] = nextCost;
                        que.Enqueue(nextY * n + nextX);
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
