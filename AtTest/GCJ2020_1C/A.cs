using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2020_1C
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
            string[] str = Read().Split();
            int x = int.Parse(str[0]);
            int y = int.Parse(str[1]);
            string path = str[2];
            int res = int.MaxValue;
            if (Abs(x) + Abs(y) == 0)
            {
                res = 0;
            }
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == 'N')
                {
                    y++;
                }
                if (path[i] == 'W')
                {
                    x--;
                }
                if (path[i] == 'S')
                {
                    y--;
                }
                if (path[i] == 'E')
                {
                    x++;
                }

                if (Abs(x) + Abs(y) <= i + 1)
                {
                    res = Min(res, i + 1);
                }
            }
            return () =>
            {
                if (res == int.MaxValue)
                {
                    WriteLine("IMPOSSIBLE");
                }
                else
                {
                    WriteLine(res);
                }
            };
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
