using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
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
            int[][] hs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                hs[i] = new int[2] { ReadInt(), i };
            }
            Array.Sort(hs, (a, b) => a[0] - b[0]);

            int now = 0;
            int no = 0;
            for(int i = 0; i < n; i++)
            {
                if (now != hs[i][0])
                {
                    now = hs[i][0];
                    no++;
                }
                hs[i][0] = no;
            }
            Array.Sort(hs, (a, b) => a[1] - b[1]);
            for(int i = 0; i < n; i++)
            {
                WriteLine(hs[i][0]);
            }
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
