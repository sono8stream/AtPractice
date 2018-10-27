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
            var whites = new int[k * 2, k * 2];
            var blacks = new int[k * 2, k * 2];
            for (int i = 0; i < n; i++)
            {
                string[] input = Read().Split(' ');
                int x = int.Parse(input[0]) % (k * 2);
                int y = int.Parse(input[1]) % (k * 2);
                if (input[2][0] == 'W')
                {
                    whites[y, x]++;
                }
                else
                {
                    blacks[y, x]++;
                }
            }
            var whiteSums = new int[k * 2, k * 2];
            var blackSums = new int[k * 2, k * 2];
            string white = "";
            string black = "";
            for (int i = 0; i < k * 2; i++)
            {
                for (int j = 0; j < k * 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        whiteSums[0, 0] = whites[0, 0];
                        blackSums[0, 0] = blacks[0, 0];
                    }
                    else if (i == 0)
                    {
                        whiteSums[i, j] = whiteSums[i, j - 1] + whites[i, j];
                        blackSums[i, j] = blackSums[i, j - 1] + blacks[i, j];
                    }
                    else if (j == 0)
                    {
                        whiteSums[i, j] = whiteSums[i - 1, j] + whites[i, j];
                        blackSums[i, j] = blackSums[i - 1, j] + blacks[i, j];
                    }
                    else
                    {
                        whiteSums[i, j] =
                            whiteSums[i - 1, j] + whiteSums[i, j - 1]
                            - whiteSums[i - 1, j - 1] + whites[i, j];
                        blackSums[i, j] =
                            blackSums[i - 1, j] + blackSums[i, j - 1]
                            - blackSums[i - 1, j - 1] + blacks[i, j];
                    }
                    white += whiteSums[i, j] + " ";
                    black += blackSums[i, j] + " ";
                }
                white += Environment.NewLine;
                black += Environment.NewLine;
            }
            Console.WriteLine(white);
            Console.WriteLine(black);

            int max = 0;
            for (int i = 0; i < k * 2; i++)
            {
                for (int j = 0; j < k * 2; j++)
                {
                    int cnt = 0;
                    cnt += RectSum(whiteSums, k + i, k + j, k);
                    cnt += RectSum(whiteSums, i, k + j, k);
                    cnt += RectSum(whiteSums, k - i, k + j, k);
                    cnt += RectSum(whiteSums, k + i, j, k);
                    cnt += RectSum(whiteSums, i, j, k);
                    cnt += RectSum(whiteSums, k - i, j, k);
                    cnt += RectSum(whiteSums, k + i, k - j, k);
                    cnt += RectSum(whiteSums, i, k - j, k);
                    cnt += RectSum(whiteSums, k - i, k - j, k);
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
                sum -= sumGrid[y - 1, xR];
            }
            if (0 < x)
            {
                sum -= sumGrid[yR, x - 1];
            }
            if (0 < x && 0 < y)
            {
                sum += sumGrid[y - 1, x - 1];
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
