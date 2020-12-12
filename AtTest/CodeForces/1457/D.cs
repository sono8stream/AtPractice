using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1457
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
            int[] array = ReadInts();
            int div = 1;
            int dig = 0;
            int[] cnt = new int[35];
            for (int i = 0; i < n; i++)
            {
                while (div * 2 <= array[i])
                {
                    div *= 2;
                    dig++;
                }

                cnt[dig]++;
                if (cnt[dig] >= 3)
                {
                    WriteLine(1);
                    return;
                }
            }

            int res = int.MaxValue;
            for(int i = 0; i + 1 < n; i++)
            {
                int left = array[i];
                for(int j = i; j >= 0; j--)
                {
                    if (j < i)
                    {
                        left ^= array[j];
                    }
                    int right = array[i + 1];
                    for (int k = i + 1; k < n; k++)
                    {
                        if (k > i + 1)
                        {
                            right ^= array[k];
                        }

                        if (left > right)
                        {
                            res = Min(res, i - j + k - (i + 1));
                        }
                    }
                }
            }

            if (res == int.MaxValue)
            {
                WriteLine(-1);
            }
            else
            {
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
