using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.RollingHash
{
    class AOJ_Round_trip_String
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            string s = Read();
            RollingHash rollingHash = new RollingHash(s);
            HashSet<string> exists = new HashSet<string>();
            int l = 0;
            int r = 0;
            for(int i = 0; i < m; i++)
            {
                string q = Read();
                if (q[0] == 'R')
                {
                    if (q[1] == '+') r++;
                    else r--;
                }
                else
                {
                    if (q[1] == '+') l++;
                    else l--;
                }
                long[] hash = rollingHash.GetRangeHash(l, r);
                exists.Add(rollingHash.ToHashString(hash));
            }

            WriteLine(exists.Count);
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

            public string ToHashString(long[] hash)
            {
                string val = "";
                for (int i = 0; i < bases.Length; i++) val += hash[i].ToString();
                return val;
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
