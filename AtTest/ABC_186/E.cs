using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_186
{
    class E
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] nsk = ReadLongs();
                long n = nsk[0];
                long s = nsk[1];
                long k = nsk[2] % n;

                long sqrt = (long)Sqrt(n) + 10;
                var dict = new Dictionary<long, long>();
                for(int j = 0; j < sqrt; j++)
                {
                    long val = j * k;
                    val %= n;
                    if (!dict.ContainsKey(val))
                    {
                        dict.Add(val, j);
                    }
                }
                long res = long.MaxValue;
                for(int j = 0; j < sqrt; j++)
                {
                    long delta = n - s;
                    if (dict.ContainsKey(delta))
                    {
                        res = Min(res, j * sqrt + dict[delta]);
                    }
                    s += sqrt * k;
                    s %= n;
                }

                WriteLine(res == long.MaxValue ? -1 : res);
            }
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
