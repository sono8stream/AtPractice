using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();

            int[] xors = new int[n];
            xors[0] = array[0];
            for(int i = 1; i < n; i++)
            {
                xors[i] = array[i] ^ xors[i - 1];
            }

            long mask = 1000000000 + 7;
            for(int i = 0; i <n; i++)
            {
                long left = xors[i];
                long right = xors[n - 1] ^ xors[i];
                if (left != right) continue;

                long tmp = 1;
                if (left == 0)
                {
                    tmp = i * (n - 2 - i);
                }
                //res += tmp;
                //res %= tmp;
            }
            //WriteLine(res);
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
