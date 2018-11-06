using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_113
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var pys = new int[nm[1]][];
            for(int i = 0; i < nm[1]; i++)
            {
                int[] temp = ReadInts();
                pys[i] = new int[4] { temp[0], temp[1], i, 0 };
            }
            Array.Sort(pys, (a, b) => a[1] - b[1]);
            for(int i = 0; i < nm[1]; i++)
            {
                //Console.WriteLine(pys[i][0] + " " + pys[i][1]);
            }
            var cnts = new int[nm[0]];

            for(int i = 0; i < nm[1]; i++)
            {
                cnts[pys[i][0] - 1]++;
                pys[i][3] = cnts[pys[i][0] - 1];
            }
            Array.Sort(pys, (a, b) => a[2] - b[2]);
            for(int i = 0; i < nm[1]; i++)
            {
                Console.WriteLine(pys[i][0].ToString("D6")
                    + pys[i][3].ToString("D6"));
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
