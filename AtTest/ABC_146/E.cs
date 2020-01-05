using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_146
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
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            if (k == 1)
            {
                WriteLine(0);
                return;
            }
            for (int i = 0; i < n; i++) array[i] = (array[i] + k - 1) % k;
            long[] sum = new long[n];
            sum[0] = array[0];
            for (int i = 1; i < n; i++) sum[i] = (sum[i - 1] + array[i]) % k;
            var dict = new Dictionary<long, long>();
            dict.Add(0, 1);
            long res = 0;
            for(int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(sum[i]))
                {
                    res += dict[sum[i]];
                    dict[sum[i]]++;
                }
                else
                {
                    dict.Add(sum[i], 1);
                }
                if (i == k - 2)
                {
                    dict[0]--;
                    if (dict[0] == 0) dict.Remove(0);
                }
                if (i >= k - 1)
                {
                    dict[sum[i - k + 1]]--;
                    if (dict[sum[i - k + 1]] == 0) dict.Remove(sum[i - k + 1]);
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
