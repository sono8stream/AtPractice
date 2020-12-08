using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1409
{
    class C
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
                int[] nxy = ReadInts();
                int n = nxy[0];
                int x = nxy[1];
                int y = nxy[2];
                int delta = y - x;
                for(int j = 1; j < y; j++)
                {
                    if (delta % j != 0)
                    {
                        continue;
                    }

                    int cnt = delta / j + 1;
                    if (cnt > n)
                    {
                        continue;
                    }
                    int min = x;
                    while (cnt < n && min > j)
                    {
                        min -= j;
                        cnt++;
                    }

                    for(int k = 0; k < n; k++)
                    {
                        Write(min + k * j);
                        if (k + 1 < n)
                        {
                            Write(" ");
                        }
                    }
                    WriteLine();
                    break;
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
