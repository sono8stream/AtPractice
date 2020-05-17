using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_168
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
            var pairs = new Dictionary<long, Dictionary<long, int>>();
            for(int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                long a = ab[0];
                long b = ab[1];
                if (Abs(a) > 0 && Abs(b) > 0)
                {
                    long gcd = GCD(Abs(a), Abs(b));
                    a  /= gcd;
                    b /= gcd;
                }
                else
                {
                    if (a == 0&&Abs(b)>0)
                    {
                        b = 1;
                    }
                    if (b == 0&&Abs(a)>0)
                    {
                        a = 1;
                    }
                }
                if (a < 0)
                {
                    a *= -1;
                    b *= -1;
                }
                if (!pairs.ContainsKey(a))
                {
                    pairs.Add(a, new Dictionary<long, int>());
                }
                if (!pairs[a].ContainsKey(b))
                {
                    pairs[a].Add(b, 0);
                }
                pairs[a][b]++;
            }

            long mask = 1000000000 + 7;
            long[] pow2s = new long[n + 5];
            pow2s[0] = 1;
            for(int i = 1; i < n + 5; i++)
            {
                pow2s[i] = pow2s[i - 1] * 2;
                pow2s[i] %= mask;
            }

            long res = 0;
            if (pairs.ContainsKey(0) && pairs[0].ContainsKey(0))
            {
                res += pairs[0][0];
            }
            long others = 1;
            var used = new Dictionary<long, HashSet<long>>();
            used.Add(0, new HashSet<long>());
            used[0].Add(0);
            foreach (long a in pairs.Keys)
            {
                foreach(long b in pairs[a].Keys)
                {
                    if (used.ContainsKey(a) && used[a].Contains(b))
                    {
                        continue;
                    }

                    if (pairs.ContainsKey(-b) && pairs[-b].ContainsKey(a))
                    {
                        others *= (pow2s[pairs[a][b]] + pow2s[pairs[-b][a]] - 1 + mask) % mask;

                        if (!used.ContainsKey(a))
                        {
                            used.Add(a, new HashSet<long>());
                        }
                        used[a].Add(b);
                        if (!used.ContainsKey(-b))
                        {
                            used.Add(-b, new HashSet<long>());
                        }
                        used[-b].Add(a);
                    }
                    else if (pairs.ContainsKey(b) && pairs[b].ContainsKey(-a))
                    {
                        others *= (pow2s[pairs[a][b]] + pow2s[pairs[b][-a]] - 1 + mask) % mask;

                        if (!used.ContainsKey(a))
                        {
                            used.Add(a, new HashSet<long>());
                        }
                        used[a].Add(b);
                        if (!used.ContainsKey(b))
                        {
                            used.Add(b, new HashSet<long>());
                        }
                        used[b].Add(-a);
                    }
                    else
                    {
                        others *= pow2s[pairs[a][b]];
                    }
                    others %= mask;
                }
            }
            others = (others - 1 + mask) % mask;
            res += others;
            res %= mask;
            WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a * b / c;
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
