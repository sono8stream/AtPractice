using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_081
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int[] array = ReadInts();
            var cntArray = new int[200000];
            for (int i = 0; i < nk[0]; i++)
            {
                cntArray[array[i] - 1]++;
            }
            Array.Sort(cntArray);
            int changeCnt = 0;
            int iterator = 0;
            while (nk[1] < 200000 - iterator)
            {
                changeCnt += cntArray[iterator];
                iterator++;
            }
            Console.WriteLine(changeCnt);
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
