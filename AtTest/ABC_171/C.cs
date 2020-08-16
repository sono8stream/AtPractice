using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_171
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
            long sum = 0;
            long div = 26;
            int cnt = 1;
            while (n - div > 0)
            {
                n -= div;
                div *= 26;
                cnt++;
            }

            n--;
            int[] vals = new int[cnt];
            div = 26;
            for(int i = 0; i < cnt; i++)
            {
                vals[i] = (int)(n % div);
                n /= div;
            }

            for(int i = cnt-1; i >= 0; i--)
            {
                Write((char)(vals[i] + 'a'));
            }
            WriteLine();
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
