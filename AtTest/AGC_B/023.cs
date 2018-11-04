using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_B
{
    class _023
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var sGrid = new int[n * 2, n * 2];
            for (int i = 0; i < n; i++)
            {
                string s = Read();
                for (int j = 0; j < n; j++)
                {
                    sGrid[i, j] = s[j]-'a';
                    sGrid[i, j + n] = s[j] - 'a';
                    sGrid[i + n, j] = s[j] - 'a';
                    sGrid[i + n, j  + n] = s[j] - 'a';
                }
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}