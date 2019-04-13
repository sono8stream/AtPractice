using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1A
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
            for(int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for(int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int[] rc = ReadInts();
            bool rev = rc[0] > rc[1];
            int h = Min(rc[0], rc[1]);
            int w = Max(rc[0], rc[1]);
            if (w == 2) return () => WriteLine("IMPOSSIBLE");
            if (h == 2)
            {
                if (w < 5) return () => WriteLine("IMPOSSIBLE");
                else
                {
                    return () =>
                    {
                        WriteLine("POSSIBLE");
                        for (int i = w - 2; i >= 1; i--)
                        {
                            if (rev)
                            {
                                WriteLine(i + " " + 1);
                                WriteLine((i + 2) + " " + 2);
                            }
                            else
                            {
                                WriteLine(1 + " " + i);
                                WriteLine(2 + " " + (i + 2));
                            }
                        }
                        if (rev)
                        {
                            WriteLine(w + " " + 1);
                            WriteLine(2 + " " + 2);
                            WriteLine((w-1) + " " + 1);
                            WriteLine(1 + " " + 2);
                        }
                        else
                        {
                            WriteLine(1 + " " + w);
                            WriteLine(2 + " " + 2);
                            WriteLine(1 + " " + (w - 1));
                            WriteLine(2 + " " + 1);
                        }
                    };
                }
            }
            if (h == 3)
            {
                if (w < 4) return () => WriteLine("IMPOSSIBLE");
                else return () =>
                     {
                         WriteLine("POSSIBLE");
                         for (int i = 1; i <= w; i++)
                         {
                             for (int j = 1; j <= h; j++)
                             {
                                 int c = j % 2 == 0 ? (i + 2) % w : i;
                                 if (c == 0) c = w;
                                 if (rev)
                                 {
                                     WriteLine(c + " " + j);
                                 }
                                 else
                                 {
                                     WriteLine(j + " " + c);
                                 }
                             }
                         }
                     };
            }
            return () =>
            {
                WriteLine("POSSIBLE");
                for (int i = 1; i <= w; i++)
                {
                    for (int j = 1; j <= h; j++)
                    {
                        int r = (w == h && i == w && w % 2 == 0) ? (j + 1) % h : j;
                        if (r == 0) r = h;
                        int c = r % 2 == 0 ? (i + 2) % w: i;
                        if (c == 0) c = w;
                        if (rev)
                        {
                            WriteLine(c + " " + r);
                        }
                        else
                        {
                            WriteLine(r + " " + c);
                        }
                    }
                }
            };
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
