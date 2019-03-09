using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_121
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nmc = ReadInts();
            int n = nmc[0];
            int m = nmc[1];
            int c = nmc[2];
            int[] bs = ReadInts();
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                int[] array = ReadInts();
                int tmp = 0;
                for(int j = 0; j < m; j++)
                {
                    tmp += array[j] * bs[j];
                }
                tmp += c;
                if (tmp > 0) res++;
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
