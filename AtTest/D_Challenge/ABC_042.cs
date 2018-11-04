using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_042
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] hwab = ReadLongs();
            long h = hwab[0];
            long w = hwab[1];
            long a = hwab[2];
            long b = hwab[3];
            long mask = 1000000000 + 7;
            long fDiv = ReverseMod(Permutation(h - a - 1, h - a - 1, mask),
                mask - 2, mask);
            fDiv *= ReverseMod(Permutation(b, b, mask), mask - 2, mask);
            fDiv %= mask;
            long fPer = Permutation(h - a - 1 + b, h - a - 1 + b, mask);
            long sDiv = ReverseMod(Permutation(a - 1, a - 1, mask),
                mask - 2, mask);
            long sPer = Permutation(a - 1, a - 1, mask);
            var fPerms = new long[w-b];
            var sPerms = new long[w-b];
            for (long i = 0; i < w - b; i++)
            {
                fPerms[i] = fPer * fDiv;
                fPerms[i] %= mask;
                fPer = MultiMod(fPer, h - a - 1 + b + i+1, mask);
                fDiv = MultiMod(fDiv, ReverseMod(b + i+1, mask - 2, mask), mask);
                //Console.WriteLine(fPerms[i]);
                
            }
            for(long i = w - b - 1; i >= 0; i--)
            {
                sPerms[i] = sPer * sDiv;
                sPerms[i] %= mask;
                sPer = MultiMod(sPer, w - b - i + a - 1, mask);
                sDiv = MultiMod(sDiv,
                    ReverseMod(w - b - i, mask - 2, mask), mask);
                //Console.WriteLine(sPerms[i]);
            }

            long res = 0;
            for(int i = 0; i < sPerms.Length; i++)
            {
                res += fPerms[i] * sPerms[i];
                res %= mask;
            }
            Console.WriteLine(res);
        }

        static long Combination(long n, long m, long mask)
        {
            if (n - m < m)
            {
                m = n - m;
            }

            long val = Permutation(n, m, mask);
            for (int i = 1; i <= m; i++)
            {
                val = MultiMod(val, ReverseMod(i, mask - 2, mask), mask);
            }
            return val;
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

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
