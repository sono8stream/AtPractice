using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1440
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
            for (int i = 0; i < t; i++)
            {
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                int[,] grid = new int[n, m];
                for(int j = 0; j < n; j++)
                {
                    string s = Read();
                    for(int k = 0; k < m; k++)
                    {
                        grid[j, k] = s[k] == '0' ? 0 : 1;
                    }
                }

                List<int[]> res = new List<int[]>();
                
                if (n % 2 == 1 && m % 2 == 1)
                {
                    if (grid[0, 0] == 1)
                    {
                        res.Add(new int[6] { 0, 0, 0, 1, 1, 0 });
                        grid[0, 0] = 0;
                        grid[0, 1] = grid[0, 1] == 1 ? 0 : 1;
                        grid[1, 0] = grid[1, 0] == 1 ? 0 : 1;
                    }
                }
                if (n % 2 == 1)
                {
                    for(int j = m - 2; j >= 0; j -= 2)
                    {
                        if (grid[0, j] == 1 && grid[0, j + 1] == 1)
                        {
                            res.Add(new int[6] { 0, j, 0, j + 1, 1, j });
                            grid[0, j] = 0;
                            grid[0, j + 1] = 0;
                            grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                        }
                        else if (grid[0, j] == 1)
                        {
                            res.Add(new int[6] { 0, j, 1, j, 1, j+1 });
                            grid[0, j] = 0;
                            grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                            grid[1, j + 1] = grid[1, j + 1] == 1 ? 0 : 1;
                        }
                        else if (grid[0, j + 1] == 1)
                        {
                            res.Add(new int[6] { 0, j+1, 1, j, 1, j+1 });
                            grid[0, j + 1] = 0;
                            grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                            grid[1, j + 1] = grid[1, j + 1] == 1 ? 0 : 1;
                        }
                    }
                }
                if (m % 2 == 1)
                {
                    for (int j = n - 2; j >= 0; j -= 2)
                    {
                        if (grid[j, 0] == 1 && grid[j + 1, 0] == 1)
                        {
                            res.Add(new int[6] { j, 0, j + 1, 0, j, 1 });
                            grid[j, 0] = 0;
                            grid[j + 1, 0] = 0;
                            grid[j, 1] = grid[j, 1] == 1 ? 0 : 1;
                        }
                        else if (grid[j, 0] == 1)
                        {
                            res.Add(new int[6] { j, 0, j, 1, j + 1, 1 });
                            grid[j, 0] = 0;
                            grid[j, 1] = grid[j, 1] == 1 ? 0 : 1;
                            grid[j + 1, 1] = grid[j + 1, 1] == 1 ? 0 : 1;
                        }
                        else if (grid[j + 1, 0] == 1)
                        {
                            res.Add(new int[6] { j + 1, 0, j, 1, j + 1, 1 });
                            grid[j + 1, 0] = 0;
                            grid[j, 1] = grid[j, 1] == 1 ? 0 : 1;
                            grid[j + 1, 1] = grid[j + 1, 1] == 1 ? 0 : 1;
                        }
                    }
                }
                int[] dx = new int[4] { 0, 1, 1, 0 };
                int[] dy = new int[4] { 0, 0, 1, 1 };
                for (int j = n - 2; j >= 0; j -= 2)
                {
                    for (int k = m - 2; k >= 0; k -= 2)
                    {
                        Queue<int> ones = new Queue<int>();
                        Queue<int> zeros = new Queue<int>();
                        for (int l = 0; l < 4; l++)
                        {
                            int x = j + dx[l];
                            int y = k + dy[l];
                            if (grid[x, y] == 1)
                            {
                                ones.Enqueue(l);
                            }
                            else
                            {
                                zeros.Enqueue(l);
                            }
                        }

                        if (ones.Count == 4)
                        {
                            List<int[]> poses = new List<int[]>();
                            while (ones.Count > 1)
                            {
                                int now = ones.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                zeros.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                        }
                        if (ones.Count == 1)
                        {
                            List<int[]> poses = new List<int[]>();
                            while (ones.Count > 0)
                            {
                                int now = ones.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                zeros.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            while (zeros.Count > 2)
                            {
                                int now = zeros.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                ones.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                        }
                        if (ones.Count == 2)
                        {
                            List<int[]> poses = new List<int[]>();
                            while (ones.Count > 1)
                            {
                                int now = ones.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                zeros.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            while (zeros.Count > 1)
                            {
                                int now = zeros.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                ones.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                        }
                        if (ones.Count == 3)
                        {
                            List<int[]> poses = new List<int[]>();
                            while (ones.Count > 0)
                            {
                                int now = ones.Dequeue();
                                int x = j + dx[now];
                                int y = k + dy[now];
                                grid[x, y] = 0;
                                zeros.Enqueue(now);
                                poses.Add(new int[2] { x, y });
                            }
                            res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                        }
                    }
                }
                
                /*
                for(int j = 0; j < n-1; j++)
                {
                    for(int k = 0; k < m-1; k++)
                    {
                        if (j == n - 2 && k == m - 2)
                        {
                            int[] dx = new int[4] { 0, 1, 1, 0 };
                            int[] dy = new int[4] { 0, 0, 1, 1 };

                            Queue<int> ones = new Queue<int>();
                            Queue<int> zeros = new Queue<int>();
                            for (int l = 0; l < 4; l++)
                            {
                                int x = j + dx[l];
                                int y = k + dy[l];
                                if (grid[x, y] == 1)
                                {
                                    ones.Enqueue(l);
                                }
                                else
                                {
                                    zeros.Enqueue(l);
                                }
                            }

                            if (ones.Count == 4)
                            {
                                List<int[]> poses = new List<int[]>();
                                while (ones.Count > 1)
                                {
                                    int now = ones.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    zeros.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                            }
                            if (ones.Count == 1)
                            {
                                List<int[]> poses = new List<int[]>();
                                while (ones.Count > 0)
                                {
                                    int now = ones.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    zeros.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                while (zeros.Count > 2)
                                {
                                    int now = zeros.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    ones.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                            }
                            if (ones.Count == 2)
                            {
                                List<int[]> poses = new List<int[]>();
                                while (ones.Count > 1)
                                {
                                    int now = ones.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    zeros.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                while (zeros.Count > 1)
                                {
                                    int now = zeros.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    grid[x, y] = 0;
                                    ones.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                            }
                            if (ones.Count == 3)
                            {
                                List<int[]> poses = new List<int[]>();
                                while (ones.Count > 0)
                                {
                                    int now = ones.Dequeue();
                                    int x = j + dx[now];
                                    int y = k + dy[now];
                                    zeros.Enqueue(now);
                                    poses.Add(new int[2] { x, y });
                                }
                                res.Add(new int[6] { poses[0][0],poses[0][1],poses[1][0],
                                poses[1][1],poses[2][0],poses[2][1]});
                            }
                        }
                        else if (j == n - 2)
                        {
                            if (grid[j, k] == 1 && grid[j + 1, k] == 1)
                            {
                                res.Add(new int[6] { j, k, j + 1, k, j, k + 1 });
                                grid[j, k + 1] = grid[j, k + 1] == 1 ? 0 : 1;
                            }
                            else if (grid[j, k] == 1)
                            {
                                res.Add(new int[6] { j, k, j, k+1, j + 1, k+1 });
                                grid[j,k+ 1] = grid[j, k+1] == 1 ? 0 : 1;
                                grid[j + 1,k+ 1] = grid[j + 1,k+1] == 1 ? 0 : 1;
                            }
                            else if (grid[j + 1, 0] == 1)
                            {
                                res.Add(new int[6] { j + 1, 0, j, 1, j + 1, 1 });
                                grid[j + 1, 0] = 0;
                                grid[j, 1] = grid[j, 1] == 1 ? 0 : 1;
                                grid[j + 1, 1] = grid[j + 1, 1] == 1 ? 0 : 1;
                            }

                        }
                        else if (k == m - 2)
                        {
                            if (grid[0, j] == 1 && grid[0, j + 1] == 1)
                            {
                                res.Add(new int[6] { 0, j, 0, j + 1, 1, j });
                                grid[0, j] = 0;
                                grid[0, j + 1] = 0;
                                grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                            }
                            else if (grid[0, j] == 1)
                            {
                                res.Add(new int[6] { 0, j, 1, j, 1, j + 1 });
                                grid[0, j] = 0;
                                grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                                grid[1, j + 1] = grid[1, j + 1] == 1 ? 0 : 1;
                            }
                            else if (grid[0, j + 1] == 1)
                            {
                                res.Add(new int[6] { 0, j + 1, 1, j, 1, j + 1 });
                                grid[0, j + 1] = 0;
                                grid[1, j] = grid[1, j] == 1 ? 0 : 1;
                                grid[1, j + 1] = grid[1, j + 1] == 1 ? 0 : 1;
                            }
                        }
                        else
                        {
                            if (grid[j, k] == 1)
                            {

                            }
                        }
                    }
                }
                */

                WriteLine(res.Count);
                for(int j = 0; j < res.Count; j++)
                {
                    for(int k = 0; k < 6; k++)
                    {
                        Write(res[j][k]+1);
                        if (k + 1 < 6)
                        {
                            Write(" ");
                        }
                    }
                    WriteLine();
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
