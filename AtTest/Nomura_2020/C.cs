using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Nomura_2020
{
    class C
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
            long capacity = 1;
            long[] capacities = new long[n+1];
            for(int i = 0; i <= n; i++)
            {
                if (capacity < array[i])
                {
                    WriteLine(-1);
                    return;
                }

                capacity -= array[i];
                capacities[i] = capacity;
                capacity = Min(capacity * 2, long.MaxValue / 10);
            }

            long backSum = 0;
            for(int i = n; i >= 0; i--)
            {
                backSum += array[i];
            }
            long res = 0;
            for(int i = 0; i <= n; i++)
            {
                backSum -= array[i];
                res += array[i];
                res += Min(capacities[i], backSum);
            }
            WriteLine(res);
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
