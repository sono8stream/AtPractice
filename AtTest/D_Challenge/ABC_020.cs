using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_020
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long mask = 1000000000 + 7;
            long[] primes = PrimeNumbers(k);
            long kk = k;
            long[] primeCnts = new long[primes.Length];
            long allPat = 1;
            for(int i = 0; i < primes.Length; i++)
            {
                while (kk % primes[i] == 0)
                {
                    primeCnts[i]++;
                    kk /= primes[i];
                }
                Console.WriteLine(primeCnts[i]);
                allPat *= (primeCnts[i] + 1);
            }
            Console.WriteLine(allPat);
            long res = 0;
            for(long i = allPat; i > 0; i--)
            {
                long div = 1;

            }
        }

        static long[] PrimeNumbers(long max)
        {
            var primes = new List<long>();
            if (max < 2) return primes.ToArray();
            primes.Add(2);
            if (max < 3)
            {
                return primes.ToArray();
            }
            primes.Add(3);
            if (max < 5)
            {
                return primes.ToArray();
            }
            for (long i = 1; i*6-1 <= max; i ++)
            {
                long val = i * 6 - 1;
                long val2 = i * 6 + 1;
                bool prime1 = true;
                bool prime2 = true;
                for(int j = 0; j < primes.Count; j++)
                {
                    if (val % primes[j] == 0) prime1 = false;
                    if (val2 % primes[j] == 0) prime2 = false;
                    if (!prime1 && !prime2) break;
                }
                if (prime1) primes.Add(val);
                if (prime2&&val2<=max) primes.Add(val2);
            }
            return primes.ToArray();
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
