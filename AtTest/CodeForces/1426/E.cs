using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1426
{
    class E
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
            int n = ReadInt();
            int[] arrayA = ReadInts();
            int[] arrayB = ReadInts();

            int[][] pats = new int[6][];
            pats[0] = new int[3] { 0, 1, 2 };
            pats[1] = new int[3] { 0, 2, 1 };
            pats[2] = new int[3] { 1, 0, 2 };
            pats[3] = new int[3] { 1, 2, 0 };
            pats[4] = new int[3] { 2, 0, 1 };
            pats[5] = new int[3] { 2, 1, 0 };

            int min = int.MaxValue;
            int max = 0;
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    int cnt = 0;
                    int[] tmpA = new int[3] { arrayA[0], arrayA[1], arrayA[2] };
                    int[] tmpB = new int[3] { arrayB[0], arrayB[1], arrayB[2] };
                    for (int x = 0; x < 3; x++)
                    {
                        for(int y = 0; y < 3; y++)
                        {
                            int common = Min(tmpA[pats[i][x]], tmpB[pats[j][y]]);
                            tmpA[pats[i][x]] -= common;
                            tmpB[pats[j][y]] -= common;
                            if ((pats[i][x] + 1) % 3 == pats[j][y])
                            {
                                cnt += common;
                            }
                        }
                    }
                    min = Min(min, cnt);
                    max = Max(max, cnt);
                }
            }

            /*
            int min = 0;
            {
                int[] tmpA = new int[3] { arrayA[0], arrayA[1], arrayA[2] };
                int[] tmpB = new int[3] { arrayB[0], arrayB[1], arrayB[2] };
                for(int i = 0; i < 3; i++)
                {
                    int common = Min(tmpA[i], tmpB[(i + 2) % 3]);
                    tmpA[i] -= common;
                    tmpB[(i + 2) % 3] -= common;
                }
                for(int i = 0; i < 3; i++)
                {
                    int common = Min(tmpA[i], tmpB[i]);
                    tmpA[i] -= common;
                    tmpB[i] -= common;
                }
                for(int i = 0; i < 3; i++)
                {
                    min += tmpA[i];
                }
            }

            int max = 0;
            {
                for (int i = 0; i < 3; i++)
                {
                    max+= Min(arrayA[i], arrayB[(i +1) % 3]);
                }
            }
            */

            WriteLine(min + " " + max);
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
