using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_192
{
    class D
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
            string x = Read();
            long m = ReadLong();

            if (x.Length == 1)
            {
                if (m >= int.Parse(x))
                {
                    WriteLine(1);
                }
                else
                {
                    WriteLine(0);
                }
                return;
            }

            long baseVal = 0;
            for(int i = 0; i < x.Length; i++)
            {
                baseVal = Max(baseVal, x[i] - '0' + 1);
            }

            long bottom = baseVal;
            long top = m + 1;

            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;

                long val = 0;
                long div = 1;
                try
                {
                    checked
                    {

                        for (int i = x.Length - 1; i >= 0; i--)
                        {
                            val += div * (x[i] - '0');
                            if (i > 0)
                            {
                                div *= mid;
                            }
                        }
                    }
                }
                catch (OverflowException e)
                {
                    top = mid;
                    continue;
                }

                if (val <= m)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }

            {
                long val = 0;
                long div = 1;
                try
                {
                    checked
                    {

                        for (int i = x.Length - 1; i >= 0; i--)
                        {
                            val += div * (x[i] - '0');
                            if (i > 0)
                            {
                                div *= bottom;
                            }
                        }
                    }
                }
                catch (OverflowException e)
                {
                    WriteLine(0);
                    return;
                }
                if (val > m)
                {
                    WriteLine(0);
                    return;
                }
            }
            WriteLine(bottom - baseVal + 1);
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
