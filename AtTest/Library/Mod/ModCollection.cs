using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.Mod
{
    class ModCollection
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long n = long.Parse(input[0]);
            long mask = 1000000007;
            Console.WriteLine(MultiMod(3000000000,
                ReverseMod(2, mask - 2, mask), mask));
        }

        static long MultiMod(long a,long b,long mask)
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

    struct ModInt
    {
        long mask;
        long val;

        public long Value { get { return val; } }

        public ModInt(long val, long mask)
        {
            this.val = val % mask;
            this.mask = mask;
        }

        public static ModInt operator ++(ModInt m)
        {
            return new ModInt((m.val + 1) % m.mask, m.mask);
        }

        public static ModInt operator --(ModInt m)
        {
            return new ModInt((m.val - 1 + m.mask) % m.mask, m.mask);
        }

        public static ModInt operator +(ModInt m1, ModInt m2)
        {
            return new ModInt((m1.val + m2.val) % m1.mask, m1.mask);
        }
        public static ModInt operator +(ModInt m1, long v2)
        {
            return new ModInt((m1.val + v2 % m1.mask) % m1.mask, m1.mask);
        }

        public static ModInt operator -(ModInt m1, ModInt m2)
        {
            return new ModInt((m1.val - m2.val + m1.mask) % m1.mask, m1.mask);
        }

        public static ModInt operator -(ModInt m1, long v2)
        {
            return new ModInt((m1.val - v2 % m1.mask + m1.mask) % m1.mask, m1.mask);
        }

        public static ModInt operator *(ModInt m1, ModInt m2)
        {
            return new ModInt(m1.val * m2.val % m1.mask, m1.mask);
        }

        public static ModInt operator /(ModInt m1, ModInt m2)
        {
            return new ModInt(m1.val * Inverse(m2.val, m1.mask) % m1.mask, m1.mask);
        }

        static long Inverse(long v, long m)
        {
            long a = m;
            long b = v % m;
            long x = 1;
            long x1 = 0;
            long y = 0;
            long y1 = 1;
            while (b > 0)
            {
                long q = a / b;
                long r = a % b;
                long x2 = (m + x - (q * x1) % m) % m;
                long y2 = (m + y - (q * y1) % m) % m;
                a = b;
                b = r;
                x = x1;
                x1 = x2;
                y = y1;
                y1 = y2;
            }
            return y;
        }

        public static bool operator ==(ModInt m1, ModInt m2)
        {
            return m1.val == m2.val;
        }

        public static bool operator !=(ModInt m1, ModInt m2)
        {
            return m1.val != m2.val;
        }

        public static bool operator >(ModInt m1, ModInt m2)
        {
            return m1.val > m2.val;
        }

        public static bool operator <(ModInt m1, ModInt m2)
        {
            return m1.val < m2.val;
        }
    }
}
