using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_157
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
            int[,] array = new int[3, 3];
            for(int i = 0; i < 3; i++)
            {
                int[] vals = ReadInts();
                for(int j = 0; j < 3; j++)
                {
                    array[i, j] = vals[j];
                }
            }
            int n = ReadInt();
            bool[,] appears = new bool[3,3];
            for(int i = 0; i < n; i++)
            {
                int b = ReadInt();
                for(int j = 0; j < 3; j++)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        if (array[j, k] == b)
                        {
                            appears[j, k] = true;
                        }
                    }
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if ((appears[j, 0] && appears[j, 1] && appears[j, 2])
                    || (appears[0, j] && appears[1, j] && appears[2, j]))
                {
                    WriteLine("Yes");
                    return;
                }
            }
            if ((appears[0, 0] && appears[1, 1] && appears[2, 2])
                || (appears[0, 2] & appears[1, 1] && appears[2, 0]))
            {
                WriteLine("Yes");
                return;
            }
            WriteLine("No");
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
