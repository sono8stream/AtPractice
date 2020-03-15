using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Panasonic2020
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
            int n = ReadInt();
            int[] tmp = new int[n];
            int[] maxs = new int[n];
            for(int i = 0; i < n; i++)
            {
                Write('a');
            }
            WriteLine();
            while (true)
            {
                int index = -1;
                for (int i = n - 1; i > 0; i--)
                {
                    if (tmp[i] - maxs[i - 1] <= 0)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                {
                    break;
                }

                tmp[index]++;
                for(int i = 1; i < n; i++)
                {
                    maxs[i] = Max(maxs[i - 1], tmp[i]);
                }

                for(int i = index + 1; i < n; i++)
                {
                    tmp[i] = 0;
                }
                
                for(int i = 0; i < n; i++)
                {
                    Write((char)('a' + tmp[i]));
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
