using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC006_D
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            bool[,] grid = new bool[h, w];
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == 'o';
                }
            }

            bool[,] a = new bool[7, 7];
            a[1, 3] = true;
            a[2, 2] = true;
            a[2, 4] = true;
            a[3, 1] = true;
            a[3, 5] = true;
            a[4, 1] = true;
            a[4, 2] = true;
            a[4, 3] = true;
            a[4, 4] = true;
            a[4, 5] = true;
            a[5, 1] = true;
            a[5, 5] = true;

            bool[,] b = new bool[7, 7];
            b[1, 1] = true;
            b[1, 2] = true;
            b[1, 3] = true;
            b[1, 4] = true;
            b[2, 1] = true;
            b[2, 5] = true;
            b[3, 1] = true;
            b[3, 2] = true;
            b[3, 3] = true;
            b[3, 4] = true;
            b[4, 1] = true;
            b[4, 5] = true;
            b[5, 1] = true;
            b[5, 2] = true;
            b[5, 3] = true;
            b[5, 4] = true;

            bool[,] c = new bool[7, 7];
            c[1, 2] = true;
            c[1, 3] = true;
            c[1, 4] = true;
            c[2, 1] = true;
            c[2, 5] = true;
            c[3, 1] = true;
            c[4, 1] = true;
            c[4, 5] = true;
            c[5, 2] = true;
            c[5, 3] = true;
            c[5, 4] = true;

            int[] res = new int[3];
            bool[,] used = new bool[h, w];
            int[] dx = new int[8] { 1, 1, 0,  -1, -1, -1, 0, 1 };
            int[] dy = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (!grid[i, j] || used[i, j])
                    {
                        continue;
                    }

                    int minX = j;
                    int maxX = j;
                    int minY = i;
                    int maxY = i;
                    Queue<int[]> que = new Queue<int[]>();
                    que.Enqueue(new int[2] { i, j });
                    while (que.Count > 0)
                    {
                        int[] pos = que.Dequeue();
                        int x = pos[1];
                        int y = pos[0];
                        if (used[y, x])
                        {
                            continue;
                        }

                        used[y, x] = true;
                        minX = Min(minX, x);
                        maxX = Max(maxX, x);
                        minY = Min(minY, y);
                        maxY = Max(maxY, y);

                        for (int k = 0; k < 8; k++)
                        {
                            int toX = x + dx[k];
                            int toY = y + dy[k];
                            if (0 <= toX && toX < w && 0 <= toY && toY < h
                                && grid[toY, toX] && !used[toY, toX])
                            {
                                que.Enqueue(new int[2] { toY, toX });
                            }
                        }
                    }

                    int wTmp = maxX - minX + 1;
                    int hTmp = maxY - minY + 1;
                    if (wTmp == hTmp && wTmp % 5 == 0)
                    {
                        int size = wTmp / 5;

                        if (minX < size || maxX >= w - size
                            || minY < size || maxY >= h - size)
                        {
                            continue;
                        }

                        var pats = new List<bool[][,]>();
                        pats.Add(Rotates(Multiply(a, size)));
                        pats.Add(Rotates(Multiply(b, size)));
                        pats.Add(Rotates(Multiply(c, size)));
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (Match(grid, minX - size, minY - size, pats[k][l]))
                                {
                                    res[k]++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            WriteLine(string.Join(" ", res));
        }

        static bool[,] Multiply(bool[,] origin,int rate)
        {
            int h = origin.GetLength(0) * rate;
            int w = origin.GetLength(1) * rate;
            bool[,] res = new bool[h, w];

            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    res[i, j] = origin[i / rate, j / rate];
                }
            }

            return res;
        }

        static bool[][,] Rotates(bool[,] origin)
        {
            int h = origin.GetLength(0);
            int w = origin.GetLength(1);
            bool[][,] res = new bool[4][,];
            for(int i = 0; i < 4; i++)
            {
                res[i] = new bool[h, w];
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    res[0][i, j] = origin[i, j];
                    res[1][j, h - 1 - i] = origin[i, j];
                    res[2][h - 1 - i, w - 1 - j] = origin[i, j];
                    res[3][w - 1 - j, i] = origin[i, j];
                }
            }

            return res;
        }

        static bool Match(bool[,]grid,int x,int y,bool[,] origin)
        {
            int deltaH = origin.GetLength(0);
            int deltaW = origin.GetLength(1);

            for (int i = y; i < y + deltaH; i++)
            {
                for (int j = x; j < x + deltaW; j++)
                {
                    if (grid[i, j] == origin[i - y, j - x])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
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
