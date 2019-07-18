using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_035
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
            int bitCnt = 0;
            int now = 1;
            while (now <= n)
            {
                if ((n & now) > 0) bitCnt++;
                now *= 2;
            }

            if (bitCnt == 1)
            {
                WriteLine("No");
                return;
            }

            WriteLine("Yes");

            WriteLine("1 2");
            WriteLine("2 3");
            WriteLine(3+" "+(n+1));
            WriteLine((n+1)+" "+(n+2));
            WriteLine((n+2)+" "+(n+3));

            for(int i = 4; i + 1 <= n; i += 2)
            {
                WriteLine(i + " " + (i + 1));
                WriteLine((i + 1) + " " + (1 + n));
                WriteLine((1 + n) + " " + (i + n));
                WriteLine((i + n) + " " + (i + 1 + n));
            }

            if (n % 2 == 0)
            {
                int first = 1;
                while ((n & first) == 0) first *= 2;

                WriteLine(n + " " + (first + 1));
                WriteLine((2 * n) + " " + (n + (n ^ first)));
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
