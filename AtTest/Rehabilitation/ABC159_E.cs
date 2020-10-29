using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class ABC159_E
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
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '1';
                }
            }

            int all = 1 << (h - 1);
            int res = int.MaxValue;
            for (int i = 0; i < all; i++)
            {
                List<int> parts = new List<int>();
                for (int j = 0; j < h - 1; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        parts.Add(j);
                    }
                }
                parts.Add(h - 1);

                int[] cnts = new int[parts.Count];
                bool can = true;
                int tmp = parts.Count - 1;
                for(int j = 0; j < w; j++)
                {
                    int now = 0;
                    int[] deltas = new int[parts.Count];
                    for(int l = 0; l < h; l++)
                    {
                        if (grid[l, j])
                        {
                            deltas[now]++;
                        }
                        if (l == parts[now])
                        {
                            now++;
                        }
                    }

                    bool divide = false;
                    for (int l = 0; l < deltas.Length; l++)
                    {
                        if (deltas[l] > k)
                        {
                            can = false;
                            break;
                        }

                        if (cnts[l] + deltas[l] > k)
                        {
                            divide = true;
                        }
                    }
                    if (!can)
                    {
                        break;
                    }
                    if (divide)
                    {
                        tmp++;
                        for (int l = 0; l < cnts.Length; l++)
                        {
                            cnts[l] = deltas[l];
                        }
                    }
                    else
                    {
                        for(int l = 0; l < cnts.Length; l++)
                        {
                            cnts[l] += deltas[l];
                        }
                    }
                }

                if (can)
                {
                    res = Min(res, tmp);
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
