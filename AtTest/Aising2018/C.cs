using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Aising2018
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            var black = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for (int j = 0; j < w; j++)
                {
                    black[i, j] = s[j] == '#';
                }
            }
            long cnt = 0;
            var visited = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (visited[i, j]) continue;
                    long blackCnt = 0;
                    long allCnt
                        = DFS(black, ref visited, h, w, i, j, ref blackCnt);
                    cnt += (allCnt - blackCnt) * blackCnt;
                }
            }
            Console.WriteLine(cnt);
        }

        static int DFS(bool[,] black, ref bool[,] visited,
            int h, int w, int i, int j, ref long blackCnt)
        {
            visited[i, j] = true;
            bool nowBlack = black[i, j];
            if (nowBlack) blackCnt++;
            int cnt = 1;
            if (i > 0 && nowBlack != black[i - 1, j] && !visited[i - 1, j])
            {
                cnt += DFS(black, ref visited, h, w, i - 1, j,ref blackCnt);
            }
            if (j > 0 && nowBlack != black[i, j - 1] && !visited[i, j - 1])
            {
                cnt += DFS(black, ref visited, h, w, i, j - 1, ref blackCnt);
            }
            if (i < h - 1 && nowBlack != black[i + 1, j] && !visited[i + 1, j])
            {
                cnt += DFS(black, ref visited, h, w, i + 1, j, ref blackCnt);
            }
            if (j < w - 1 && nowBlack != black[i, j + 1] && !visited[i, j + 1])
            {
                cnt += DFS(black, ref visited, h, w, i, j + 1, ref blackCnt);
            }
            return cnt;
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
