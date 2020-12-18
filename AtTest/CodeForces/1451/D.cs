using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1451
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
                int[] dk = ReadInts();
                long d = dk[0];
                long k = dk[1];

                long bottom = 0;
                long top = d / k;
                top++;
                while (bottom + 1 < top)
                {
                    long mid = (bottom + top) / 2;
                    if (2 * mid * mid*k*k <= d * d)
                    {
                        bottom = mid;
                    }
                    else
                    {
                        top = mid;
                    }
                }

                long plus = k * k * (bottom * bottom + (bottom + 1) * (bottom + 1));
                if (plus > d * d)
                {
                    WriteLine("Utkarsh");
                }
                else
                {
                    WriteLine("Ashish");
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
