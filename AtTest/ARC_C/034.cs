using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _034
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] ab = ReadInts();
            int a = ab[0];
            int b = ab[1];
            var dict = new Dictionary<int, long>();
            for(int i = b + 1; i <= a; i++)
            {
                var list = PrimeFactors(i);
                for(int j = 0; j < list.Count; j++)
                {
                    if (!dict.ContainsKey(list[j][0]))
                    {
                        dict.Add(list[j][0], 0);
                    }
                    dict[list[j][0]] += list[j][1];
                }
            }

            long res = 1;
            long mask = 1000000000 + 7;
            foreach(int key in dict.Keys)
            {
                res *= dict[key]+1;
                res %= mask;
            }
            WriteLine(res);
        }

        static List<int[]> PrimeFactors(int n)
        {
            var res = new List<int[]>();
            int tmp = n;

            for (int i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(new int[2] { i, 0 });
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res[res.Count - 1][1]++;
                    }
                }
            }
            if (tmp != 1) res.Add(new int[2] { tmp, 1 });//最後の素数も返す

            return res;
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
