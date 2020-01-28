using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_150
{
    class F
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
            int n = ReadInt();
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            long[] aDeltas = new long[2 * n];
            long[] bDeltas = new long[n];
            for (int i = 0; i < n; i++)
            {
                aDeltas[i] = aArray[i % n] ^ aArray[(i + 1) % n];
                aDeltas[i + n] = aDeltas[i];
                bDeltas[i] = bArray[i % n] ^ bArray[(i + 1) % n];
            }

            RollingHash2 aHash = new RollingHash2(aDeltas);
            long[] bHash = aHash.CalcHash(bDeltas);
            for (int i = 0; i < n; i++)
            {
                if (aHash.ValidateRange(i, n, bHash))
                {
                    WriteLine(i + " " + (aArray[i] ^ bArray[0]));
                }
            }
        }

        class RollingHash2
        {
            long mod = 1000000007;
            long[] bases = new long[3] { 1009, 2003, 3001 };
            long[,] pows;
            long[,] hashes;

            public RollingHash2(long[] array)
            {
                pows = new long[array.Length, bases.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < bases.Length; j++)
                    {
                        if (i == 0) pows[i, j] = 1;
                        else pows[i, j] = (pows[i - 1, j] * bases[j]) % mod;
                    }
                }

                hashes = new long[array.Length, bases.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < bases.Length; j++)
                    {
                        if (i > 0) hashes[i, j] = (hashes[i - 1, j] * bases[j]) % mod;
                        hashes[i, j] += array[i];
                        hashes[i, j] %= mod;
                    }
                }
            }

            public long[] GetRangeHash(int l, int length)
            {
                long[] hash = new long[bases.Length];
                for (int i = 0; i < bases.Length; i++)
                {
                    hash[i] = hashes[l + length - 1, i];
                    if (l > 0)
                    {
                        hash[i] += mod - (hashes[l - 1, i] * pows[length, i]) % mod;
                        hash[i] %= mod;
                    }
                }
                return hash;
            }

            public bool ValidateRange(int l, int length, long[] hash)
            {
                int r = l + length - 1;
                long[] rangeHash = GetRangeHash(l, length);
                for (int i = 0; i < bases.Length; i++)
                {
                    if (rangeHash[i] != hash[i]) return false;
                }
                return true;
            }

            public long[] CalcHash(long[] s)
            {
                long[] vals = new long[bases.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < bases.Length; j++)
                    {
                        vals[j] = (vals[j] * bases[j] + s[i]) % mod;
                    }
                }
                return vals;
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
