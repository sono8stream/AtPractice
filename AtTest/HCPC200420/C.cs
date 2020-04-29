using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC200420
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
            int[] hwd = ReadInts();
            int h = hwd[0];
            int w = hwd[1];
            int d = hwd[2];
            bool[,] grid = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for (int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                }
            }

            int res = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j + d - 1 < w; j++)
                {
                    bool ok = true;
                    for(int k = 0; k < d; k++)
                    {
                        if (grid[i, j + k])
                        {
                            continue;
                        }

                        ok = false;
                        break;
                    }
                    if (ok)
                    {
                        res++;
                    }
                }
            }
            for (int i = 0; i + d - 1 < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    bool ok = true;
                    for(int k = 0; k < d; k++)
                    {
                        if (grid[i + k, j])
                        {
                            continue;
                        }

                        ok = false;
                        break;
                    }
                    if (ok)
                    {
                        res++;
                    }
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
