using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_099
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            var patterns = new List<int>();
            patterns.Add(1);
            patterns.AddRange(new int[6]
                {6,36,216,1296,7776,46656});
            patterns.AddRange(new int[5]
            { 9,81,729,6561,59049});
            patterns.Sort();
            int cnt = n;
            for (int i = 0; i <= n; i++)//6^pで表すものをiとし, 最小回数を全探索
            {
                int a = n - i;
                int p = 0;
                while (a > 0)
                {
                    p += a % 6;
                    a /= 6;
                }

                int b = i;
                int q = 0;
                while (b > 0)
                {
                    q += b % 9;
                    b /= 9;
                }

                cnt = Math.Min(p + q, cnt);
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
