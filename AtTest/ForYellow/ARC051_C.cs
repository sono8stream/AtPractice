using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC051_C
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
            int[] nab = ReadInts();
            int n = nab[0];
            long a = nab[1];
            long b = nab[2];
            long[] array = ReadLongs();

            if (a == 1)
            {
                Array.Sort(array);
                for (int i = 0; i < n; i++)
                {
                    WriteLine(array[i]);
                }
                return;
            }

            int[] digits = new int[n];
            for(int i = 0; i < n; i++)
            {
                int tmpDigit = 1;
                long tmp = array[i];
                while (tmp > 0)
                {
                    tmpDigit++;
                    tmp /= a;
                }
                digits[i] = tmpDigit;
            }

            int maxDigit = digits.Max();
            while (b > 0)
            {
                int idx = -1;
                for(int i = 0; i < n; i++)
                {
                    if (digits[i] < maxDigit)
                    {
                        if (idx == -1 || array[idx] > array[i])
                        {
                            idx = i;
                        }
                    }
                }

                if (idx == -1)
                {
                    break;
                }

                array[idx] *= a;
                digits[idx]++;
                b--;
            }

            long mask = 1000000000 + 7;
            Array.Sort(array);
            for(int i = 0; i < n; i++)
            {
                array[i] %= mask;
            }

            if (b > 0)
            {
                long bTmp = b / n;

                long val = 1;
                long dig = 1;
                long pow = a;
                while (dig <= bTmp)
                {
                    if ((bTmp & dig) > 0)
                    {
                        val *= pow;
                        val %= mask;
                    }
                    pow *= pow;
                    pow %= mask;
                    dig *= 2;
                }

                long[] next = new long[n];
                for(int i = 0; i < n; i++)
                {
                    int from = (int)((i + b) % n);
                    next[i] = array[from] * val;
                    next[i] %= mask;
                    if (from < b % n)
                    {
                        next[i] *= a;
                        next[i] %= mask;
                    }
                }

                array = next;
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(array[i]);
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
