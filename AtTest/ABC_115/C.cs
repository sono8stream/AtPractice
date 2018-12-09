using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_115
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
            int[] nk = ReadInts();
            var hs = new int[nk[0]];
            for(int i = 0; i < nk[0]; i++)
            {
                hs[i] = ReadInt();

            }
            Array.Sort(hs);
            int res = int.MaxValue;
            for (int i = 0; i <= nk[0] - nk[1]; i++)
            {
                int margin = hs[i + nk[1]-1] - hs[i];
                res = Math.Min(res, margin);
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
