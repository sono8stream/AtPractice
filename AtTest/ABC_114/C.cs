using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_114
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
            int n = ReadInt();
            int all = (int)Math.Pow(4, 9);
            int cnt = 0;
            for(int i = 0; i < all; i++)
            {
                int val = 0;
                int ii = i;
                bool[] ok = new bool[4];
                for(int j = 0; j < 9; j++)
                {
                    if (ii == 0) break;
                    int k = ii % 4;
                    if (k > 0)
                    {
                        val += (k * 2 + 1) * ((int)Math.Pow(10, j));
                    }
                    ii /= 4;
                    ok[k] = true;
                }
                if (!ok[0] && ok[1] && ok[2] && ok[3] && val <= n)
                {
                    cnt++;
                }
                //Console.WriteLine(val);
            }
            Console.WriteLine(cnt);
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
