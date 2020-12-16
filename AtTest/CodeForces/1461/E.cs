using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1461
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
            long[] klrtxy = ReadLongs();
            long k = klrtxy[0];
            long l = klrtxy[1];
            long r = klrtxy[2];
            long t = klrtxy[3];
            long x = klrtxy[4];
            long y = klrtxy[5];

            long delta = Abs(y - x);
            if (y < x)
            {
                if (k + y <= r)
                {
                    if ((k - l) / Abs(delta) >= t)
                    {
                        WriteLine("Yes");
                    }
                    else
                    {
                        WriteLine("No");
                    }
                }
                else
                {
                    if (k - x < l)
                    {
                        WriteLine("No");
                    }
                    else
                    {
                        long kk = k - x;
                        if ((kk - l) / delta >= t-1)
                        {
                            WriteLine("Yes");
                        }
                        else
                        {
                            WriteLine("No");
                        }
                    }
                }
            }
            else if (y == x)
            {
                if (k - x >= l || k + y <= r)
                {
                    WriteLine("Yes");
                }
                else
                {
                    WriteLine("No");
                }
            }
            else
            {
                long max = r - l;
                long tmp = k - l;
                var used = new HashSet<long>();
                long remain = t - tmp / x;
                tmp = tmp % x;
                used.Add(tmp);
                while (remain > 0)
                {
                    if (tmp + y > max)
                    {
                        WriteLine("No");
                        return;
                    }

                    remain -= (tmp + y) / x;
                    tmp = (tmp + y) % x;
                    if (used.Contains(tmp))
                    {
                        break;
                    }
                    else
                    {
                        used.Add(tmp);
                    }
                }
                WriteLine("Yes");
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
