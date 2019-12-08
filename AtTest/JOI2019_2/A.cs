using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JOI2019_2
{
    class A
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
            int n=ReadInt();
            char[,] ss = new char[n,n];
            char[,] ts = new char[n, n];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < n; j++)
                {
                    ss[i, j] = s[j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                string s = Read();
                for (int j = 0; j < n; j++)
                {
                    ts[i, j] = s[j];
                }
            }
            char[,] turn1 = new char[n, n];
            char[,] turn2 = new char[n, n];
            char[,] turn3 = new char[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    turn1[i, j] = ss[j, n - 1 - i];
                    turn2[i, j] = ss[n - 1 - j, i];
                    turn3[i, j] = ss[n - 1 - i, n - 1 - j];
                }
            }
            int res0 = 0;
            int res1 = 1;
            int res2 = 1;
            int res3 = 2;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (ts[i, j] != ss[i, j]) res0++;
                    if (ts[i, j] != turn1[i, j]) res1++;
                    if (ts[i, j] != turn2[i, j]) res2++;
                    if (ts[i, j] != turn3[i, j]) res3++;
                }
            }
            int res = Min(res0, Min(res1, Min(res2, res3)));
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
