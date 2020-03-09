using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_158
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
            int[] np = ReadInts();
            int n = np[0];
            int p = np[1];
            string s = Read();

            long res = 0;
            if (p == 2)
            {
                for(int i = 0; i < n; i++)
                {
                    if ((s[i] - '0') % 2 == 0)
                    {
                        res += i + 1;
                    }
                }
            }
            else if (p == 5)
            {
                for(int i = 0; i < n; i++)
                {
                    int current = s[i] - '0';
                    if (current == 0 || current == 5)
                    {
                        res += i + 1;
                    }
                }
            }
            else
            {
                int[] margins = new int[p];
                margins[0] = 1;
                int digMargin = 1;
                int tmpMargin = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    int current = (s[i] - '0') % p;
                    tmpMargin = (current * digMargin + tmpMargin) % p;
                    res += margins[tmpMargin];
                    margins[tmpMargin]++;
                    digMargin = (digMargin * 10) % p;
                }
            }
            WriteLine(res);
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
