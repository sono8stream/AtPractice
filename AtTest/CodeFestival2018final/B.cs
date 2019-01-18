using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeFestival2018final
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] rs = ReadInts();
            double[] perms = new double[n];
            for(int i = 1; i < n; i++)
            {
                perms[i] = perms[i - 1] + Math.Log10(i + 1);
            }
            double val = perms[n - 1];
            for(int i = 0; i < m; i++)
            {
                if (rs[i] == 0) continue;

                val -= perms[rs[i] - 1];
            }
            for(int i = 0; i < n; i++)
            {
                val -= Math.Log10(m);
            }
            Console.WriteLine(Math.Ceiling(-val));
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
