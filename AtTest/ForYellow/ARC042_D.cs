using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC042_D
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
            int[] xpab = ReadInts();
            long x = xpab[0];
            long p = xpab[1];
            long a = xpab[2];
            long b = xpab[3];

            long remain = b - a;
            if (remain >= p - 1)
            {
                WriteLine(1);
                return;
            }

            if (remain > 10000000)
            {
                long pow = x;
                long rev = 1;
                long div = 1;
                long target = p - 2;
                while (div <= target)
                {
                    if ((div & target) > 0)
                    {
                        rev *= pow;
                        rev %= p;
                    }

                    pow *= pow;
                    pow %= p;
                    div *= 2;
                }

                var dict = new Dictionary<long, long>();
                long m = (long)Sqrt(p);
                long val = 1;
                long rev2 = 1;
                for(int i = 0; i < m; i++)
                {
                    dict.Add(val, i);
                    val *= x;
                    val %= p;
                    rev2 *= rev;
                    rev2 %= p;
                }

                for(long i = 0; i < p / remain + 100; i++)
                {
                    long right = i;
                    for(int j = 0; j * m <= p; j++)
                    {
                        if (dict.ContainsKey(right))
                        {
                            long idx = j * m + dict[right];
                            if (a <= idx && idx <= b)
                            {
                                WriteLine(i);
                                return;
                            }
                        }
                        right *= rev2;
                        right %= p;
                    }
                }
            }
            else
            {
                long val = 1;
                for(int i = 0; i < a; i++)
                {
                    val *= x;
                    val %= p;
                }

                long min = val;
                for(long i = a; i < b; i++)
                {
                    val *= x;
                    val %= p;
                    min = Min(min, val);
                }

                WriteLine(min);
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
