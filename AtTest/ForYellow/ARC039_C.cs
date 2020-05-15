using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC039_C
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
            int k = ReadInt();
            var dict = new Dictionary<long, long[]>();
            long x = 500000;
            long y = 500000;
            dict.Add(Pos(x, y), Neighbors(x, y));

            string s = Read();
            for(int i = 0; i < k; i++)
            {
                long pos = Pos(x, y);
                if (s[i] == 'R')
                {
                    while (dict.ContainsKey(pos))
                    {
                        pos = dict[pos][0];
                    }
                }
                if (s[i] == 'U')
                {
                    while (dict.ContainsKey(pos))
                    {
                        pos = dict[pos][1];
                    }
                }
                if (s[i] == 'L')
                {
                    while (dict.ContainsKey(pos))
                    {
                        pos = dict[pos][2];
                    }
                }
                if (s[i] == 'D')
                {
                    while (dict.ContainsKey(pos))
                    {
                        pos = dict[pos][3];
                    }
                }
                x = pos % 1000000;
                y = pos / 1000000;
                long[] neighbors = Neighbors(x,y);
                for(int j = 0; j < 4; j++)
                {
                    while (dict.ContainsKey(neighbors[j]))
                    {
                        neighbors[j] = dict[neighbors[j]][j];
                    }
                }
                dict.Add(pos, neighbors);
            }

            WriteLine((x - 500000) + " " + (y - 500000));
        }

        static long Pos(long x, long y)
        {
            long val = x + y * 1000000;
            return val;
        }

        static long[] Neighbors(long x,long y)
        {
            return new long[4] { Pos(x + 1, y), Pos(x, y + 1), Pos(x - 1, y), Pos(x, y - 1) };
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
