using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1409
{
    class B
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
            for (int i = 0; i < t; i++)
            {
                long[] abxyn = ReadLongs();
                long a = abxyn[0];
                long b = abxyn[1];
                long x = abxyn[2];
                long y = abxyn[3];
                long n = abxyn[4];

                if (x > y)
                {
                    long aTmp = a;
                    long xTmp = x;
                    a = b;
                    x = y;
                    b = aTmp;
                    y = xTmp;
                }

                long res;
                if (a - x >= n)
                {
                    long bb = Max(b - n, y);
                    if (a - n > bb)
                    {
                        long remain = n - (b - bb);
                        res = (a - remain) * bb;
                    }
                    else
                    {
                        res = (a - n) * b;
                    }
                }
                else
                {
                    long remain = n - (a - x);
                    if (b - y >= remain)
                    {
                        res = x * (b - remain);
                    }
                    else
                    {
                        res = x * y;
                    }
                }

                /*

                if (a >= y)
                {
                    long delta = b - a;
                    if (delta >= n)
                    {
                        res = a * (b - n);
                    }
                    else
                    {
                        long remain = n - delta;
                        long bottom = Max(x, y);
                        long bottom2 = Min(x, y);
                        if ((a - bottom) * 2 >= remain)
                        {
                            if (remain % 2 == 1)
                            {
                                res = (a - remain / 2) * (a - remain / 2 - 1);
                            }
                            else
                            {
                                res = (a - remain / 2) * (a - remain / 2);
                            }
                        }
                        else
                        {
                            remain -= a - bottom;
                            if (bottom - bottom2 <= remain)
                            {
                                res = bottom2 * bottom;
                            }
                            else
                            {
                                res = bottom * (bottom - remain);
                            }
                        }
                    }
                }
                else
                {
                    if (b - y >= n)
                    {
                        res = a * (b - n);
                    }
                    else
                    {
                        long remain = n - (b - y);
                        if (a - x >= remain)
                        {
                            res = (a - remain) * y;
                        }
                        else
                        {
                            res = x * y;
                        }
                    }
                }
                */
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
