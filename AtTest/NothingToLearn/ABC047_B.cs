using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.NothingToLearn
{
    class ABC047_B
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
            int[] whn = ReadInts();
            int w = whn[0];
            int h = whn[1];
            int n = whn[2];
            int l = 0;
            int r = w;
            int t = h;
            int b = 0;
            for(int i = 0; i < n; i++)
            {
                int[] xya = ReadInts();
                int x = xya[0];
                int y = xya[1];
                int a = xya[2];
                switch (a)
                {
                    case 1:
                        l = Max(l, x);
                        break;
                    case 2:
                        r = Min(r, x);
                        break;
                    case 3:
                        b = Max(b, y);
                        break;
                    case 4:
                        t = Min(t, y);
                        break;
                }
            }

            if(r<=l || t <= b)
            {
                WriteLine(0);
            }
            else
            {
                WriteLine((r - l) * (t - b));
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
