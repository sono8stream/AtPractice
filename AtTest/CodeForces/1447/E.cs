using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1447
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
            int n = ReadInt();
            int[] array = ReadInts();
            int[] cnts = new int[50];
            bool hasDouble = false;
            for(int i = 0; i < n; i++)
            {
                int top = 0;
                int now = array[i];
                while (now > 1)
                {
                    top++;
                    now /= 2;
                }

                cnts[top]++;
                if (cnts[top] > 1)
                {
                    hasDouble = true;
                }
            }

            if (!hasDouble)
            {
                WriteLine(0);
                return;
            }

            int res = 0;
            for (int i = 0; i < 50; i++)
            {
                if (cnts[i] > 1)
                {
                    res += cnts[i] - 1;
                }
            }

            for(int i = 0; i < 50; i++)
            {
                if (cnts[i] <= 1)
                {
                    continue;
                }

                int lowerRemoves = 0;
                for(int j = 0; j < i; j++)
                {
                    lowerRemoves += cnts[j];
                }
                if (lowerRemoves > 0)
                {
                    lowerRemoves--;
                }

                int upperRemoves = 0;
                for(int j = i + 1; j < 50; j++)
                {
                    if (cnts[j] > 1)
                    {
                        upperRemoves += cnts[j] - 1;
                    }
                }

                res = Min(res, lowerRemoves + upperRemoves);
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
