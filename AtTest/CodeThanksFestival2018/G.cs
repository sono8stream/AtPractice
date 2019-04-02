using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeThanksFestival2018
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            int[][] array = new int[n][];
            for(int i = 0; i < n; i++)
            {
                array[i] = new int[2] { aArray[i], bArray[i] };
            }
            Array.Sort(array, (a, b) => b[0] - a[0]);
            for(int i = 0; i < n; i++)
            {
                WriteLine(array[i][0] + " " + array[i][1]);
            }
            int[,] dp = new int[n, n];
            dp[0, 0] = array[0][0];

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
