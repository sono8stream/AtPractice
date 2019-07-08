using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_133
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nds = ReadInts();
            int n = nds[0];
            int d = nds[1];
            int[][] xs = new int[n][];
            for(int i=0;i<n;i++)xs[i]= ReadInts();
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    int val = 0;
                    for(int k = 0; k < d; k++)
                    {
                        val += (xs[i][k] - xs[j][k]) *(xs[i][k] - xs[j][k]);
                    }

                    for (int k = 0; k < 200; k++)
                    {
                        if (val == k * k)
                        {
                            res++;
                            break;
                        }
                    }
                }
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
