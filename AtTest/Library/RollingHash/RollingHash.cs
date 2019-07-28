using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.RollingHash
{
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

            for(int i = 0; i < s.Length; i++)
            {
                for(int j = 0; j < bases.Length; j++)
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

        public long[] GetRangeHash(int l,int r)
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

        public bool ValidateRange(int l,int length,long[] hash)
        {
            int r = l + length - 1;
            long[] rangeHash = GetRangeHash(l, l + length - 1);
            for(int i = 0; i < bases.Length; i++)
            {
                if (rangeHash[i] != hash[i]) return false;
            }
            return true;
        }

        public long[] GetStringHash(string s)
        {
            long[] vals = new long[bases.Length];
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = 0; j < bases.Length; j++)
                {
                    vals[j] = (vals[j] * bases[j] + s[i]) % mod;
                }
            }

            return vals;
        }
    }
}
