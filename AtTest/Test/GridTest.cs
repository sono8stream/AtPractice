using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Test
{
    class GridTest
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int l = ReadInt();
            int n = (l + 1) / 4;
            int rI = 0;
            int cI = 0;
            int max = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    int row = i*2 + 2;
                    int column = j*2 + 2;
                    int cnt = (l - j * 3 - 2) * row
                        + (l - i * 3 - 2) * column;
                    if (cnt > max)
                    {
                        max = cnt;
                        rI = i;
                        cI = j;
                    }
                }
            }
            WriteLine(max + " " + rI + " " + cI);
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if ((i % 4 == 3 && i < rI * 4)
                        || (j % 4 == 3 && j < cI * 4))
                    {
                        Write('□');
                    }
                    else
                    {
                        Write('■');
                    }
                }
                WriteLine();
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
