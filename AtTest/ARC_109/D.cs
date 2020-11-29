using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_109
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
                int[] abcs = ReadInts();
                int ax = abcs[0];
                int ay = abcs[1];
                int bx = abcs[2];
                int by = abcs[3];
                int cx = abcs[4];
                int cy = abcs[5];

                long toVer = 0;
                long toX = 0;
                long toHor = 0;
                long toY = 0;
                if (ax == bx)
                {
                    toVer = ax;
                    toX = cx;
                }
                else if (bx == cx)
                {
                    toVer = bx;
                    toX = ax;
                }
                else
                {
                    toVer = cx;
                    toX = bx;
                }
                if (ay == by)
                {
                    toHor = ay;
                    toY = cy;
                }
                else if (by == cy)
                {
                    toHor = by;
                    toY = ay;
                }
                else
                {
                    toHor = cy;
                    toY = by;
                }

                long rx = 0;
                long ry = 0;
                if (toVer <= 0)
                {
                    rx = -toVer * 2;
                    if(toX < toVer){
                        rx++;
                    }
                }
                else
                {
                    rx = toVer * 2 - 1;
                    if (toX > toVer)
                    {
                        rx++;
                    }
                }
                if (toHor <= 0)
                {
                    ry = -toHor * 2;
                    if (toY < toHor)
                    {
                        ry++;
                    }
                }
                else
                {
                    ry = toHor * 2 - 1;
                    if (toY > toHor)
                    {
                        ry++;
                    }
                }

                WriteLine(Max(rx, ry));
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
