using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeFestival2016Final
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var array = new int[n * 2][];
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[2] { ReadInt(), 0 };
            }
            for (int i = 0; i < n; i++)
            {
                array[n + i] = new int[2] { ReadInt(), 1 };
            }
            Array.Sort(array, (a, b) => a[0] - b[0]);

            long mask = 1000000000 + 7;
            long res = 1;
            long aCnt = 0;
            long bCnt = 0;
            for(int i = 0; i < 2 * n; i++)
            {
                if (array[i][1] == 0)
                {
                    if (bCnt == 0)
                    {
                        aCnt++;
                    }
                    else
                    {
                        res = MultiMod(res, bCnt, mask);
                        bCnt--;
                    }
                }
                else
                {
                    if (aCnt == 0)
                    {
                        bCnt++;
                    }
                    else
                    {
                        res = MultiMod(res, aCnt, mask);
                        aCnt--;
                    }
                }
            }
            WriteLine(res);
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
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
