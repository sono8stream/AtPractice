using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1417
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
                int[] nt = ReadInts();
                int n = nt[0];
                int tt = nt[1];
                int[] array = ReadInts();
                int halves = 0;
                for(int j = 0; j < n; j++)
                {
                    if (array[j]*2 == tt)
                    {
                        halves++;
                    }
                }

                int tmpHalves = 0;
                for(int j = 0; j < n; j++)
                {
                    if (array[j] * 2 < tt)
                    {
                        Write(0);
                    }
                    if (array[j] * 2 == tt)
                    {
                        tmpHalves++;
                        if (tmpHalves * 2 <= halves)
                        {
                            Write(0);
                        }
                        else
                        {
                            Write(1);
                        }
                    }
                    if (array[j] * 2 > tt)
                    {
                        Write(1);
                    }

                    if (j < n - 1)
                    {
                        Write(' ');
                    }
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
