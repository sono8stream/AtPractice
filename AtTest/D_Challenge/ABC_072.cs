using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_072
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] ps = ReadInts();
            int cnt = 0;
            for(int i = 0; i < n - 1; i++)
            {
                if (ps[i] == i + 1)
                {
                    int temp = ps[i];
                    ps[i] = ps[i + 1];
                    ps[i + 1] = temp;
                    cnt++;
                }
            }
            if (ps[n - 1] == n) cnt++;
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
