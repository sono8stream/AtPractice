using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_114
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
            string s = Read();
            int min = int.MaxValue;
            for(int i = 0; i <= s.Length - 3; i++)
            {
                int val = int.Parse(s.Substring(i, 3));
                min = Math.Min(Math.Abs(val - 753), min);
            }

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
