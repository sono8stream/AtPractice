using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival_2014_Final_F
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
            long[] bs = new long[n];
            for(int i = 0; i < n; i++)
            {
                bs[i] = ReadLong();
            }

            bool[] contradictions = new bool[n];
            for (int i = 0; i < n; i++)
            {
                int next1 = (i + 1) % n;
                int next2 = (i + 2) % n;
                long val = GCD(bs[i], bs[next2]);

                if (bs[next1] % GCD(bs[i], bs[next2]) == 0)
                {
                    continue;
                }
                else
                {
                    contradictions[next1] = true;
                }
            }

            int res = n + 1;
            for(int i = 0; i < 10; i++)
            {
                int tmp = 0;
                for(int j = 0; j < n; j++)
                {
                    int now = (i + j) % n;
                    if (contradictions[now])
                    {
                        j += 2;
                        tmp++;
                    }
                }
                res = Min(res, tmp);
            }

            WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }

            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);

            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a * b / c;
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
