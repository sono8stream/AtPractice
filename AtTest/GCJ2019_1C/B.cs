using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2019_1C
{
    class B
    {
        static int max = 119;
        static int chars = 5;
        static int[][] cnts;

        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] tf = ReadInts();
            int t = tf[0];
            int f = tf[1];
            cnts = new int[max][];
            for (int i = 0; i < max; i++) cnts[i] = new int[chars];
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
        }

        static Action Solve()
        {
            for(int i = 0; i < max; i++)
            {
                for (int j = 0; j < chars; j++) cnts[i][j] = 0;
            }
            int[][] charCnts = new int[3][];
            for (int i = 0; i < 3; i++) charCnts[i] = new int[chars];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < max; j++)
                {
                    WriteLine(i + 1 + j * chars);
                    char c = Read()[0];
                    cnts[j][i] = c - 'A';
                    charCnts[i][c - 'A']++;
                }
            }
            bool[] used = new bool[chars];
            List<char> res = new List<char>();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < chars; j++)
                {
                    if (charCnts[i][j] == 23)
                    {
                        used[j] = true;
                        res.Add((char)('A' + j));
                        break;
                    }
                }
            }

            for(int i = 0; i < max; i++)
            {
                int cnt = 0;
                for(int j = 0; j < 3; j++)
                {
                    if (cnts[i][j] == (res[j] - 'A')) cnt++;
                }
                if (cnt == 3)
                {
                    WriteLine(i * chars + 4);
                    char c = Read()[0];
                    used[c - 'A'] = true;
                    for(int j = 0; j < chars; j++)
                    {
                        if (!used[j]) res.Add((char)('A' + j));
                    }
                    res.Add(c);
                    break;
                }
            }

            WriteLine(res.ToArray());
            ReadLine();

            return () => WriteLine();
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
