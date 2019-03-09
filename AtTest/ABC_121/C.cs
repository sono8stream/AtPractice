using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_121
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[][] abArray = new long[n][];
            for(int i = 0; i < n; i++)
            {
                abArray[i] = ReadLongs();
            }
            abArray=abArray.OrderBy(a => a[0]).ToArray();
            long res = 0;
            long now = m;
            for(int i = 0; i < n; i++)
            {
                if (abArray[i][1] >= now)
                {
                    res += now * abArray[i][0];
                    break;
                }
                else
                {
                    res += abArray[i][0] * abArray[i][1];
                    now -= abArray[i][1];
                }
            }
            WriteLine(res);
            //for (int i = 0; i < n; i++) WriteLine(abArray[i][0]);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
