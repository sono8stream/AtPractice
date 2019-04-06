using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_123
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long[] transport = new long[5];
            for(int i = 0; i < 5; i++)
            {
                transport[i] = ReadLong();
            }
            long time = 0;
            for(int i = 0; i < 5; i++)
            {
                long remain = n - (time - i) * transport[i];
                if (remain <= 0) time++;
                else
                {
                    time += remain / transport[i];
                    if (n % transport[i] > 0) time++;
                }
            }
            WriteLine(time);
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
