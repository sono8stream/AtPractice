using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_142
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
            long[] ab = ReadLongs();
            long a = ab[0];
            long b = ab[1];
            var aPrimes = PrimeFactors(a);
            var bPrimes = PrimeFactors(b);
            int res = 1;
            foreach(long val in aPrimes)
            {
                if (bPrimes.Contains(val)) res++;
            }
            WriteLine(res);
        }

        static HashSet<long> PrimeFactors(long n)
        {
            var res = new HashSet<long>();
            long tmp = n;

            for (long i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(i);
                    while (tmp % i == 0) tmp /= i;
                }
            }
            if (tmp != 1) res.Add(tmp);//最後の素数も返す

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
