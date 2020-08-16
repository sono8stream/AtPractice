using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_172
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
            int n = ReadInt();
            long[] array = ReadLongs();

            long other= 0;
            for(int i = 2; i < n; i++)
            {
                other ^= array[i];
            }

            long res = DFS(array[0], array[1], other, 1);
            if (res == -1 || res == array[0])
            {
                WriteLine(-1);
            }
            else
            {
                WriteLine(res);
            }
        }

        static long DFS(long a, long b, long other, long div)
        {
            if (a == 0 && b == 0 && other == 0)
            {
                return 0;
            }
            if ((a ^ b) % 2 != other % 2)
            {
                return -1;
            }

            long val1 = DFS(a / 2, b / 2, other / 2, div * 2);
            long val2 = DFS((a - 1) / 2, (b + 1) / 2, other / 2, div * 2);

            if (val1 == -1 && val2 == -1)
            {
                return -1;
            }
            if (val1 == -1)
            {
                return val2 + div;
            }
            if (val2 == -1)
            {
                return val1;
            }
            return Min(val1, val2 + div);
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
