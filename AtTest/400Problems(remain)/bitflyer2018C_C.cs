using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class bitflyer2018C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nd = ReadLongs();
            long n = nd[0];
            long d = nd[1];
            long[] xs = ReadLongs();
            long[] lefts = new long[n];
            long[] rights = new long[n];
            int left = 0;
            int right = 0;
            for(long i = 0; i < n; i++)
            {
                while (xs[i] - xs[left] > d) left++;
                while (right < n && xs[right] - xs[i] <= d) right++;
                lefts[i] = i - left;
                rights[i] = right - i - 1;
                //Console.WriteLine(lefts[i]+" "+rights[i]);
            }
            long res = n * (n - 1) * (n - 2) / 6;
            for(long i = 0; i < n; i++)
            {
                res -= rights[i] * (rights[i] - 1) / 2;
            }
            for(long i = 0; i < n; i++)
            {
                res -= lefts[i] * (n - rights[i] - i - 1);
                res -= (i - lefts[i])*rights[i];
                res -= (i - lefts[i]) * (n - rights[i] - i - 1);
            }
            Console.WriteLine(res);
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
