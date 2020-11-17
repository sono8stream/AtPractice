using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1436
{
    class B
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
            HashSet<int> primes = PrimeNumbers(100000);
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int oneSum = n - 1;
                int other = int.MaxValue;
                foreach (int prime in primes) {
                    if (prime - oneSum > 0 && !primes.Contains(prime - oneSum))
                    {
                        other = Min(other, prime - oneSum);
                    }
                }
                int otherSum = other * (n - 1);
                int other2 = int.MaxValue;
                foreach(int prime in primes)
                {
                    if (prime - otherSum >= 0 && !primes.Contains(prime - otherSum))
                    {
                        other2 = Min(other2, prime - otherSum);
                    }
                }

                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        if (j == n - 1 && k == n - 1)
                        {
                            Write(other2);
                        }
                        else if (j == n - 1||k==n-1)
                        {
                            Write(other);
                        }
                        else
                        {
                            Write(1);
                        }

                        if (k == n - 1)
                        {
                            WriteLine();
                        }
                        else
                        {
                            Write(' ');
                        }
                    }
                }
            }
        }

        static HashSet<int> PrimeNumbers(int max)
        {
            var primes = new HashSet<int>();

            bool[] isPrime = new bool[max + 1];
            for(int i = 2; i <= max; i++)
            {
                isPrime[i] = true;
            }
            for(int i = 2; i <= max; i++)
            {
                if (!isPrime[i])
                {
                    continue;
                }

                for(int k = 2; i * k <= max; k++)
                {
                    isPrime[i * k] = false;
                }
            }

            for (int i = 2; i <= max; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
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
