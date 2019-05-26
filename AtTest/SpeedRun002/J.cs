using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.SpeedRun002
{
    class J
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var set = new HashSet<long>();
            for(int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                if (i == 0)
                {
                    long aMax = (long)Sqrt(ab[0]);
                    for(int j = 1; j <= aMax; j++)
                    {
                        if (ab[0] % j == 0)
                        {
                            set.Add(j);
                            set.Add(ab[0] / j);
                        }
                    }
                    long bMax = (long)Sqrt(ab[1]);
                    for(int j = 1; j <= bMax; j++)
                    {
                        if (ab[1] % j == 0)
                        {
                            set.Add(j);
                            set.Add(ab[1] / j);
                        }
                    }
                }
                else
                {
                    var setTemp = new HashSet<long>();
                    foreach (long val in set)
                    {
                        if (ab[0] % val == 0 || ab[1] % val == 0)
                        {
                            setTemp.Add(val);
                        }
                    }
                    set = setTemp;
                }
            }

            long res = 1;
            foreach (long val in set) res = Max(res, val);
            WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            if (a % b == 0) return b;
            else return GCD(b, a % b);
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
