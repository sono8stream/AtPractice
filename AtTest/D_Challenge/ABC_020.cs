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
            if (k > 100) return;
            long mask = 1000000000 + 7;
            long res = 0;
            for(long i = 0; i < k; i++)
            {
                long cnt = (n - i) / k;
                long sum = MultiMod(cnt, cnt + 1, mask);
                sum = MultiMod(sum, ReverseMod(2, mask - 2, mask), mask);
                sum = MultiMod(sum, k, mask);
                sum += (cnt + 1) * i;
                sum %= mask;
                long gcd = GCD(i, k);
                sum = MultiMod(sum, k, mask);
                sum = MultiMod(sum, ReverseMod(gcd, mask - 2, mask), mask);
                res += sum;
                res %= mask;
                Console.WriteLine(sum);
            }
            Console.WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long ReverseMod(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = ReverseMod(a, pow / 2, mask);
                long nextMod = MultiMod(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return MultiMod(nextMod, a, mask);
                }
            }
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
