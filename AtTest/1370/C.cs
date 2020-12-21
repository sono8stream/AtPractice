using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._1370
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
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                string first = "Ashishgup";
                string second = "FastestFinger";
                if (n == 1)
                {
                    WriteLine(second);
                }
                else if (n == 2)
                {
                    WriteLine(first);
                }
                else if (n % 2 == 1)
                {
                    WriteLine(first);
                }
                else
                {
                    Dictionary<int, int> factors = PrimeFactors(n);
                    if (factors[2] > 1)
                    {
                        if (factors.Count > 1)
                        {
                            WriteLine(first);
                        }
                        else
                        {
                            WriteLine(second);
                        }
                    }
                    else
                    {
                        int otherCnt = 0;
                        foreach(var key in factors.Keys)
                        {
                            if (key != 2)
                            {
                                otherCnt += factors[key];
                            }
                        }
                        if (otherCnt > 1)
                        {
                            WriteLine(first);
                        }
                        else
                        {
                            WriteLine(second);
                        }
                    }
                }
            }
        }

        static Dictionary<int, int> PrimeFactors(int n)
        {
            var res = new Dictionary<int, int>();
            int tmp = n;

            for (int i = 2; i * i <= n; i++)
            {
                if (tmp % i == 0)
                {
                    res.Add(i, 0);
                    while (tmp % i == 0)
                    {
                        tmp /= i;
                        res[i]++;
                    }
                }
            }
            if (tmp != 1) res.Add(tmp, 1);//最後の素数も返す

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
