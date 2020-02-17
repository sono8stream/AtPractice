using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_155
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
            int n = ReadInt();
            int[] array = ReadInts();
            for(int i = 0; i < n; i++)
            {
                if (array[i] % 2 == 1)
                {
                    continue;
                }

                if (array[i] % 3 == 0 || array[i] % 5 == 0)
                {
                    continue;
                }

                WriteLine("DENIED");
                return;
            }
            WriteLine("APPROVED");
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
