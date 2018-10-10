using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_073
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var array = new long[n];
            for(int i =0; i < n; i++)
            {
                array[i] = ReadLong();
            }
            var dict = new Dictionary<long, bool>();
            for(int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    dict.Remove(array[i]);
                }
                else
                {
                    dict.Add(array[i], false);
                }
            }
            Console.WriteLine(dict.Count);
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
