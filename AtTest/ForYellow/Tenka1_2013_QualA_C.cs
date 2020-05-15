using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2013_QualA_C
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
            int[] mn = ReadInts();
            int m = mn[0];
            int n = mn[1];

            int unit = 9;
            if (m >= unit)
            {
                m = unit + (m - unit) % 4;
            }
            if (n >= unit)
            {
                n = unit + (n - unit) % 4;
            }

            int pats = 0;
            int[,] tmp = new int[n, m];
            DFS(0, 0, ref pats, ref tmp);

            WriteLine(pats);
        }

        static void DFS(int x, int y, ref int pats, ref int[,] tmp)
        {
            if (x == tmp.GetLength(1))
            {
                x = 0;
                y++;
            }
            if (y == tmp.GetLength(0))
            {
                pats++;
                return;
            }

            if ((x == 0 || tmp[y, x - 1] != 1) && (y == 0 || tmp[y - 1, x] != 1))
            {
                tmp[y, x] = 1;
                DFS(x+1, y, ref pats, ref tmp);
            }
            if ((x == 0 || (x == 1 && tmp[y, x - 1] != 2)
                || (x > 1 && tmp[y, x - 1] != 2 && tmp[y, x - 2] != 2))
                && (y == 0 || (y == 1 && tmp[y - 1, x] != 2)
                || (y > 1 && tmp[y - 1, x] != 2 && tmp[y - 2, x] != 2)))
            {
                tmp[y, x] = 2;
                DFS(x + 1,y, ref pats, ref tmp);
            }
            if ((x == 0 || (x == 1 && tmp[y, x - 1] != 3)
                || (x == 2 && tmp[y, x - 1] != 3 && tmp[y, x - 2] != 3)
                || (x > 2 && tmp[y, x - 1] != 3 && tmp[y, x - 2] != 3 && tmp[y, x - 3] != 3))
                && (y == 0 || (y == 1 && tmp[y - 1, x] != 3)
                || (y == 2 && tmp[y - 1, x] != 3 && tmp[y - 2, x] != 3)
                || (y > 2 && tmp[y - 1, x] != 3 && tmp[y - 2, x] != 3 && tmp[y - 3, x] != 3)))
            {
                tmp[y, x] = 3;
                DFS(x + 1,y, ref pats, ref tmp);
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
