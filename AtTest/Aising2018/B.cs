using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Aising2018
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
            int n = ReadInt();
            int[] ab = ReadInts();
            int[] ps = ReadInts();
            int[] cnts = new int[3];
            for(int i = 0; i < n; i++)
            {
                if (ps[i] <= ab[0])
                {
                    cnts[0]++;
                }
                else if(ps[i]<=ab[1])
                {
                    cnts[1]++;
                }
                else
                {
                    cnts[2]++;
                }
            }
            int min = Math.Min(cnts[0], cnts[1]);
            min = Math.Min(min, cnts[2]);
            Console.WriteLine(min);
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
