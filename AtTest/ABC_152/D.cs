using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_152
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
            int n = ReadInt();
            var dict = new Dictionary<int, long>();
            for(int i = 1; i <= n; i++)
            {
                int tail = i % 10;
                int tmp = i;
                while (tmp >= 10) tmp /= 10;
                int head = tmp;
                int val = head * 10 + tail;
                if (dict.ContainsKey(val))
                {
                    dict[val]++;
                }
                else
                {
                    dict.Add(val, 1);
                }
            }
            long res = 0;
            for (int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    int a = i * 10 + j;
                    int b = j * 10 + i;
                    if (dict.ContainsKey(a) && dict.ContainsKey(b))
                    {
                        res += dict[a] * dict[b];
                    }
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
