using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Aising_2020
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

            int[] cnts = new int[n + 1];
            for(int x = 1; x <= 100; x++)
            {
                for(int y = 1; y <= 100; y++)
                {
                    for(int z = 1; z <= 100; z++)
                    {
                        int val = x * x + y * y + z * z + x * y + y * z + z * x;
                        if (val <= n)
                        {
                            cnts[val]++;
                        }
                    }
                }
            }

            for(int i = 1; i <= n; i++)
            {
                WriteLine(cnts[i]);
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
