using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_091
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
            int[] bArray = ReadInts();
            var bMods = new int[30][];
            for(int i =0; i < 30; i++)
            {
                bMods[i] = new int[n];
                int div = 2;
                for(int j = 0; j < n; j++)
                {
                    bMods[i][j] = bArray[j] % div;
                }
                div *= 2;
            }

            var cnts = new int[30];
            for(int i = 0; i < n; i++)
            {
                int t = 1;
                for(int j = 0; j < 30; j++)
                {
                    Array.Sort(bMods[j]);
                    int aMargin = array[i] % (t * 2);

                }
                t *= 2;
            }
        }

        static int BinarySearch(int[] array,int val,bool upper)
        {
            int bottom = 0;
            int top = array.Length;
            while (bottom + 1 < top)
            {
                int x = (bottom + top) / 2;
                if (array[x] > val)
                {
                    top = x;
                }
                else
                {
                    bottom = x;
                }
            }
            if (array[bottom] == val) return bottom;
            if (upper) return bottom+1;
            else return bottom;
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
