using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_063
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nab = ReadLongs();
            int n = (int)nab[0];
            long a = nab[1];
            long b = nab[2];
            long c = a - b;
            var hs = new long[n];
            for(int i = 0; i < n; i++)
            {
                hs[i] = ReadLong();
            }
            long tBottom = 0;
            long tTop = 1000000000;
            while(tTop- tBottom > 1)
            {
                bool ok = true;
                long t = (tBottom + tTop) / 2;
                long cnt = t;
                for(int i = 0; i < n; i++)
                {
                    long remain = hs[i] - t * b;
                    if (remain <= 0) continue;
                    if (remain > cnt * c)
                    {
                        ok = false;
                        break;
                    }
                    else
                    {
                        cnt -= remain / c;
                        if (remain % c > 0) cnt--;
                    }
                }
                if (ok)
                {
                    tTop = t;
                }
                else
                {
                    tBottom = t;
                }
            }
            Console.WriteLine(tTop);
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
