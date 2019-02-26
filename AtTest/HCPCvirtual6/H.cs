using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPCvirtual6
{
    class H
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int q = ReadInt();
            long[] res = new long[q];
            long[] val = new long[6] { 1, 1, 2, 3, 5, 8 };
            for(int i = 0; i < q; i++)
            {
                int[] abx = ReadInts();
                int x = abx[2];
                int all = 1 << 6;
                for (int j = 0; j < all; j++)
                {
                    long now = 0;
                    int last = -2;
                    bool beaut = true;
                    for (int k = 0; k < 6; k++)
                    {
                        if ((j & (1 << k)) > 0)
                        {
                            if (last == k - 1) beaut = false;
                            now += val[k];
                            last = k;
                        }
                    }
                    if (beaut && now == x) res[i]++;
                }
            }
            for(int i = 0; i < q; i++)
            {
                WriteLine(res[i]);
            }
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
