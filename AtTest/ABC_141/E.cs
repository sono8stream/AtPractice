using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_141
{
    class E
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
            string s = Read();
            RollingHash rollingHash = new RollingHash(s);
            int bottom = 0;
            int top = n;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                var set = new HashSet<string>();
                var sub = new Queue<string>();
                bool can = false;
                for(int i = 0; i + mid - 1 < n; i++)
                {
                    long[] hash = rollingHash.GetRangeHash(i, i + mid - 1);
                    string hashStr = "";
                    for(int j = 0; j < hash.Length; j++)
                    {
                        hashStr += hash[j].ToString();
                    }
                    if (set.Contains(hashStr))
                    {
                        can = true;
                        break;
                    }
                    sub.Enqueue(hashStr);
                    if (sub.Count >= mid)
                    {
                        set.Add(sub.Dequeue());
                    }
                }
                if (can)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            WriteLine(bottom);
        }
        class RollingHash
        {
            long mod = 1000000007;
            long[] bases = new long[3] { 1009, 2003, 3001 };
            long[,] pows;
            long[,] hashes;

            public RollingHash(string s)
            {
                pows = new long[s.Length, bases.Length];
                hashes = new long[s.Length, bases.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < bases.Length; j++)
                    {
                        if (i == 0) pows[i, j] = 1;
                        else pows[i, j] = (pows[i - 1, j] * bases[j]) % mod;
                    }
                }

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < bases.Length; j++)
                    {
                        if (i > 0) hashes[i, j] = (hashes[i - 1, j] * bases[j]) % mod;
                        hashes[i, j] += s[i];
                        hashes[i, j] %= mod;
                    }
                }
            }

            public long[] GetRangeHash(int l, int r)
            {
                long[] hash = new long[bases.Length];
                for (int i = 0; i < bases.Length; i++)
                {
                    hash[i] = hashes[r, i];
                    if (l > 0)
                    {
                        hash[i] += mod - (hashes[l - 1, i] * pows[r - l + 1, i]) % mod;
                        hash[i] %= mod;
                    }
                }
                return hash;
            }

            public bool ValidateRange(int l, int length, long[] hash)
            {
                int r = l + length - 1;
                long[] rangeHash = GetRangeHash(l, l + length - 1);
                for (int i = 0; i < bases.Length; i++)
                {
                    if (rangeHash[i] != hash[i]) return false;
                }
                return true;
            }

            public long[] GetStringHash(string s)
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
