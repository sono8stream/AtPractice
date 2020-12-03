using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1407
{
    class B
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
                int n = ReadInt();
                int[] array = ReadInts();
                Array.Sort(array);
                bool[] used = new bool[n];
                int now = array[n - 1];
                for(int j = 0; j < n; j++)
                {
                    int max = 0;
                    int idx = -1;
                    for(int k = 0; k < n; k++)
                    {
                        if (used[k])
                        {
                            continue;
                        }

                        int gcd = (int)GCD(now, array[k]);
                        if (gcd > max)
                        {
                            max = gcd;
                            idx = k;
                        }
                    }

                    Write(array[idx]);
                    used[idx] = true;
                    now = max;
                    if (j + 1 < n)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
