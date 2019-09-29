using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.PGBattle2019
{
    class D
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
            int n = ReadInt();
            long[] array = ReadLongs();
            long cost = 0;
            for(int i = 1; i < n - 1; i++)
            {
                if (array[i - 1] > array[i] && array[i] < array[i + 1])
                {
                    long target = Min(array[i - 1], array[i + 1]);
                    cost += target - array[i];
                    array[i] = target;
                }
                else if (array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    long target = Max(array[i - 1], array[i + 1]);
                    cost += array[i] - target;
                    array[i] = target;
                }
            }
            for(int i = 0; i < n - 1; i++)
            {
                cost += Abs(array[i + 1] - array[i]);
            }
            WriteLine(cost);
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
