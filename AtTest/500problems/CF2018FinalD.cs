using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2018FinalD
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            char[][] strs = new char[n][];
            for(int i = 0; i < n; i++)
            {
                strs[i] = Read().ToCharArray();
            }
            int[,,] cnts = new int[52, 52, 52];
            for(int i = 0; i < n; i++)
            {
                var dp = new Dictionary<int, bool>();
                int val = 0;
                val += GetNo(strs[i][0]) * 10000
                    + GetNo(strs[i][1]) * 100
                    + GetNo(strs[i][2]);
                dp.Add(val, true);
                for(int j = 3; j < strs[i].Length; j++)
                {
                    var next = new Dictionary<int, bool>();
                    int now = GetNo(strs[i][j]);
                    foreach(int key in dp.Keys)
                    {
                        if (!next.ContainsKey(key))
                        {
                            next.Add(key, true);
                        }
                        int nextVal = (key % 10000) * 100 + now;
                        if (!next.ContainsKey(nextVal))
                        {
                            next.Add(nextVal, true);
                        }
                    }
                    dp = next;
                }
                foreach(int key in dp.Keys)
                {
                    cnts[key / 10000, (key % 10000) / 100, key % 100]++;
                }
            }
            int[] maxI = new int[3] { 0, 0, 0 };
            for(int i = 0; i < 52; i++)
            {
                for(int j = 0; j < 52; j++)
                {
                    for(int k = 0; k < 52; k++)
                    {
                        if (cnts[i, j, k] > cnts[maxI[0], maxI[1], maxI[2]])
                        {
                            maxI[0] = i;
                            maxI[1] = j;
                            maxI[2] = k;
                        }
                    }
                }
            }
            for(int i = 0; i < 3; i++)
            {
                if (maxI[i] < 26) Write((char)('A' + maxI[i]));
                else Write((char)('a' + maxI[i] - 26));
            }
            WriteLine();
        }

        static int GetNo(char c)
        {
            if ('A' <= c && c <= 'Z') return c - 'A';
            else return (c - 'a') + 26;
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
