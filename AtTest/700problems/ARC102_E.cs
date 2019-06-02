using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC102_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] kn = ReadLongs();
            long k = kn[0];
            long n = kn[1];
            long mask = 998244353;

            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            //long[] perms = AllPermutations(k + n, mask);
            //long all = MultiMod(perms[k + n - 1],
            //    ReverseMod(MultiMod(perms[k - 1], perms[n], mask),
            //    mask - 2, mask), mask);
            for (long i = 2; i <= k * 2; i++)
            {
                long cnt = i / 2;
                long val = 0;

            }

            Out.Flush();
        }

        /*
        static ModLong Combination(ModLong n,ModLong m)
        {
            if (n.value < m.value) return new ModLong(0);

            if (n - m < m) m = n - m;

            long val = Permutation(n, m, mask);
            long div = Permutation(m, m, mask);
            return MultiMod(val, ReverseMod(div, mask - 2, mask), mask);
        }

        static long Permutation(ModLong n, ModLong m)
        {
            ModLong val = new ModLong(1);
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
        }

        static long[] AllPermutations(long n, long mask)
        {
            var perms = new long[n + 1];
            perms[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                perms[i] = MultiMod(perms[i - 1], i, mask);
            }
            return perms;
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

        struct ModLong
        {
            public static long mask = 1000000000 + 7;//default

            public long value;

            public ModLong(long value)
            {
                this.value = value;
            }

            public static ModLong operator +(ModLong a, ModLong b)
            {
                long val = (a.value + b.value) % mask;
                return new ModLong(val);
            }

            public static ModLong operator +(ModLong a, long b)
            {
                long val = (a.value + b) % mask;
                return new ModLong(val);
            }

            public static ModLong operator +(long a, ModLong b)
            {
                long val = (a + b.value) % mask;
                return new ModLong(val);
            }

            public static ModLong operator -(ModLong a, ModLong b)
            {
                long val = a.value - b.value;
                while (val < 0) val += mask;
                return new ModLong(val);
            }

            public static ModLong operator -(ModLong a, long b)
            {
                long val = a.value - b;
                while (val < 0) val += mask;
                return new ModLong(val);
            }

            public static ModLong operator -(long a, ModLong b)
            {
                long val = a - b.value;
                while (val < 0) val += mask;
                return new ModLong(val);
            }

            public static ModLong operator *(ModLong a, ModLong b)
            {
                long val=(a.value*b.value)% mask;
                return new ModLong(val);
            }

            public static ModLong operator *(ModLong a, long b)
            {
                long val = (a.value * b) % mask;
                return new ModLong(val);
            }

            public static ModLong operator *(long a, ModLong b)
            {
                long val = (a * b.value) % mask;
                return new ModLong(val);
            }

            public static ModLong operator /(ModLong a, ModLong b)
            {
                long val = (a.value * Reverse(b.value, mask - 2)) % mask;
                return new ModLong(val);
            }

            public static ModLong operator /(ModLong a, long b)
            {
                long val = (a.value * Reverse(b, mask - 2)) % mask;
                return new ModLong(val);
            }

            public static ModLong operator /(long a, ModLong b)
            {
                long val = (a * Reverse(b.value, mask - 2)) % mask;
                return new ModLong(val);
            }

            static long Reverse(long val,long pow)
            {
                if (pow == 0) return 1;
                else if (pow == 1) return val % mask;
                else
                {
                    long halfMod = Reverse(val, pow / 2);
                    long nextMod = (halfMod * halfMod) % mask;
                    if (pow % 2 == 0)
                    {
                        return nextMod;
                    }
                    else
                    {
                        return (nextMod * val) % mask;
                    }
                }
            }
        }
        */

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
