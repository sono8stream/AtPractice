using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _020
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] als = new int[n][];
            for(int i = 0; i < n; i++)
            {
                als[i] = ReadInts();
            }
            long b = ReadInt();
            long val = 0;
            for (int i = 0; i < n; i++)
            {
                long pow = 10;
                while (pow < als[i][0]) pow *= 10;
                for (int j = 0; j < als[i][1]; j++)
                {
                    val *= pow;
                    val += als[i][0];
                    val %= b;
                }
            }
            WriteLine(val);
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
