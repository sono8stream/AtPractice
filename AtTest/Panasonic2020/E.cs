using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Panasonic2020
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
            string a = Read();
            string b = Read();
            string c = Read();
            bool[] ab = new bool[10000];
            bool[] bc = new bool[10000];
            bool[] ac = new bool[10000];
            for (int i = -5000; i < 5000; i++)
            {
                bool ok = true;
                for (int j = 0; j < b.Length && i + 5000 + j < 10000; j++)
                {
                    if (!Match(a, b, i + j, j))
                    {
                        ok = false;
                        break;
                    }
                }
                ab[i + 5000] = ok;
            }
            for (int i = -5000; i < 5000; i++)
            {
                bool ok = true;
                for (int j = 0; j < c.Length && i + 5000 + j < 10000; j++)
                {
                    if (!Match(b, c, i + j, j))
                    {
                        ok = false;
                        break;
                    }
                }
                bc[i + 5000] = ok;
            }
            for (int i = -5000; i < 5000; i++)
            {
                bool ok = true;
                for (int j = 0; j < c.Length && i + 5000 + j < 10000; j++)
                {
                    if (!Match(a, c, i + j, j))
                    {
                        ok = false;
                        break;
                    }
                }
                ac[i + 5000] = ok;
            }

            int res = int.MaxValue;
            for (int i = -4100; i < 4100; i++)
            {
                if (!ab[i + 5000])
                {
                    continue;
                }

                for (int j = -4100; j < 4100; j++)
                {
                    if (!ac[j + 5000])
                    {
                        continue;
                    }

                    if (j - i < -5000 || j - i >= 5000 || bc[j - i + 5000])
                    {
                        int tmp = Max(a.Length, Max(i + b.Length, j + c.Length))
                            - Min(0, Min(i, j));
                        res = Min(res, tmp);
                    }
                }
            }

            WriteLine(res);
        }

        static bool Match(string a, string b, int i, int j)
        {
            if (i < 0 || a.Length <= i)
            {
                return true;
            }

            if (a[i] == '?' || b[j] == '?')
            {
                return true;
            }

            return a[i] == b[j];
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
