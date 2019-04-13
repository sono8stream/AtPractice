using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.yukicoder
{
    class _811
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
            List<int> list = PrimeFactors(n);
            list.Add(int.MaxValue);
            int baseVal = list[0];
            int maxCnt = 0;
            int maxVal = baseVal;
            for(int i = baseVal; i < n; i+=baseVal)
            {
                List<int> tmpList = PrimeFactors(i);
                int cnt = 0;

                int iter = 0;
                for(int j = 0; j < tmpList.Count; j++)
                {
                    while (list[iter] < tmpList[j]) iter++;
                    if (tmpList[j] == list[iter])
                    {
                        cnt++;
                        iter++;
                    }
                }
                if (cnt < k) continue;

                int tmp = CountDividers(tmpList);
                if (maxCnt < tmp)
                {
                    maxCnt = tmp;
                    maxVal = i;
                }
            }
            WriteLine(maxVal);
        }

        static List<int> PrimeFactors(int n)
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

        static int CountDividers(List<int> primes)
        {
            int res = 1;
            int seq = 2;
            for (int i = 1; i < primes.Count; i++)
            {
                if (primes[i] == primes[i - 1]) seq++;
                else
                {
                    res *= seq;
                    seq = 2;
                }
            }
            res *= seq;
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
