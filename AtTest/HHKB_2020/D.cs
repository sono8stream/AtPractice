using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HHKB_2020
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
            long mask = 1000000000 + 7;
            for (int i = 0; i < t; i++)
            {
                long[] nab = ReadLongs();
                ModInt n = new ModInt(nab[0], mask);
                ModInt a = new ModInt(Max(nab[1], nab[2]), mask);
                ModInt b = new ModInt(Min(nab[1], nab[2]), mask);

                ModInt all = (n - a + 1) * (n - a + 1) * (n - b + 1) * (n - b + 1);

                ModInt lineCnt = new ModInt(
                    n.Value + 1 < a.Value + b.Value ? 0 : (n - a - b + 1).Value, mask);
                ModInt nots = lineCnt * (lineCnt + 1);
                ModInt x = (n - a + 1) * (n - b + 1) - nots;
                ModInt res = all - x * x;
                WriteLine(res.Value);
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
