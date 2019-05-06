using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day1
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            List<int> factors = PrimeFactors2(n);
            if (factors.Count < k)
            {
                WriteLine(-1);
                return;
            }

            for(int i = 0; i < k-1; i++)
            {
                Write(factors[i] + " ");
            }

            int last = 1;
            for (int i = k - 1; i < factors.Count; i++) last *= factors[i];
            WriteLine(last);
        }

        static List<int> PrimeFactors2(int n)
        {
            var res = new List<int>();
            int tmp = n;

            for (int i = 2; i * i <= n; i++)
            {
                while (tmp % i == 0)
                {
                    tmp /= i;
                    res.Add(i);
                }
            }
            if (tmp != 1) res.Add(tmp);//最後の素数も返す

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
