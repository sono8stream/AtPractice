using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_125
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            int[] lefts = new int[n];
            lefts[0] = array[0];
            for(int i = 1; i < n ; i++)
            {
                lefts[i] = GCD(lefts[i - 1], array[i]);
            }
            int[] rights = new int[n];
            rights[n - 1] = array[n - 1];
            for(int i = n - 2; i >= 0; i--)
            {
                rights[i] = GCD(rights[i + 1], array[i]);
            }

            int res = Max(lefts[n - 2], rights[1]);
            for (int i = 1; i < n - 1; i++)
            {
                res = Max(res, GCD(lefts[i - 1], rights[i + 1]));
            }
            WriteLine(res);
        }

        static int GCD(int a, int b)
        {
            if (b > a)
            {
                int temp = b;
                b = a;
                a = temp;
            }
            int c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
