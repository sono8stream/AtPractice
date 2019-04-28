using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class DDCC2019Final_B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] nkr = ReadLongs();
            long n = nkr[0];
            long k = nkr[1];
            long r = nkr[2];
            long max = (n - k) * (n - k + 1) / 2;
            if (max < r)
            {
                WriteLine("No Luck");
            }
            else
            {
                bool[] used = new bool[n];
                long min = 1;
                long remain = max - r;
                while (remain > 0)
                {
                    if (remain >= n - k - min + 1)
                    {
                        Write(min);
                        used[min - 1] = true;
                        remain -= n - k - min + 1;
                        min++;
                    }
                    else
                    {
                        Write( n - k - remain + 1);
                        used[n - k - remain] = true;
                        remain = 0;
                    }
                    Write(' ');
                }
                for(long i = n - 1; i >= 0; i--)
                {
                    if (used[i]) continue;
                    Write(i + 1);
                    Write(' ');
                }
                WriteLine();
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
