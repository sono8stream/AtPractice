using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2020_1B
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            long[] xy = ReadLongs();
            long x = xy[0];
            long y = xy[1];

            bool xPlus = x > 0;
            bool yPlus = y > 0;
            x = Abs(x);
            y = Abs(y);

            int maxDig = 0;
            long div = 1;
            while (x >= div || y >= div)
            {
                maxDig++;
                div *= 2;
            }

            bool[,] cans = new bool[maxDig + 1, 4];
            cans[0, 0] = true;
            div = 1;
            string[,] res = new string[maxDig + 1, 4];
            res[0, 0] = "";
            for (int i = 1; i <= maxDig; i++)
            {
                bool x1 = (x & div) > 0;
                bool y1 = (y & div) > 0;
                if (cans[i - 1, 0])
                {
                    if (x1 && !y1)
                    {
                        cans[i, 0] = true;
                        res[i, 0] =""+ res[i - 1, 0];
                        res[i, 0] += xPlus ? 'E' : 'W';
                        cans[i, 1] = true;
                        res[i, 1] = "" + res[i - 1, 0];
                        res[i, 1] += xPlus ? 'W' : 'E';
                    }
                    if (!x1 && y1)
                    {
                        cans[i, 0] = true;
                        res[i, 0] = "" + res[i - 1, 0];
                        res[i, 0] += yPlus ? 'N' : 'S';
                        cans[i, 2] = true;
                        res[i, 2] = "" + res[i - 1, 0];
                        res[i, 2] += yPlus ? 'S' : 'N';
                    }
                }
                if (cans[i - 1, 1])
                {
                    if (x1 && y1)
                    {
                        cans[i, 1] = true;
                        res[i, 1] = "" + res[i - 1, 1];
                        res[i, 1] += yPlus ? 'N' : 'S';
                        cans[i, 3] = true;
                        res[i, 3] = "" + res[i - 1, 1];
                        res[i, 3] += yPlus ? 'S' : 'N';
                    }
                    if (!x1 && !y1)
                    {
                        cans[i, 0] = true;
                        res[i, 0] = "" + res[i - 1, 1];
                        res[i, 0] += xPlus ? 'E' : 'W';
                    }
                }
                if (cans[i - 1, 2])
                {
                    if (x1 && y1)
                    {
                        cans[i, 2] = true;
                        res[i, 2] = "" + res[i - 1, 2];
                        res[i, 2] += xPlus ? 'E' : 'W';
                        cans[i, 3] = true;
                        res[i, 3] = "" + res[i - 1, 2];
                        res[i, 3] += xPlus ? 'W' : 'E';
                    }
                    if (!x1 && !y1)
                    {
                        cans[i, 0] = true;
                        res[i, 0] = "" + res[i - 1, 2];
                        res[i, 0] += yPlus ? 'N' : 'S';
                    }
                }
                if (cans[i - 1, 3])
                {
                    if (!x1 && y1)
                    {
                        cans[i, 2] = true;
                        res[i, 2] = "" + res[i - 1, 3];
                        res[i, 2] += xPlus ? 'E' : 'W';
                    }
                    if (x1 && !y1)
                    {
                        cans[i, 1] = true;
                        res[i, 1] = "" + res[i - 1, 3];
                        res[i, 1] += yPlus ? 'N' : 'S';
                    }
                }

                div *= 2;
            }

            if (cans[maxDig, 0])
            {
                return () => WriteLine(res[maxDig, 0]);
            }
            if (cans[maxDig, 1])
            {
                return () => WriteLine(res[maxDig, 1] + (xPlus ? "E" : "W"));
            }
            if (cans[maxDig, 2])
            {
                return () => WriteLine(res[maxDig, 2] + (yPlus ? "N" : "S"));
            }
            return () => WriteLine("IMPOSSIBLE");
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
