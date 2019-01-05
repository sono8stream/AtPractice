using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_108
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int l = ReadInt();
            if (l <= 60)
            {
                Console.WriteLine(2 + " " + l);
                for (int i = 0; i < l; i++)
                {
                    Console.WriteLine(1 + " " + 2 + " " + i);
                }
            }
            else
            {
                int m = 60;
                List<int> factors = new List<int>();
                for (int i = 60; i >= 0; i--)
                {
                    List<int> factorsTemp = PrimeFactors(l - i);
                    int mTemp = 0;
                    for (int j = 0; j < factorsTemp.Count; j++)
                    {
                        mTemp += factorsTemp[j];
                    }
                    if (m > mTemp + i)
                    {
                        factors = factorsTemp;
                        m = mTemp + i;
                    }
                }
                int n = factors.Count;
                Console.WriteLine((n + 1) + " " + m);

                int unit = 1;
                for (int i = 0; i < factors.Count; i++)
                {
                    for (int j = 0; j < factors[i]; j++)
                    {
                        Console.WriteLine((i + 1) + " " + (i + 2)
                            + " " + (j * unit));
                    }
                    unit *= factors[i];
                }
                if (unit < l)
                {
                    for (int i = unit; i < l; i++)
                    {
                        Console.WriteLine(1 + " " + (n+1) + " " + i);
                    }
                }
            }
        }

        static List<int> PrimeFactors(int n)
        {
            var res = new List<int>();
            int tmp = n;

            for (int i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res.Add(i);
                    }
                }
            }
            if (tmp != 1) res.Add(tmp);//最後の素数も返す

            return res;
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
