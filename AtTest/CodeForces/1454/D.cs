using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1454
{
    class D
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
                long n = ReadLong();
                var factors = PrimeFactors(n);
                long max = 0;
                for(int j = 0; j < factors.Count; j++)
                {
                    max = Max(max, factors[j][1]);
                }

                WriteLine(max);
                long[] res = new long[max];
                for(int j = 0; j < max; j++)
                {
                    res[j] = 1;
                }
                for(int j = 0; j < factors.Count; j++)
                {
                    for(int k = 0; k <factors[j][1];k++ )
                    {
                        res[max - k - 1] *= factors[j][0];
                    }
                }
                for (int j = 0; j < max; j++)
                {
                    Write(res[j]);
                    if (j + 1 < max)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
        }

        static List<long[]> PrimeFactors(long n)
        {
            var res = new List<long[]>();
            long tmp = n;

            for (long i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(new long[2] { i, 0 });
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res[res.Count - 1][1]++;
                    }
                }
            }
            if (tmp != 1) res.Add(new long[2] { tmp, 1 });//最後の素数も返す

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
