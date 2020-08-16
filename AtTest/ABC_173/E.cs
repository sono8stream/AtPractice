using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_173
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] array = ReadLongs();

            List<long> pluses = new List<long>();
            List<long> minuses = new List<long>();
            int zeroCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] >= 0)
                {
                    pluses.Add(array[i]);
                } 
                else
                {
                    minuses.Add(array[i]);
                }
            }
            pluses.Sort();
            pluses.Reverse();
            minuses.Sort();

            long mask = 1000000000 + 7;

            if (n == k)
            {
                long res = 1;
                for(int i = 0; i < n; i++)
                {
                    res *= (array[i] + mask) % mask;
                    res %= mask;
                }
                WriteLine(res);
                return;
            }

            if (minuses.Count == n && k % 2 == 1)
            {// Minus
                long res = 1;
                for(int i = 0; i <k; i++)
                {
                    res *= (mask + minuses[minuses.Count - i - 1]) % mask;
                    res %= mask;
                }
                WriteLine(res);
                return;
            }
            else
            {
                long res = 1;
                int pI = 0;
                int mI = 0;
                int remain = k;
                while (remain > 0)
                {
                    if (remain >= 2)
                    {
                        if (mI < minuses.Count - 1)
                        {
                            if (pI < pluses.Count - 1)
                            {
                                if (minuses[mI] * minuses[mI + 1] 
                                    >= pluses[pI] * pluses[pI + 1])
                                {
                                    res *= (minuses[mI] * minuses[mI + 1]) % mask;
                                    res %= mask;
                                    mI += 2;
                                    remain -= 2;
                                }
                                else
                                {
                                    res *= pluses[pI];
                                    res %= mask;
                                    pI++;
                                    remain--;
                                }
                            }
                            else
                            {
                                res *= (minuses[mI] * minuses[mI + 1]) % mask;
                                res %= mask;
                                mI += 2;
                                remain -= 2;
                            }
                        }
                        else
                        {
                            res *= pluses[pI];
                            pI++;
                            remain--;
                        }
                    }
                    else
                    {
                        res *= pluses[pI];
                        remain--;
                    }
                    res %= mask;
                }

                WriteLine(res);
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
