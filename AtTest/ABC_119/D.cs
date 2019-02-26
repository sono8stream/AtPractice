using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_119
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] abq = ReadInts();
            int a = abq[0];
            int b = abq[1];
            int q = abq[2];
            long[] ss = new long[a+2];
            ss[0] = long.MinValue/2;
            ss[a + 1] = long.MaxValue/100;
            for (int i = 1; i <= a; i++) ss[i] = ReadLong();
            long[] ts = new long[b+2];
            ts[0] = long.MinValue/100;
            ts[b + 1] = long.MaxValue/2;
            for (int i = 1; i <= b; i++) ts[i] = ReadLong();
            long[] res = new long[q];
            for(int i = 0; i < q; i++)
            {
                long x = ReadLong();
                int sIndex = BinarySearch(ss, x);
                int tIndex = BinarySearch(ts, x);
                long val = long.MaxValue;
                for(int j = 0; j < 2; j++)
                {
                    long d1 = ss[sIndex + j] - x;
                    for(int k = 0; k < 2; k++)
                    {
                        long d2 = ts[tIndex + k] - x;
                        long min = Min(Abs(d1), Abs(d2));
                        long max = Max(Abs(d1), Abs(d2));
                        if ((d1 > 0 && d2 > 0) || (d1 <= 0 && d2 <= 0))
                        {
                            val = Min(val, max);
                        }
                        else
                        {
                            val = Min(val, min * 2 + max);
                        }
                        //WriteLine(d1 + " " + d2 + " " + min + " " + max);
                    }
                }
                res[i] = val;
            }

            for (int i = 0; i < q; i++)
            {
                WriteLine(res[i]);
            }
        }

        //val以下の最大のインデックス
        static int BinarySearch(long[] array,long val)
        {
            int bottom = 0;
            int top = array.Length;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                if (array[mid] <= val)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            if (bottom == 0 && val < array[bottom]) return -1;
            else return bottom;
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
