using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Virtual
{
    class ABC094_C
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
            int[][] array2 = new int[n][];
            for(int i = 0; i < n; i++)
            {
                array2[i] = new int[3] { array[i], i, 0 };
            }
            Array.Sort(array2, (a, b) => a[0] - b[0]);
            for(int i = 0; i < n; i++)
            {
                if (i < n / 2) array2[i][2] = array2[n / 2][0];
                else array2[i][2] = array2[n / 2 - 1][0];
            }
            Array.Sort(array2, (a, b) => a[1] - b[1]);
            for(int i =0; i < n; i++)
            {
                WriteLine(array2[i][2]);
            }
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
