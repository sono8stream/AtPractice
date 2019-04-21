using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class MPC2018_D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            //0: 未利用，1: 終了, 2: 無限
            int res = 0;
            int[,] states = new int[1000, 1000];
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= m; j++)
                {
                    DFS(i, j, states);
                    if (states[i, j] == 2) res++;
                }
            }

            Console.WriteLine(res);
        }

        static int DFS(int x, int y, int[,] states)
        {
            if (states[x, y] > 0) return states[x, y];

            if (x == 0 || y == 0)
            {
                states[x, y] = 1;
            }
            else
            {
                int nextX = x;
                int nextY = y;

                if (nextX<nextY) nextX = Reverse(nextX);
                else nextY = Reverse(nextY);

                if (nextX < nextY) nextY -= nextX;
                else nextX -= nextY;

                states[x, y] = 2;
                states[x, y] = DFS(nextX, nextY, states);
            }
            return states[x, y];
        }

        static int Reverse(int x)
        {
            if (x < 10) return x;
            else if (x < 100) return x / 10 + (x % 10) * 10;
            else return x / 100 + ((x % 100) / 10) * 10 + (x % 10) * 100;
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
