using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeThanksFestival2018
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] xy = ReadLongs();
            long min = Math.Min(xy[0], xy[1]);
            long max = Math.Max(xy[0], xy[1]);
            long margin = max - min;
            long div = margin / 2;
            min -= div;
            max -= div*3;
            if (min != max || min < 0 || min % 4 > 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
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
