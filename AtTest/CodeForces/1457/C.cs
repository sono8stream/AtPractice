using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1457
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] npk = ReadInts();
                int n = npk[0];
                int p = npk[1];
                int k = npk[2];
                string s = Read();
                int[] xy = ReadInts();
                int x = xy[0];
                int y = xy[1];

                int[] sums = new int[k];
                for (int j = 0; j < k; j++)
                {
                    for (int l = j + p - 1; l < n; l += k)
                    {
                        if (s[l] == '1')
                        {
                            sums[j]++;
                        }
                    }
                }

                int res = int.MaxValue;
                for(int j = p - 1; j < n; j++)
                {
                    int tmp = y * (j - (p - 1));
                    int len = n - j;
                    int cnt = len / k;
                    if (len % k > 0)
                    {
                        cnt++;
                    }
                    tmp += (cnt - sums[(j - (p - 1)) % k]) * x;
                    res = Min(res, tmp);

                    if (s[j] == '1')
                    {
                        sums[(j - (p - 1)) % k]--;
                    }
                }

                WriteLine(res);
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
