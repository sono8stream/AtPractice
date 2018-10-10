using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
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
            int[] abc = ReadInts();
            Array.Sort(abc);
            int cnt = 0;
            cnt += (abc[2] - abc[1]) / 2;
            abc[1] += (abc[2] - abc[1]) / 2 * 2;
            cnt += (abc[2] - abc[0]) / 2;
            abc[0] += (abc[2] - abc[0]) / 2 * 2;
            Array.Sort(abc);
            if (abc[0] < abc[1])//-1 0 0
            {
                cnt += 2;
            }
            else if (abc[1] < abc[2])
            {
                cnt += 1;
            }
            Console.WriteLine(cnt);
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
