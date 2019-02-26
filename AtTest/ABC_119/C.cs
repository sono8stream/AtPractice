using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_119
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nabc = ReadInts();
            int n = nabc[0];
            int[] tar = new int[3] { nabc[1], nabc[2], nabc[3] };
            int[] ls = new int[n];
            for(int i = 0; i < n; i++)
            {
                ls[i] = ReadInt();
            }
            int allPat = (int)Pow(4, n);
            int res = int.MaxValue;
            for(int i = 0; i < allPat; i++)
            {
                int[] vals = new int[3];
                int ii = i;
                int mp = 0;
                for(int j = 0; j < n; j++)
                {
                    if (ii % 4 < 3)
                    {
                        if (vals[ii % 4] > 0) mp += 10;
                        vals[ii % 4] += ls[j];
                    }
                    ii /= 4;
                }
                if (vals[0] == 0 || vals[1] == 0 || vals[2] == 0) continue;
                mp += Abs(tar[0] - vals[0]);
                mp += Abs(tar[1] - vals[1]);
                mp += Abs(tar[2] - vals[2]);
                res = Min(res, mp);
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
