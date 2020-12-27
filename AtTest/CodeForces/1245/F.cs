using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1245
{
    class F
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
                int[] lr = ReadInts();
                long l = lr[0];
                long r = lr[1];
                long lefts = l == 0 ? 0 : GetPatterns(l - 1);
                long rights = GetPatterns(r);
                WriteLine(rights - lefts);
            }
        }

        static long GetPatterns(long val)
        {
            if (val == 0)
            {
                return 1;
            }
            if (val == 1)
            {
                return 3;
            }

            long[] pow2s = new long[35];
            long[] pow3s = new long[35];
            pow2s[0] = 1;
            pow3s[0] = 1;
            for(int i = 1; i < 35; i++)
            {
                pow2s[i] = pow2s[i - 1] * 2;
                pow3s[i] = pow3s[i - 1] * 3;
            }

            long div = 1;
            int dig = 0;
            while (div * 2 <= val)
            {
                div *= 2;
                dig++;
            }

            long res = 0;
            int zeros = 0;
            for (; dig >= 0; dig--)
            {
                if ((val / div) % 2 == 1)
                {
                    if (div * 2 <= val)
                    {
                        res += 2 * pow2s[zeros + 1] * pow3s[dig];
                    }
                    else
                    {
                        res += pow3s[dig];
                    }
                }
                else
                {
                    zeros++;
                }
                div /= 2;
            }
            res += 2 * pow2s[zeros];

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
