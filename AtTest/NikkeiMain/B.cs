using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.NikkeiMain
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];

            long[] array = ReadLongs();
            long[] bArray = ReadLongs();

            if (n > m)
            {
                Console.WriteLine("Y");
            }
            else if (n < m)
            {
                Console.WriteLine("X");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (array[i] == bArray[i]) continue;
                    Console.WriteLine(array[i] < bArray[i] ?
                        "X" : "Y");
                    return;
                }
                Console.WriteLine("Same");
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
