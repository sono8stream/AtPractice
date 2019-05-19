using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_Challenge
{
    class _016_C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] HWhw = ReadInts();
            int H = HWhw[0];
            int W = HWhw[1];
            int h = HWhw[2];
            int w = HWhw[3];

            if (H % h == 0 && W % w == 0)
            {
                WriteLine("No");
                return;
            }

            bool rev = false;
            if (W % w == 0)
            {
                int tmp = H;
                int tmp2 = h;
                H = W;
                h = w;
                W = tmp;
                w = tmp2;
                rev = true;
            }

            int[] sums = new int[W];
            for (int i = 0; w - 1 + i * w < W; i++)
            {
                sums[w - 1 + i * w] = -(i + 1);
            }

            for(int i = 0; W - 1 - i * w >= 0; i++)
            {
                sums[W - 1 - i * w] = i + 1;
            }

            for (int i = W - 2; i >= 0; i--)
            {
                if (sums[i] == 0) sums[i] = sums[i + 1];
            }

            WriteLine("Yes");

            if (rev)
            {
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        if (i > 0) Write(sums[i] - sums[i - 1]);
                        else Write(sums[i]);
                        if (j < H - 1) Write(" ");
                    }
                    WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        if (j > 0) Write(sums[j] - sums[j - 1]);
                        else Write(sums[j]);
                        if (j < W - 1) Write(" ");
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
