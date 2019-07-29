using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_135
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
            string s = Read();
            string t = Read();
            StringBuilder ss = new StringBuilder(s);

            while (ss.Length < s.Length + t.Length - 1)
            {
                ss.Append(s);
            }
            RollingHash rollingHash = new RollingHash(ss.ToString());
            long[] hash = rollingHash.GetStringHash(t);
            int[] graph = new int[s.Length];
            for (int i = 0; i < s.Length; i++) graph[i] = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (rollingHash.ValidateRange(i, t.Length, hash))
                {
                    graph[i] = (i + t.Length) % s.Length;
                }
            }
            int[] lengthes = new int[s.Length];
            for (int i = 0; i < s.Length; i++) lengthes[i] = -1;
            for(int i = 0; i < s.Length; i++)// from leaf
            {
                if (graph[i] >= 0) continue;

                int cnt = 0;
                lengthes[i] = cnt;
                int now = (i - t.Length % s.Length + s.Length) % s.Length;
                while (graph[now]>=0)
                {
                    cnt++;
                    lengthes[now] = cnt;
                    now= (now - t.Length % s.Length + s.Length) % s.Length;
                }
            }

            int res = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (lengthes[i] == -1)
                {
                    WriteLine(-1);
                    return;
                }

                res = Max(res, lengthes[i]);
            }
            WriteLine(res);
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
