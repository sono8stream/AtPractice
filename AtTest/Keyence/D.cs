using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Keyence
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var aArray = ReadInts();
            var bArray = ReadInts();
            Array.Sort(aArray);
            Array.Reverse(aArray);
            Array.Sort(bArray);
            Array.Reverse(bArray);
            int i = 0;
            int j = 0;
            long max = nm[0] * nm[1];
            if (!(aArray[i] == bArray[j] && aArray[i] == max))
            {
                Console.WriteLine(0);
                return;
            }
            i++;
            j++;
            long res = 1;
            long mask = 1000000000 + 7;
            for (long val = max - 1; val >= 1; val--)
            {
                long space = 0;
                if (i < nm[0] && j < nm[1]
                    && val == aArray[i] && val == bArray[j])
                {
                    space = 1;
                    i++;
                    j++;
                }
                else if (i < nm[0] && val == aArray[i])
                {
                    space = j;
                    i++;
                }
                else if (j < nm[1] && val == bArray[j])
                {
                    space = i;
                    j++;
                }
                else
                {
                    space = i * j - (max - val);
                }
                if (space == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                res *= space;
                res %= mask;
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
