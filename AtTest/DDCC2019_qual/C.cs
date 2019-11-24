using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DDCC2019_qual
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
            int[,] res = new int[h, w];
            int cnt = 0;
            bool find = false;
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    if (s[j] == '#')
                    {
                        cnt++;
                        res[i, j] = cnt;
                        if (!find)
                        {
                            find = true;
                            for(int l = 0; l < j; l++)
                            {
                                res[i, l] = cnt;
                            }
                        }
                    }
                    else if(find)
                    {
                        res[i, j] = cnt;
                    }
                }
                find = false;
            }
            find = false;
            int now = 0;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (res[j, i] > 0)
                    {
                        now = res[j, i];
                        if (!find)
                        {
                            find = true;
                            for(int l = 0; l < j; l++)
                            {
                                res[l, i] = now;
                            }
                        }
                    }
                    else if (find)
                    {
                        res[j,i] = now;
                    }
                }
                find = false;
            }
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    Write(res[i, j] + " ");
                }
                WriteLine();
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
