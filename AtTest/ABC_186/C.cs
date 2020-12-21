using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_186
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
            int n = ReadInt();
            int res = 0;
            for(int i = 1; i <= n; i++)
            {
                int rem10 = i;
                int rem8 = i;
                bool ok = true;
                while (rem10 > 0)
                {
                    if (rem10 % 10 == 7)
                    {
                        ok = false;
                        break;
                    }
                    rem10 /= 10;
                }
                while (rem8 > 0)
                {
                    if (rem8 % 8 == 7)
                    {
                        ok = false;
                        break;
                    }
                    rem8 /= 8;
                }

                if (ok)
                {
                    res++;
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
