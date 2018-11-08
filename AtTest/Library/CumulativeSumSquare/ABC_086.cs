using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_086
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            var blacks = new int[n][];//すべてbに落とし込む
            var blackGrid = new int[k * 2, k * 2];
            var bws = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string[] input = Read().Split(' ');
                int x = int.Parse(input[0]) % (k * 2);
                int y = int.Parse(input[1]) % (k * 2);
                bool black = input[2][0] == 'B';
                if (!black)
                {
                    x += k;
                    x %= k * 2;
                }
                blacks[i] = new int[2] { x, y };
                blackGrid[x, y]++;
            }
            var blackSums = new int[k * 2, k * 2];//x,yに黒の起点があるときの個数
            for(int x=0; x < k * 2; x++)//2次元累積和
            {
                for (int y = 0; y < k * 2; y++)
                {
                    blackSums[x, y] = blackGrid[x, y];

                    if (x > 0)
                    {
                        blackSums[x, y] += blackSums[x - 1, y];
                    }
                    if (y > 0)
                    {
                        blackSums[x, y] += blackSums[x, y - 1];
                    }
                    if (x > 0 && y > 0)
                    {
                        blackSums[x, y] -= blackSums[x - 1, y - 1];
                    }
                }
            }

            int max = 0;
            for (int x = 0; x < k * 2; x++)
            {
                for (int y = 0; y < k * 2; y++)
                {
                    if (k <= x && k <= y) continue;
                    int cnt = 0;
                    cnt += RectSum(blackSums, x, y, k);
                    cnt += RectSum(blackSums, x + k, y + k, k);
                    cnt += RectSum(blackSums, x - k, y - k, k);
                    cnt += RectSum(blackSums, x + k, y - k, k);
                    cnt += RectSum(blackSums, x - k, y + k, k);
                    cnt += RectSum(blackSums, x - k * 2, y, k);
                    cnt += RectSum(blackSums, x, y - k * 2, k);
                    max = Math.Max(max, cnt);
                }
            }
            Console.WriteLine(max);
        }

        static int RectSum(int[,] sumGrid, int x, int y, int k)
        {
            int xR = Math.Min(x + k - 1, k * 2 - 1);
            int yR = Math.Min(y + k - 1, k * 2 - 1);
            if (xR < 0 || yR < 0) return 0;
            if (k * 2 <= x || k * 2 <= y) return 0;
            int sum = sumGrid[xR, yR];
            if (0 < y)
            {
                sum -= sumGrid[xR, y - 1];
            }
            if (0 < x)
            {
                sum -= sumGrid[x - 1, yR];
            }
            if (0 < x && 0 < y)
            {
                sum += sumGrid[x - 1, y - 1];
            }
            return sum;
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
