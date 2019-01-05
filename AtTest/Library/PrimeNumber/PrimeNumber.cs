using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.PrimeNumber
{
    class PrimeNumber
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] primes = PrimeNumbers(1, 1000);
            for (int i = 0; i < primes.Length; i++)
            {
                Console.WriteLine(primes[i]);
            }
        }

        static long[] PrimeNumbers(long min,long max)
        {
            var primes = new List<long>();
            if (min <= 2 && max >= 2)
            {
                primes.Add(2);
            }
            for (long i = 3; i <= max; i += 2)
            {
                long rootI = (long)Math.Sqrt(i);
                bool isPrime = true;
                for (long j = 3; j <= rootI; j += 2)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
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
            for (long i = 1; i * 6 - 1 <= max; i++)
            {
                long val = i * 6 - 1;
                long val2 = i * 6 + 1;
                bool prime1 = true;
                bool prime2 = true;
                for (int j = 0; j < primes.Count; j++)
                {
                    if (val % primes[j] == 0) prime1 = false;
                    if (val2 % primes[j] == 0) prime2 = false;
                    if (!prime1 && !prime2) break;
                }
                if (prime1) primes.Add(val);
                if (prime2 && val2 <= max) primes.Add(val2);
            }
            return primes.ToArray();
        }

        static List<int[]> PrimeFactors(int n)
        {
            var res = new List<int[]>();
            int tmp = n;

            for (int i=2; i * i <= n;i++)
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

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
