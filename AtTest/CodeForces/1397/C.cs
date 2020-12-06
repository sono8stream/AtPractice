using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1397
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
            int n = ReadInt();
            long[] array = ReadLongs();
            if (n == 1)
            {
                WriteLine(1 + " " + 1);
                WriteLine(-array[0]);
                WriteLine(1 + " " + 1);
                WriteLine(array[0]);
                WriteLine(1 + " " + 1);
                WriteLine(-array[0]);
                return;
            }

            WriteLine(1 + " " + (n - 1));
            for(int i = 0; i < n - 1; i++)
            {
                long margin = Abs(array[i]) % n;
                if (margin > 0)
                {
                    Write(array[i] / Abs(array[i]) * (n - 1) * margin);
                    array[i] += array[i] / Abs(array[i]) * (n - 1) * margin;
                }
                else
                {
                    Write(0);
                }
                if (i + 1 < n - 1)
                {
                    Write(' ');
                }
            }
            WriteLine();

            WriteLine(n + " " + n);
            long delta = n - Abs(array[n - 1]) % n;
            WriteLine(array[n - 1] / Abs(array[n - 1]) * delta);
            array[n - 1] += array[n - 1] / Abs(array[n - 1]) * delta;

            WriteLine(1 + " " + n);
            for(int i = 0; i < n; i++)
            {
                Write(-array[i]);
                if (i + 1 < n)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
