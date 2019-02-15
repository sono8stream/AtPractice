using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int k = ReadInt();
            int all = 1 << k;
            int[] rs = new int[all];
            for (int i = 0; i < all; i++) rs[i] = ReadInt();
            var rates = new double[all];
            for (int i = 0; i < all; i++) rates[i] = 1;
            for(int i = 0; i < k; i++)
            {
                var next = new double[all];
                int div = 2 << i;
                for(int j = 0; j < all; j++)
                {
                    int f;
                    int l;
                    if (j % div < div / 2)
                    {
                        f = j - j % div + div / 2;
                    }
                    else
                    {
                        f = j - j % div;
                    }
                    l = f + div / 2;
                    for (; f < l; f++)
                    {
                        next[j] += rates[f] * WinRate(rs[j], rs[f]);
                    }
                    next[j] *= rates[j];
                }
                rates = next;
            }
            for (int i = 0; i < all; i++) Console.WriteLine(rates[i]);
        }

        static double WinRate(int rp,int rq)
        {
            return 1.0 / (1 + Math.Pow(10, 1.0 * (rq - rp) / 400));
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
