using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1363
{
    class B
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
                string s = Read();
                int[] toZeroCnts = new int[s.Length];
                int[] toOneCnts = new int[s.Length];
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '0')
                    {
                        toOneCnts[j]++;
                    }
                    else
                    {
                        toZeroCnts[j]++;
                    }
                    if (j > 0)
                    {
                        toOneCnts[j] += toOneCnts[j - 1];
                        toZeroCnts[j] += toZeroCnts[j - 1];
                    }
                }

                int res = int.MaxValue;
                for (int j = 0; j < s.Length; j++)
                {
                    int firstZero = toZeroCnts[j] + (toOneCnts[s.Length - 1] - toOneCnts[j]);
                    int firstOne = toOneCnts[j] + (toZeroCnts[s.Length - 1] - toZeroCnts[j]);
                    res = Min(res, Min(firstZero, firstOne));
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
