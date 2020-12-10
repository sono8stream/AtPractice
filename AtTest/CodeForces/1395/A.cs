using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1395
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
                int[] rgbw = ReadInts();
                long r = rgbw[0];
                long g = rgbw[1];
                long b = rgbw[2];
                long w = rgbw[3];

                bool canOperate = r > 0 && g > 0 && b > 0;
                long all = r + g + b + w;
                int oddCnt = 0;
                if (r % 2 == 1)
                {
                    oddCnt++;
                }
                if (g % 2 == 1)
                {
                    oddCnt++;
                }
                if (b % 2 == 1)
                {
                    oddCnt++;
                }
                if (w % 2 == 1)
                {
                    oddCnt++;
                }

                if (all % 2 == 1)
                {
                    if (oddCnt == 1 || (canOperate && oddCnt == 3))
                    {
                        WriteLine("Yes");
                    }
                    else
                    {
                        WriteLine("No");
                    }
                }
                else
                {
                    if (oddCnt == 0 || (canOperate && oddCnt == 4))
                    {
                        WriteLine("Yes");
                    }
                    else
                    {
                        WriteLine("No");
                    }
                }
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
