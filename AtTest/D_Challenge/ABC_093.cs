using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_093
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int q = ReadInt();
            long[] ans = new long[q];
            for(int i = 0; i < q; i++)
            {
                long[] ab = ReadLongs();
                long min = Math.Min(ab[0], ab[1]);
                long max = Math.Max(ab[0], ab[1]);
                long multi = min * max;

                long sqrt = (long)Math.Sqrt(multi);
                if (sqrt * sqrt == multi) sqrt--;
                Console.WriteLine(sqrt);
                Console.WriteLine(Math.Sqrt(multi - 1));

                if (min == max || min + 1 == max)
                {
                    ans[i] = min * 2 - 2;
                    continue;
                }
                else
                {
                    //long sqrt = (long)Math.Sqrt(multi);
                    //if (sqrt*sqrt==multi) sqrt--;

                    if (sqrt * (sqrt + 1) >= multi)
                    {
                        ans[i] = 2 * sqrt - 2;
                    }
                    else
                    {
                        ans[i] = 2 * sqrt - 1;
                    }
                }

            }
            for(int i = 0; i < q; i++)
            {
                Console.WriteLine(ans[i]);
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
