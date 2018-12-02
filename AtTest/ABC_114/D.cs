using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_114
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var ps = new int[25];
            var spNums = new int[25] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            for(int i = 2; i <= n; i++)
            {
                int ii = i;
                for(int j = 0; j < 25; j++)
                {
                    while (ii % spNums[j] == 0)
                    {
                        ii /= spNums[j];
                        ps[j]++;
                    }
                }
            }
            for(int i = 0; i < 25; i++)
            {
                //Console.WriteLine(ps[i]);
            }
            Console.WriteLine(Cnt(ps, 74) + Cnt(ps, 24) * (Cnt(ps, 2) - 1)
                + Cnt(ps, 14) * (Cnt(ps, 4) - 1)
                + Cnt(ps, 4) * (Cnt(ps, 4) - 1) / 2 * (Cnt(ps, 2) - 2));
        }

        static int Cnt(int[] ps,int bottom)
        {
            int cnt = 0;
            for(int i = 0; i < ps.Length; i++)
            {
                if (ps[i] >= bottom) cnt++;
            }
            return cnt;
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
