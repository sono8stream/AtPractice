using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Tenka12017_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long N = ReadInt();
            for(long h = 1; h <= 3500; h++)
            {
                for(long n = 1; n <= 3500; n++)
                {
                    long Nhn = N * h * n;
                    long div = 4 * h * n - N * n - N * h;
                    if (div > 0 && Nhn % div == 0)
                    {
                        long w = Nhn / div;
                        Console.WriteLine(h + " " + n + " " + w);
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
