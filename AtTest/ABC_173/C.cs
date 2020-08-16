using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_173
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
            int[] hwk = ReadInts();
            int h = hwk[0];
            int w = hwk[1];
            int k = hwk[2];

            bool[,] grid = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for (int j = 0; j < w; j++)
                {
                    if (s[j] == '#')
                    {
                        grid[i, j] = true;
                    }
                }
            }

            int all = 1 << (h + w);
            int res = 0;
            for (int i = 0; i < all; i++)
            {
                int tmp = 0;
                for (int j = 0; j < h; j++)
                {
                    for(int l = 0; l < w; l++)
                    {
                        if((i&(1<<j))>0
                            || (i & (1 << (h + l))) > 0)
                        {
                            continue;
                        }

                        if (grid[j, l])
                        {
                            tmp++;
                        }
                    }
                }

                if (tmp == k)
                {
                    res++;
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
