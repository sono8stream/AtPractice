using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_147
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
            long n = ReadInt();
            long[] array = ReadLongs();
            long[] cnts = new long[60];
            for(int i = 0; i < n; i++)
            {
                long tmp = array[i];
                long div = 1;
                for (int j = 0; j < cnts.Length; j++)
                {
                    if ((tmp & div) > 0) cnts[j]++;
                    div *= 2;
                }
            }
            long res = 0;
            long digValue = 1;
            long mask = 1000000000 + 7;
            for(int i = 0; i < cnts.Length; i++)
            {
                long tmp = n - cnts[i];
                tmp *= digValue;
                tmp %= mask;
                tmp *= cnts[i];
                tmp %= mask;
                res += tmp;
                res %= mask;
                digValue *= 2;
                digValue %= mask;
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
