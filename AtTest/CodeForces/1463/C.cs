using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1463
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
                long[][] txs = new long[n][];
                for(int j = 0; j < n; j++)
                {
                    txs[j] = ReadLongs();
                }

                long now = 0;
                long target = 0;
                long time = 0;
                int res = 0;
                for(int j = 0; j < n; j++)
                {
                    long tt = txs[j][0];
                    long x = txs[j][1];
                    if (Abs(target - now) <= tt - time)
                    {
                        now = target;
                    }
                    else
                    {
                        if (now < target)
                        {
                            now += tt - time;
                        }
                        else
                        {
                            now -= tt - time;
                        }
                    }
                    time = tt;
                    if (now == target)
                    {
                        target = x;
                    }

                    long nextPos;
                    if (j == n - 1)
                    {
                        nextPos = target;
                    }
                    else
                    {
                        long nextTime = txs[j + 1][0];
                        if (Abs(target - now) <= nextTime - time)
                        {
                            nextPos = target;
                        }
                        else
                        {
                            if (now < target)
                            {
                                nextPos = now + nextTime - time;
                            }
                            else
                            {
                                nextPos = now - (nextTime - time);
                            }
                        }
                    }
                    long l = Min(now, nextPos);
                    long r = Max(now, nextPos);
                    if (l <= txs[j][1] && txs[j][1] <= r)
                    {
                        res++;
                    }
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
