using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class G
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
            int q = ReadInt();
            long[] ns = ReadLongs();
            long mask = 1000000000 + 7;

            long[] pows = new long[61];
            pows[0] = 1;
            pows[1] = 3;
            for(int i = 2; i <= 60; i++)
            {
                pows[i] = pows[i-1] * pows[i-1];
                pows[i] %= mask;
            }

            for(int i = 0; i < q; i++)
            {
                if (ns[i]<= 2) Write(ns[i]);
                else
                {
                    long res = 1;
                    long threeCnt = ns[i] / 3;
                    if (ns[i] % 3 == 1)
                    {
                        threeCnt--;
                        res = 4;
                    }
                    if (ns[i] % 3 == 2) res = 2;

                    long dig = 1;
                    while (threeCnt > 0)
                    {
                        if (threeCnt % 2 > 0)
                        {
                            res *= pows[dig];
                            res %= mask;
                        }
                        dig++;
                        threeCnt /= 2;
                    }
                    Write(res);
                }

                if (i < q - 1) Write(' ');
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
