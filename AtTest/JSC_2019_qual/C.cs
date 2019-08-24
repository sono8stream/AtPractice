using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JSC_2019_qual
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
            long n = ReadLong();
            string s = Read();
            long mask = 1000000000 + 7;
            long pats = 1;
            long remain = 0;
            for(int i = 0; i < 2*n; i++)
            {
                if (s[i] == 'B')
                {
                    if (remain % 2 == 1)
                    {
                        pats *= remain;
                        pats %= mask;
                        remain--;
                    }
                    else
                    {
                        remain++;
                    }
                }
                else
                {
                    if (remain % 2 == 1)
                    {
                        remain++;
                    }
                    else
                    {
                        if (remain == 0)
                        {
                            WriteLine(0);
                            return;
                        }
                        else
                        {
                            pats *= remain;
                            pats %= mask;
                            remain--;
                        }
                    }
                }
            }
            if (remain > 0)
            {
                WriteLine(0);
                return;
            }
            for(long i = 1; i <= n; i++)
            {
                pats *= i;
                pats %= mask;
            }
            WriteLine(pats);
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
