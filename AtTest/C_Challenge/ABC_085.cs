using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_085
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] ny = ReadInts();
            ny[1] /= 1000;
            for (int i = 0; i <= ny[0]; i++)
            {
                for(int j = 0; j <= ny[0] - i; j++)
                {
                    int val = 10 * i + 5 * j + 1 * (ny[0] - i - j);
                    if (val == ny[1])
                    {
                        Console.WriteLine(string.Format("{0} {1} {2}",
                            i, j, ny[0] - i - j));
                        return;
                    }
                }
            }
            Console.WriteLine("-1 -1 -1");
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
