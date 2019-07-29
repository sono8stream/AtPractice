using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_135
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
            long k = ReadLong();
            long[] xy = ReadLongs();
            long x = xy[0];
            long y = xy[1];

            long nowX = 0;
            long nowY = 0;
            long delta = Abs(x - nowX) + Abs(y - nowY);

            if (k % 2 == 0 && delta % 2 == 1)
            {
                WriteLine(-1);
                return;
            }

            List<long[]> res = new List<long[]>();
            while(delta!=k&&(delta > 2 * k || delta % 2 == 1))
            {
                long remain = k;
                if (Abs(x - nowX) <= remain)
                {
                    remain -= Abs(x - nowX);
                    nowX = x;
                }
                else
                {
                    if (x < nowX) nowX-= remain;
                    else nowX += remain;
                    remain = 0;
                }
                if (y < nowY) nowY -= remain;
                else nowY += remain;

                res.Add(new long[2] { nowX, nowY });
                delta = Abs(x - nowX) + Abs(y - nowY);
            }

            if (delta != k)
            {
                long midX, midY;
                long mid = delta / 2;
                long deltaX = Abs(x - nowX);
                if (deltaX >= mid){
                    if (x < nowX) midX = nowX - mid;
                    else midX = nowX + mid;

                    if (y < nowY) midY = nowY + k - mid;
                    else midY = nowY - k + mid;
                }
                else
                {
                    if (y < nowY) midY = y + mid;
                    else midY = y - mid;

                    if (x < nowX) midX = x - k + mid;
                    else midX = x + k - mid;
                }

                res.Add(new long[2] { midX, midY });
            }

            res.Add(new long[2] { x, y });

            WriteLine(res.Count);
            for(int i = 0; i < res.Count; i++)
            {
                WriteLine(res[i][0] + " " + res[i][1]);
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
