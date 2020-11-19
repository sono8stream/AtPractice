using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1445
{
    class C
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
            long[][] pqs = new long[t][];
            for (int i = 0; i < t; i++)
            {
                pqs[i] = ReadLongs();
            }

            for(int i = 0; i < t; i++)
            {
                List<int[]> primes = PrimeFactors((int)pqs[i][1]);
                long[] maxes = new long[primes.Count];
                for(int j = 0; j < primes.Count; j++)
                {
                    long max = 1;
                    for(int k = 0; k < primes[j][1]; k++)
                    {
                        max *= primes[j][0];
                    }
                    maxes[j] = max;
                }

                long res = 0;
                for(int j = 0; j < primes.Count; j++)
                {
                    int cnt = 0;
                    long now = 1;
                    long tmp = pqs[i][0];
                    while (tmp % primes[j][0] == 0)
                    {
                        tmp /= primes[j][0];
                        now *= primes[j][0];
                        cnt++;
                    }

                    if (now < maxes[j])
                    {
                        res = pqs[i][0];
                        break;
                    }
                    else
                    {
                        long margin = now / maxes[j];
                        res = Max(res, pqs[i][0] / margin / primes[j][0]);
                    }
                }

                WriteLine(res);
            }
        }

        static List<int[]> PrimeFactors(int n)
        {
            var res = new List<int[]>();
            int tmp = n;

            for (int i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(new int[2] { i, 0 });
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res[res.Count - 1][1]++;
                    }
                }
            }
            if (tmp != 1) res.Add(new int[2] { tmp, 1 });//最後の素数も返す

            return res;
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
