using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_112
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var xs = new long[n];
            var ys = new long[n];
            var hs = new long[n];
            int baseIndex = 0;
            for (int i = 0; i < n; i++)
            {
                long[] input = ReadLongs();
                xs[i] = input[0];
                ys[i] = input[1];
                hs[i] = input[2];
                if (hs[i] > 0)
                {
                    baseIndex = i;
                }
            }
            for (long x = 0; x <= 100; x++)
            {
                for (long y = 0; y <= 100; y++)
                {
                    bool ok = true;
                    long h = hs[baseIndex]
                        + Math.Abs(xs[baseIndex] - x)
                        + Math.Abs(ys[baseIndex] - y);
                    for (int i = 0; i < n; i++)
                    {
                        long hTemp = h
                            - Math.Abs(xs[i] - x)
                            - Math.Abs(ys[i] - y);
                        if (hTemp < 0) hTemp = 0;
                        if (hTemp != hs[i])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        Console.WriteLine(x + " " + y + " " + h);
                        return;
                    }
                }
            }
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
