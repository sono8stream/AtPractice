using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1409
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] ns = ReadLongs();
                long n = ns[0];
                long s = ns[1];

                long sum = CalcDigSum(n);

                long div = 1;
                long res = 0;
                while (sum > s)
                {
                    long margin = n % 10;
                    if (margin > 0)
                    {
                        res += div * (10 - margin);
                        n += 10;
                    }
                    n /= 10;
                    div *= 10;
                    sum = CalcDigSum(n);
                }
                WriteLine(res);
                continue;
            }
        }

        static long CalcDigSum(long val)
        {
            long sum = 0;
            while (val>0)
            {
                sum += val % 10;
                val /= 10;
            }
            return sum;
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
