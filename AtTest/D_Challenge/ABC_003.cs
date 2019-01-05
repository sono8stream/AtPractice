using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_003
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int r = int.Parse(input[0]);
            int c = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            int d = int.Parse(input[0]);
            int l = int.Parse(input[1]);

            int roomPat = (r - x + 1) * (c - y + 1);
            long mask = 1000000007;
            long pat = Combination(x * y, d + l, mask);
            if (y > d + l && x == 1)
                pat -= Combination(y, d + l, mask);
            else if (x > d + l && y == 1)
                pat -= Combination(x, d + l, mask);
            else if (x * y > d + l)
                pat -= Combination((x - 1) * (y - 1), d + l, mask);
            if (pat < 0) pat += mask;
            long allPat = Combination(x * y, d, mask);
            allPat = MultiMod(allPat, roomPat, mask);
            allPat = MultiMod(allPat, pat, mask);
            Console.WriteLine(allPat);
        }

        static long Combination(long n, long m, long mask)
        {
            if (n - m < m) m = n - m;

            long val = Permutation(n, m, mask);
            long div = Permutation(m, m, mask);
            return MultiMod(val, ReverseMod(div, mask - 2, mask), mask);
        }

        static long Permutation(long n, long m, long mask)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
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
    }
}