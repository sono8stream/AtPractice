using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2017FinalC
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            int[] cnts = new int[13];
            for (int i = 0; i < n; i++)
            {
                cnts[array[i]]++;
            }
            if (cnts[0] > 0 || cnts[12] >= 2)
            {
                WriteLine(0);
                return;
            }

            bool[] on = new bool[25];
            on[0] = true;
            on[24] = true;
            List<int> vals = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                if (cnts[i] >= 3)
                {
                    WriteLine(0);
                    return;
                }
                if (cnts[i] == 2)
                {
                    on[i] = true;
                    on[24 - i] = true;
                }
                if (cnts[i] == 1)
                {
                    vals.Add(i);
                }
            }
            int allPat = 1 << vals.Count;
            int res = 0;
            for(int i = 0; i < allPat; i++)
            {
                bool[] onTemp = new bool[25];
                for(int j = 0; j <= 24; j++)
                {
                    onTemp[j] = on[j];
                }
                for(int j = 0; j < vals.Count; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        onTemp[vals[j]] = true;
                    }
                    else
                    {
                        onTemp[24 - vals[j]] = true;
                    }
                }
                int tmp = 0;
                int min = 24;
                for (int j = 1; j <= 24; j++)
                {
                    if (onTemp[j])
                    {
                        min = Min(min, j - tmp);
                        tmp = j;
                    }
                }
                res = Max(res, min);
            }
            WriteLine(res);
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
