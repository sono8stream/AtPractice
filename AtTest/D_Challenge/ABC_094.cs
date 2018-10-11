using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_094
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            Array.Sort(array);
            long ai = array[n - 1];
            long aj = array[0];
            long ajComp = Math.Min(ai - array[0], array[0]);
            for (int i = 1; i < n; i++)
            {
                long temp = Math.Min(ai - array[i], array[i]);
                if (ajComp < temp)
                {
                    aj = array[i];
                    ajComp = temp;
                }
            }
            Console.WriteLine(ai + " " + aj);
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
