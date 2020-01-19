using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_152
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
            long n = ReadLong();
            long[] array = ReadLongs();
            long mask = 1000000000 + 7;

            long[] gcds = new long[n];
            for(int i = 0; i < n; i++)
            {
                gcds[i] = array[i] / GCD(array[i], array[n - 1]);
            }
            var dict = new Dictionary<long, long>();
            for(int i = 0; i < n-1; i++)
            {
                List<long[]> factors = PrimeFactors(gcds[i]);
                foreach(long[] val in factors)
                {
                    if (dict.ContainsKey(val[0]))
                    {
                        dict[val[0]] = Max(dict[val[0]], val[1]);
                    }
                    else
                    {
                        dict.Add(val[0], val[1]);
                    }
                }
            }
            long bLast = 1;
            foreach(long key in dict.Keys)
            {
                long tmp = Pow(key, dict[key], mask);
                bLast = (bLast * tmp) % mask;
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                long b = (array[n - 1] * bLast) % mask;
                b = (b * Reverse(array[i], mask)) % mask;
                res += b;
                res %= mask;
            }
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

        static long Reverse(long val,long mask)
        {
            return Pow(val, mask - 2, mask);
        }

        static List<long[]> PrimeFactors(long n)
        {
            var res = new List<long[]>();
            long tmp = n;

            for (long i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(new long[2] { i, 0 });
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res[res.Count - 1][1]++;
                    }
                }
            }
            if (tmp != 1) res.Add(new long[2] { tmp, 1 });//最後の素数も返す

            return res;
        }

        static long Pow(long a, long exp,long mask)
        {
            if (exp == 0) return 1;
            else if (exp == 1) return a % mask;
            else
            {
                long halfMod = Pow(a, exp / 2,mask);
                long nextMod = (halfMod* halfMod)%mask;
                if (exp % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return (nextMod * a) % mask;
                }
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
