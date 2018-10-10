using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_072
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            var cnts = new int[100000 + 2];// -1 ~ 100000
            for (int i = 0; i < n; i++)
            {
                cnts[array[i] - 1 + 1]++;
                cnts[array[i] + 1]++;
                cnts[array[i] + 1 + 1]++;
            }
            int maxIndex = 0;
            for(int i = 1; i < cnts.Length; i++)
            {
                if (cnts[maxIndex] < cnts[i])
                {
                    maxIndex = i;
                }
            }
            Console.WriteLine(cnts[maxIndex]);
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
