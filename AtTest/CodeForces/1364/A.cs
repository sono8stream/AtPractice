using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1364
{
    class A
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
                int[] nx = ReadInts();
                int n = nx[0];
                int x = nx[1];
                int[] array = ReadInts();
                bool allDiv = true;
                for(int j = 0; j < n; j++)
                {
                    if (array[j] % x != 0)
                    {
                        allDiv = false;
                        break;
                    }
                }
                if (allDiv)
                {
                    WriteLine(-1);
                    continue;
                }

                int sum = 0;
                for(int j = 0; j < n; j++)
                {
                    sum += array[j];
                    sum %= x;
                }

                if (sum % x != 0)
                {
                    WriteLine(n);
                    continue;
                }

                int res = 0;
                for(int j = 0; j < n; j++)
                {
                    if (array[j] % x != 0)
                    {
                        res = Max(res, Max(j, n - j - 1));
                        break;
                    }
                }
                for (int j = n-1; j>=0; j--)
                {
                    if (array[j] % x != 0)
                    {
                        res = Max(res, Max(j, n - j - 1));
                        break;
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
